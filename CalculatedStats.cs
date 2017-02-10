using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSandbox.HoleStats
{
    class CalculatedStats
    {
        public int Pars { get; set; }
        public int Birdies { get; set; }
        public int Eagles { get; set; }
        public int DoubleEagles { get; set; }
        public int DoubleBogeys { get; set; }
        public int Bogeys { get; set; }
        public int TripleBogeys { get; set; }
        public int Meltdowns { get; set; }
        public int FwysHit { get; set; }
        public int GIRs { get; set; }
        public int TotalPutts { get; set; }
        public int TotalScore { get; internal set; }
    }
}
