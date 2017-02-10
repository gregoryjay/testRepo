using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSandbox.HoleStats
{
    public class RoundStat
    {
        public int Number { get; set; }
        public int Par { get; set; }
        public int Score { get; set; }
        public bool GIR { get; set; }
        public bool FwyHit { get; set; }
        public int Putts { get; set; }
        public int Handicap { get; set; }
        public int Yardage { get; set; }
    }
}
