using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Common;

namespace TestWPF.SampleGroup.SampleAddin
{
    [Export(typeof(IModule))]
    public class SampleModule:IModule
    {
        public SampleModule()
        {
            Name = "SampleModule";
            FileName = "notepad.exe";
        }
        public string Name { get; private set; }
        public string FileName { get; private set; }
    }
}
