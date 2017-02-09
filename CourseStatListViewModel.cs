using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSandbox.DataAccess;

namespace WPFSandbox.Courses
{
    public class CourseStatListViewModel : BindableBase
    {
        private readonly Dal _dal = new Dal();
        private ObservableCollection<CourseStat> _courseStats;
        private int _courseId;

        public RelayCommand AddTeeMarkerCommand { get; private set; }
        public RelayCommand<CourseStat> ViewRoundsCommand { get; private set; }
        public RelayCommand<CourseStat> ViewHolesCommand { get; private set; }


        public event Action<CourseStat> AddTeeMarkerRequested = delegate { };
        public event Action<int> ViewRoundsRequested = delegate { };
        public event Action<int, int> ViewHolesRequested = delegate { };

        public CourseStatListViewModel()
        {
            AddTeeMarkerCommand = new RelayCommand(OnAddTeeMarker);
            ViewRoundsCommand = new RelayCommand<CourseStat>(OnViewRounds);
            ViewHolesCommand = new RelayCommand<CourseStat>(OnViewHoles);
        }

        private void OnViewHoles(CourseStat courseStat)
        {
            ViewHolesRequested(courseStat.CourseId, courseStat.TeeMarkerId);
        }

        private void OnViewRounds(CourseStat courseStat)
        {
           ViewRoundsRequested(courseStat.CourseId);
        }

        private void OnAddTeeMarker()
        {
            AddTeeMarkerRequested(new CourseStat() {CourseId = CourseId});
        }

        public int CourseId
        {
            get { return _courseId; }
            set { SetProperty(ref _courseId, value); }
        }

        public ObservableCollection<CourseStat> CourseStats
        {
            get { return _courseStats; }
            set { SetProperty(ref _courseStats, value); }
        }

        public void LoadCourseStats()
        {
            CourseStats = new ObservableCollection<CourseStat>(_dal.GetCourseStats(CourseId));
        }
    }
}
