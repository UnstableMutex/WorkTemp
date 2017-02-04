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
        public string Name { get; }
        public string FileName { get; }
    }
}
