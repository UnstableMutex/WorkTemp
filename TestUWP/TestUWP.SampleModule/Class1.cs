using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUWP.Common;

namespace TestUWP.SampleModule
{
    [Export(typeof(IModule))]
    public class SampleModule : IModule
    {
        public SampleModule()
        {
            Name = "Notepad";
            RelativeFN = "Notepad.exe";
        }
        public string Name { get; set; }
        public string RelativeFN { get; set; }
    }
}
