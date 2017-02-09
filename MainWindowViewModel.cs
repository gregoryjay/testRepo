using System;
using WPFSandbox.Courses;
using WPFSandbox.Holes;
using WPFSandbox.HoleStats;
using WPFSandbox.Players;
using WPFSandbox.Rounds;

namespace WPFSandbox
{
    class MainWindowViewModel : BindableBase
    {
        private readonly CourseListViewModel _courseListViewModel = new CourseListViewModel();
        private readonly AddEditCourseListViewModel _addEditCourseViewModel = new AddEditCourseListViewModel();

        private readonly RoundListViewModel _roundListViewModel = new RoundListViewModel();
        private readonly AddEditRoundViewModel _addEditRoundViewModel = new AddEditRoundViewModel();

        private readonly CourseStatListViewModel _courseStatListViewModel = new CourseStatListViewModel();
        private readonly AddEditCourseStatViewModel _addEditCourseStatViewModel = new AddEditCourseStatViewModel();

        private readonly HoleListViewModel _holeListViewModel = new HoleListViewModel();
        private readonly AddEditHoleViewModel _addEditHoleViewModel = new AddEditHoleViewModel();

        private readonly PlayerListViewModel _playerListViewModel = new PlayerListViewModel();
        private readonly AddEditPlayerViewModel _addEditPlayerViewModel = new AddEditPlayerViewModel();

        private readonly HoleStatViewModel _holeStatViewModel = new HoleStatViewModel();
        private readonly AddEditHoleStatViewModel _addEditHoleStatViewModel = new AddEditHoleStatViewModel();

        private BindableBase _currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            _courseListViewModel.AddRoundRequested += NavToRound;
            _courseListViewModel.AddCourseRequested += NavToAddCourse;
            _courseListViewModel.EditCourseRequested += NavToEditCourse;
            _courseListViewModel.ViewCourseStatsRequested += NavToCourseStats;

            _courseStatListViewModel.AddTeeMarkerRequested += NavToAddCourseStat;
            _courseStatListViewModel.ViewHolesRequested += NavToHoles;
            _courseStatListViewModel.ViewRoundsRequested += NavToRounds;

            _holeListViewModel.AddHolesRequested += NavToAddHole;

            _playerListViewModel.AddPlayerRequested += NavToAddPlayer;

            _roundListViewModel.AddRoundRequested += NavToAddRound;
            _roundListViewModel.ViewScorecardRequested += NavToViewScorecard;

            _holeStatViewModel.AddHoleStatRequested += NavToAddHoleStat;


            _addEditHoleStatViewModel.Done += NavToHoleStats;
            _addEditRoundViewModel.Done += NavToRounds;
            _addEditPlayerViewModel.Done += NavToPlayerList;
            _addEditHoleViewModel.Done += NavToHoles;
            _addEditCourseViewModel.Done += NavToCourseList;
            _addEditCourseStatViewModel.Done += NavToCourseStats;
        }

        private void NavToViewScorecard(int roundId)
        {
            _holeStatViewModel.RoundId = roundId;
            CurrentViewModel = _holeStatViewModel;
        }

        private void NavToHoleStats()
        {
            CurrentViewModel = _holeStatViewModel;
        }

        private void NavToAddHoleStat(HoleStat holeStat)
        {
            _addEditHoleStatViewModel.EditMode = false;
            _addEditHoleStatViewModel.SetHoleStat(holeStat);

            CurrentViewModel = _addEditHoleStatViewModel;
        }

        private void NavToAddRound(Round round)
        {
            _addEditRoundViewModel.EditMode = false;
            _addEditRoundViewModel.SetRound(round);

            CurrentViewModel = _addEditRoundViewModel;
        }

        private void NavToRounds(int courseId)
        {
            _roundListViewModel.CourseId = courseId;

            CurrentViewModel = _roundListViewModel;
        }

        private void NavToRounds()
        {

            CurrentViewModel = _roundListViewModel;
        }

        private void NavToPlayerList()
        {
            CurrentViewModel = _playerListViewModel;
        }

        private void NavToAddPlayer(Player player)
        {
            _addEditPlayerViewModel.EditMode = false;
            _addEditPlayerViewModel.SetPlayer(player);

            CurrentViewModel = _addEditPlayerViewModel;
        }

        private void NavToHoles(int courseId, int teeMarkerId)
        {
            _holeListViewModel.CourseId = courseId;
            _holeListViewModel.TeeMarkerId = teeMarkerId;

            CurrentViewModel = _holeListViewModel;
        }

        private void NavToHoles()
        {
            CurrentViewModel = _holeListViewModel;
        }

        private void NavToAddHole(Hole hole)
        {
            _addEditHoleViewModel.EditMode = false;
            _addEditHoleViewModel.SetHole(hole);

            CurrentViewModel = _addEditHoleViewModel;
        }

        private void NavToAddCourseStat(CourseStat courseStat)
        {
            _addEditCourseStatViewModel.EditMode = false;
            _addEditCourseStatViewModel.SetCourse(courseStat);

            CurrentViewModel = _addEditCourseStatViewModel;
        }

        private void NavToCourseStats(int courseId)
        {
            _courseStatListViewModel.CourseId = courseId;
            CurrentViewModel = _courseStatListViewModel;
        }

        private void NavToCourseStats()
        {
            CurrentViewModel = _courseStatListViewModel;
        }


        private void NavToCourseList()
        {
            CurrentViewModel = _courseListViewModel;
        }

        private void NavToAddCourse(Course course)
        {
            _addEditCourseViewModel.EditMode = false;
            _addEditCourseViewModel.SetCourse(course);
            CurrentViewModel = _addEditCourseViewModel;
        }

        private void NavToEditCourse(Course course)
        {
            _addEditCourseViewModel.EditMode = true;
            _addEditCourseViewModel.SetCourse(course);
            CurrentViewModel = _addEditCourseViewModel;
        }

        private void NavToRound(int courseId)
        {
            _addEditRoundViewModel.CourseId = courseId;

            CurrentViewModel = _addEditRoundViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public RelayCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "courses":
                    CurrentViewModel = _courseListViewModel;
                    break;
                case "players":
                default:
                    CurrentViewModel = _playerListViewModel;
                    break;
            }
        }
    }
}
