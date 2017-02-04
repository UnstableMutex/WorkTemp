using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.Composition;
using TestWPF.Common;

namespace TestWPF.SampleGroup
{
    [Export(typeof(IModuleGroup))]
    public class SampleGroup:ModuleGroupBase
    {
        public SampleGroup() : base(nameof(SampleGroup))
        {
        }
    }
}
