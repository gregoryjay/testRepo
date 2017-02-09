using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSandbox.Courses
{
    class SimpleEditableCourseStat : ValidatableBindableBase
    {
        public int CourseStatId { get; set; }
        public int CourseId { get; set; }
        public int TeeMarkerId { get; set; }
        public int Slope { get; set; }
        public double Rating { get; set; }
        public int Yardage { get; set; }
    }
}
