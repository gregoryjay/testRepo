using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSandbox.DataAccess;

namespace WPFSandbox.Rounds
{
    class RoundListViewModel : BindableBase
    {
        private readonly Dal _dal = new Dal();
        private int _courseId;
        private ObservableCollection<Round> _rounds;

        public ObservableCollection<Round> Rounds
        {
            get { return _rounds; }
            set { SetProperty(ref _rounds, value); }
        }

        public RoundListViewModel()
        {
           AddRoundCommand = new RelayCommand(OnAddRound);
           ViewScorecardCommand = new RelayCommand<Round>(OnViewScorecard);
        }

        private void OnViewScorecard(Round round)
        {
            ViewScorecardRequested(round.RoundId);
        }

        private void OnAddRound()
        {
            AddRoundRequested(new Round() { CourseId = CourseId });
        }

        public RelayCommand AddRoundCommand { get; private set; }
        public event Action<Round> AddRoundRequested = delegate { };

        public RelayCommand<Round> ViewScorecardCommand { get; private set; }
        public event Action<int> ViewScorecardRequested = delegate { };

        public void LoadRounds()    
        {
            Rounds = new ObservableCollection<Round>(_dal.GetRounds(CourseId));
        }

        public int CourseId
        {
            get { return _courseId; }
            set { SetProperty(ref _courseId, value); }
        }

    }
}
