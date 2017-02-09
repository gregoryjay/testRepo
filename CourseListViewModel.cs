using System;
using System.Collections.ObjectModel;
using WPFSandbox.DataAccess;

namespace WPFSandbox.Courses
{
    class CourseListViewModel : BindableBase
    {
        private readonly Dal _dal = new Dal();
        private ObservableCollection<Course> _courses;

        public ObservableCollection<Course> Courses
        {
            get { return _courses; }
            set { SetProperty(ref _courses, value); }
        }

        public CourseListViewModel()
        {
            AddRoundCommand = new RelayCommand<Course>(OnAddRound);
            AddCourseCommand = new RelayCommand(OnAddCourse);
            EditCourseCommand = new RelayCommand<Course>(OnEditCourse);
            ViewCourseStatsCommand = new RelayCommand<Course>(OnViewCourseStats);
        }

        private void OnViewCourseStats(Course course)
        {
            ViewCourseStatsRequested(course.CourseId);
        }


        private void OnAddCourse()
        {
           AddCourseRequested(new Course());
        }

        private void OnEditCourse(Course course)
        {
            EditCourseRequested(course);
        }

        public event Action<int> ViewCourseStatsRequested = delegate { };
        public event Action<Course> EditCourseRequested = delegate { };
        public event Action<Course> AddCourseRequested = delegate { };
        public event Action<int> AddRoundRequested = delegate { };

        private void OnAddRound(Course course)
        {
            AddRoundRequested(course.CourseId);
        }

        public void LoadCourses()
        {
            Courses = new ObservableCollection<Course>(_dal.GetAllCourses());
        }

        public RelayCommand<Course> AddRoundCommand { get; private set; }
        public RelayCommand<Course> ViewCourseStatsCommand { get; private set; }
        public RelayCommand AddCourseCommand { get; private set; }
        public RelayCommand<Course> EditCourseCommand { get; private set; }
    }
}
