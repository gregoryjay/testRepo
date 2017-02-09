using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSandbox.Players
{
    class SimpleEditablePlayer : ValidatableBindableBase
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Handicap { get; set; }
        public int Age { get; set; }
        public bool IsMale { get; set; }
    }
}
