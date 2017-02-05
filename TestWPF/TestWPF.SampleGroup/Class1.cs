using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TestWPF.Common;
using TestWPF.Common.ViewModel;

namespace TestWPF.SampleGroup
{
    [Export(typeof(IModuleGroup))]
    public class SampleGroup:ModuleGroupBase
    {
        public SampleGroup() : base(nameof(SampleGroup))
        {
        }

        
       public override IEnumerable<IModule> GetModules()
        {
            var c = new CompositionContainer(new DirectoryCatalog(Directory));
            c.ComposeParts();
            var modules = c.GetExportedValues<IModule>();
            return modules;

        }
        
    }
}
