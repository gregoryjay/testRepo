using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSandbox.DataAccess;

namespace WPFSandbox.HoleStats
{
    class HoleStatViewModel : BindableBase
    {
        private readonly Dal _dal = new Dal();
        private int _roundId;
        private ObservableCollection<HoleStat> _holeStats;

    
        public RelayCommand AddHoleStatCommand { get; private set; }
        public event Action<HoleStat> AddHoleStatRequested = delegate { };

        public HoleStatViewModel()
        {
            AddHoleStatCommand = new RelayCommand(OnAddHoleStat);
        }

        private void OnAddHoleStat()
        {
            AddHoleStatRequested(new HoleStat() {RoundId = RoundId});
        }

        public void LoadHoleStats()
        {
            HoleStats = new ObservableCollection<HoleStat>(_dal.GetHoleStats(RoundId));
        }

        public int RoundId
        {
            get { return _roundId; }
            set { SetProperty(ref _roundId, value); }
        }

        public ObservableCollection<HoleStat> HoleStats
        {
            get { return _holeStats; }
            set { SetProperty(ref _holeStats, value); }
        }

    }
}
