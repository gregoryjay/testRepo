using System;
using WPFSandbox.DataAccess;

namespace WPFSandbox.Courses
{
    class AddEditCourseListViewModel : BindableBase
    {
        private bool _editMode;
        private Course _editingCourse;
        private SimpleEditableCourse _course;
        private readonly Dal _dal = new Dal();

        public AddEditCourseListViewModel()
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        private bool CanSave()
        {
            return !Course.HasErrors;
        }

        private void OnSave()
        {
            UpdateCourse(Course, _editingCourse);
            if (EditMode)
            {
                _dal.UpdateCourse(_editingCourse);
            }
            else
            {
                _dal.InsertCourse(_editingCourse);
            }
            Done();
        }

        private void UpdateCourse(SimpleEditableCourse source, Course target)
        {
            target.Name = source.Name;
            target.City = source.City;
            target.State = source.State;
            target.Par = source.Par;
        }

        private void OnCancel()
        {
            Done();
        }

        public SimpleEditableCourse Course
        {
            get { return _course; }
            set { SetProperty(ref _course, value); }
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        public bool EditMode
        {
            get { return _editMode; }
            set {SetProperty(ref _editMode, value); }
        }

        public void SetCourse(Course course)
        {
            _editingCourse = course;
            if (Course != null) Course.ErrorsChanged -= RaiseCanExecuteChanged;

            Course = new SimpleEditableCourse();

            Course.ErrorsChanged += RaiseCanExecuteChanged;
            CopyCourse(course, Course);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyCourse(Course source, SimpleEditableCourse target)
        {
            target.CourseId = source.CourseId;

            if (EditMode)
            {
                target.Name = source.Name;
                target.City = source.City;
                target.State = source.State;
                target.Par = source.Par;
                //target.TeeMarkerId = source.TeeMarkerId;
                //target.Rating = source.Rating;
                //target.Slope = source.Slope;
            }
        }
    }
}
