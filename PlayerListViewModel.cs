using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSandbox.DataAccess;

namespace WPFSandbox.Players
{
    class PlayerListViewModel : BindableBase
    {
        private readonly Dal _dal = new Dal();
        private ObservableCollection<Player> _players;

        public RelayCommand AddPlayerCommand { get; private set; }
        public event Action<Player> AddPlayerRequested = delegate { };

        public PlayerListViewModel()
        {
            AddPlayerCommand = new RelayCommand(OnAddPlayer);
        }

        private void OnAddPlayer()
        {
            AddPlayerRequested(new Player());
        }

        public ObservableCollection<Player> Players
        {
            get { return _players; }
            set { SetProperty(ref _players, value); }
        }

        public void LoadPlayers()
        {
            Players = new ObservableCollection<Player>(_dal.GetPlayers());
        }
    }
}
