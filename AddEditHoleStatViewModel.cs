using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSandbox.DataAccess;
using WPFSandbox.Players;

namespace WPFSandbox.HoleStats
{
    class AddEditHoleStatViewModel : BindableBase
    {
        public bool EditMode { get; internal set; }
        public SimpleEditableHoleStat HoleStat { get; set; }
        private HoleStat _editingHoleStat;
        private readonly Dal _dal = new Dal();

        public AddEditHoleStatViewModel()
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        private void OnSave()
        {
            UpdateHoleStat(HoleStat, _editingHoleStat);
            if (EditMode)
            {
                _dal.UpdateHoleStat(_editingHoleStat);
            }
            else
            {
                _dal.InsertHoleStat(_editingHoleStat);
            }
            Done();
        }

        private void UpdateHoleStat(SimpleEditableHoleStat source, HoleStat target)
        {
            target.HoleId = source.HoleId;
            target.Score = source.Score;
            target.FwyHit = source.FwyHit;
            target.Putts = source.Putts;
            target.Gir = source.Gir;
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
            return !HoleStat.HasErrors;
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }


        internal void SetHoleStat(HoleStat holeStat)
        {
            _editingHoleStat = holeStat;
            if (HoleStat != null) HoleStat.ErrorsChanged -= RaiseCanExecuteChanged;

            HoleStat = new SimpleEditableHoleStat();

            HoleStat.ErrorsChanged += RaiseCanExecuteChanged;
            CopyHoleStat(holeStat, HoleStat);
        }

        private void CopyHoleStat(HoleStat source, SimpleEditableHoleStat target)
        {
            target.RoundId = source.RoundId;
            target.HoleId = source.HoleId;

            if (EditMode)
            {
                target.Score = source.Score;
                target.FwyHit = source.FwyHit;
                target.Putts = source.Putts;
                target.Gir = source.Gir;
            }
        }
    }
}
