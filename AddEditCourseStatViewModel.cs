using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSandbox.DataAccess;

namespace WPFSandbox.Courses
{
    class AddEditCourseStatViewModel : BindableBase
    {
        private bool _editMode;
        private CourseStat _editingCourseStat = null;
        private SimpleEditableCourseStat _courseStat;
        private readonly Dal _dal = new Dal();

        public AddEditCourseStatViewModel()
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public event Action Done = delegate { };

        private void OnCancel()
        {
            Done();
        }

        private bool CanSave()
        {
            //return !CourseStat.HasErrors;
            return true;
        }

        private void OnSave()
        {
            UpdateCourse(CourseStat, _editingCourseStat);
            if (EditMode)
            {
                _dal.UpdateCourseStat(_editingCourseStat);
            }
            else
            {
                _dal.InsertCourseStat(_editingCourseStat);
            }
            Done();
        }

        private void UpdateCourse(SimpleEditableCourseStat source, CourseStat target)
        {
            target.CourseId = source.CourseId;
            target.TeeMarkerId = source.TeeMarkerId;
            target.Slope = source.Slope;
            target.Rating = source.Rating;
            target.Yardage = source.Yardage;
        }

        internal void SetCourse(CourseStat courseStat)
        {
            _editingCourseStat = courseStat;
            if (CourseStat != null) CourseStat.ErrorsChanged -= RaiseCanExecuteChanged;

            CourseStat = new SimpleEditableCourseStat();
            CopyCourseStat(courseStat, CourseStat);
        }

        private void CopyCourseStat(CourseStat source, SimpleEditableCourseStat target)
        {
            target.CourseId = source.CourseId;

            if (EditMode)
            {
                target.Yardage = source.Yardage;
                target.TeeMarkerId = source.TeeMarkerId;
                target.Rating = source.Rating;
                target.Slope = source.Slope;
            }
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public SimpleEditableCourseStat CourseStat
        {
            get { return _courseStat; }
            set { SetProperty(ref _courseStat, value); }
        }

        public bool EditMode
        {
            get { return _editMode; }
            set { SetProperty(ref _editMode, value); }
        }
    }
}
