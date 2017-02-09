using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSandbox.DataAccess;

namespace WPFSandbox.Players
{
    class AddEditPlayerViewModel : BindableBase
    {
        private bool _editMode;
        public SimpleEditablePlayer Player { get; set; }
        private Player _editingPlayer;
        private readonly Dal _dal = new Dal();

        public AddEditPlayerViewModel()
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        private void OnSave()
        {
            UpdatePlayer(Player, _editingPlayer);
            if (EditMode)
            {
                _dal.UpdatePlayer(_editingPlayer);
            }
            else
            {
                _dal.InsertPlayer(_editingPlayer);
            }
            Done();
        }

        private void UpdatePlayer(SimpleEditablePlayer source, Player target)
        {
            target.Name = source.Name;
            target.Handicap = source.Handicap;
            target.IsMale = source.IsMale;
            target.Age = source.Age;
        }

        private void OnCancel()
        {
            Done();
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private bool CanSave()
        {
            return !Player.HasErrors;
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyPlayer(Player target, SimpleEditablePlayer source)
        {
            target.PlayerId = source.PlayerId;

            if (EditMode)
            {
                target.Name = source.Name;
                target.Handicap = source.Handicap;
                target.IsMale = source.IsMale;
                target.Age = source.Age;
            }
        }


        internal void SetPlayer(Player player)
        {
            _editingPlayer = player;
            if (Player != null) Player.ErrorsChanged -= RaiseCanExecuteChanged;

            Player = new SimpleEditablePlayer();

            Player.ErrorsChanged += RaiseCanExecuteChanged;
            CopyPlayer(player, Player);
        }

        public bool EditMode
        {
            get { return _editMode; }
            set { SetProperty(ref _editMode, value); }
        }
    }
}
