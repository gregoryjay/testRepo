using System.Collections.Generic;

namespace WPFSandbox
{
    public class Course
    {
        public int CourseId  { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Par { get; set; }
        public int TeeMarkerId { get; set; }
        public int Slope { get; set; }
        public double Rating { get; set; }
        public List<Hole> Holes { get; set; }
    }
}
