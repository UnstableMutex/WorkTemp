using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestUWP.Interface;

namespace TestUWP.ViewModel
{
    class MainViewModel
    {
        public MainViewModel()
        {


            ContainerConfiguration cc = new ContainerConfiguration();
            var conf = cc.WithAssembly(typeof(IGroup).GetTypeInfo().Assembly);
            var c = conf.CreateContainer();
            var grs = c.GetExports<IGroup>();
         
            var vms = ms.Select(x => new ModuleViewModel(x));
            return vms;



        }
        public IEnumerable<GroupViewModel> Groups { get; private set; }
    }
}
