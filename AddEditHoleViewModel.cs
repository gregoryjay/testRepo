using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSandbox.DataAccess;

namespace WPFSandbox.Holes
{
    class AddEditHoleViewModel : BindableBase
    {
        private bool _editMode;
        private Hole _editingHole;
        private SimpleEditableHole _hole;
        private readonly Dal _dal = new Dal();

        public AddEditHoleViewModel()
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        public bool EditMode
        {
            get { return _editMode; }
            set { SetProperty(ref _editMode, value); }
        }

        public SimpleEditableHole Hole
        {
            get { return _hole; }
            set { SetProperty(ref _hole, value);}
        }

        private bool CanSave()
        {
            return !Hole.HasErrors;
        }

        private void OnSave()
        {
            UpdateHole(Hole, _editingHole);
            if (EditMode)
            {
                _dal.UpdateHole(_editingHole);
            }
            else
            {
                _dal.InsertHole(_editingHole);
            }
            Done();
        }

        private void UpdateHole(SimpleEditableHole source, Hole target)
        {
            target.Number = source.Number;
            target.Par = source.Par;
            target.Handicap = source.Handicap;
            target.Yardage = source.Yardage;
        }

        private void OnCancel()
        {
            Done();
        }

        internal void SetHole(Hole hole)
        {
            _editingHole = hole;
            if (Hole != null) Hole.ErrorsChanged -= RaiseCanExecuteChanged;

            Hole = new SimpleEditableHole();

            Hole.ErrorsChanged += RaiseCanExecuteChanged;
            CopyHole(hole, Hole);
        }

        private void CopyHole(Hole source, SimpleEditableHole target)
        {
            target.CourseId = source.CourseId;
            target.TeeMarkerId = source.TeeMarkerId;

            if (EditMode)
            {
                target.Number = source.Number;
                target.Par = source.Par;
                target.Handicap = source.Handicap;
                target.Yardage = source.Yardage;
            }
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }
    }
}
