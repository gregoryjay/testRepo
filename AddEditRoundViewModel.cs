using System;
using WPFSandbox.DataAccess;

namespace WPFSandbox.Rounds
{
    class AddEditRoundViewModel : BindableBase
    {
        private int _courseId;
        public bool EditMode { get; internal set; }
        public SimpleEditableRound Round { get; set; }
        private Round _editingingRound = null;
        private readonly Dal _dal = new Dal();

        public AddEditRoundViewModel()
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        private void OnSave()
        {
            UpdateRound(Round, _editingingRound);
            if (EditMode)
            {
                _dal.UpdateRound(_editingingRound);
            }
            else
            {
                _dal.InsertRound(_editingingRound);
            }
            Done();
        }

        private void UpdateRound(SimpleEditableRound source, Round target)
        {
            target.CourseId = source.CourseId;
            target.PlayerId = source.PlayerId;
            
            target.TeeTime = source.TeeTime;
            target.GroupSize = source.GroupSize;
            target.DrinkHole = source.DrinkHole;
            target.TreeHole = source.TreeHole;
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
            return !Round.HasErrors;
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyRound(Round target, SimpleEditableRound source)
        {
            target.PlayerId = source.PlayerId;

            source.CourseId = target.CourseId;
            source.TeeTime = DateTime.Now;
            //target.CourseId = source.CourseId;

            if (EditMode)
            {
                target.TeeTime = source.TeeTime;
                target.GroupSize = source.GroupSize;
                target.DrinkHole = source.DrinkHole;
                target.TreeHole = source.TreeHole;
            }
        }

        internal void SetRound(Round round)
        {
            _editingingRound = round;

            if (Round != null) Round.ErrorsChanged -= RaiseCanExecuteChanged;

            Round = new SimpleEditableRound();

            Round.ErrorsChanged += RaiseCanExecuteChanged;
            CopyRound(round, Round);
        }

        public int CourseId
        {
            get { return _courseId; }
            set { SetProperty(ref _courseId, value); }
        }
    }
}
