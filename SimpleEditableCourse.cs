using System.ComponentModel.DataAnnotations;

namespace WPFSandbox.Courses
{
    public class SimpleEditableCourse : ValidatableBindableBase
    {
        private int _courseId;
        private string _name;
        private string _city;
        private string _state;
        private int _par;
        private int _teeMarkerId;
        private int _slope;
        private double _rating;

        public int CourseId
        {
            get { return _courseId; }
            set { SetProperty(ref _courseId, value); }
        }

        [Required]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [Required]
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        [Required]
        public string State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        [Required]
        public int Par
        {
            get { return _par; }
            set { SetProperty(ref _par, value); }
        }

        [Required]
        public int TeeMarkerId
        {
            get { return _teeMarkerId; }
            set { SetProperty(ref _teeMarkerId, value); }
        }

        [Required]
        public int Slope
        {
            get { return _slope; }
            set { SetProperty(ref _slope, value); }
        }

        [Required]
        public double Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }
    }
}
