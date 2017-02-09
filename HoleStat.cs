using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSandbox.HoleStats
{
    class HoleStat
    {
        public int HoleStatId { get; set; }
        public int HoleId { get; set; }
        public int RoundId { get; set; }
        public int Score { get; set; }
        public bool Gir { get; set; }
        public bool FwyHit { get; set; }
        public int Putts { get; set; }
    }
}
