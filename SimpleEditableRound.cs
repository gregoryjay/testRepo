using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSandbox.Rounds
{
    class SimpleEditableRound : ValidatableBindableBase
    {
        public int RoundId { get; set; }
        public int PlayerId { get; set; }
        public int CourseId { get; set; }
        public DateTime TeeTime { get; set; }
        public int GroupSize { get; set; }
        public int TreeHole { get; set; }
        public int DrinkHole { get; set; }
    }
}
