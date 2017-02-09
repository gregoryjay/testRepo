using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSandbox.Holes
{
    class SimpleEditableHole : ValidatableBindableBase
    {
        public int HoleId { get; set; }
        public int CourseId { get; set; }
        public int TeeMarkerId { get; set; }
        public int Number { get; set; }
        public int Par { get; set; }
        public int Handicap { get; set; }
        public int Yardage { get; set; }
    }
}
