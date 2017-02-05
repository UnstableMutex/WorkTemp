using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Common;

namespace TestWPF.ViewModel
{
    class MainViewModel
    {
        public MainViewModel()
        {
            
        }

        IEnumerable<GroupViewModel> GetGroups()
        {
            var c = new CompositionContainer(new DirectoryCatalog("Addins"));
            c.ComposeParts();
            var groups=c.GetExportedValues<IModuleGroup>();
            var result = groups.Select(x => new GroupViewModel(x)).ToList();
            return result;
        }
        public IEnumerable<GroupViewModel> Groups { get { return GetGroups(); } }
    }
}
