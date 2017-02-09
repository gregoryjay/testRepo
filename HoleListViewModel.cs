using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSandbox.DataAccess;

namespace WPFSandbox.Holes
{
    class HoleListViewModel : BindableBase
    {
        private readonly Dal _dal = new Dal();
        private ObservableCollection<Hole> _holes;
        private int _courseId;
        private int _teeMarkerId;

        public RelayCommand AddHoleCommand { get; private set; }
        public event Action<Hole> AddHolesRequested = delegate { };

        public HoleListViewModel()
        {
            AddHoleCommand = new RelayCommand(OnAddHoles);
        }

        private void OnAddHoles()
        {
            AddHolesRequested(new Hole() { CourseId = CourseId, TeeMarkerId = TeeMarkerId});
        }

        public ObservableCollection<Hole> Holes
        {
            get { return _holes; }
            set { SetProperty(ref _holes, value); }
        }

        public int CourseId
        {
            get { return _courseId; }
            set { SetProperty(ref _courseId, value); }
        }

        public int TeeMarkerId
        {
            get { return _teeMarkerId; }
            set { SetProperty(ref _teeMarkerId, value); }
        }

        public void LoadHoles()
        {
            Holes = new ObservableCollection<Hole>(_dal.GetHoles(CourseId, TeeMarkerId));
        }

    }
}
