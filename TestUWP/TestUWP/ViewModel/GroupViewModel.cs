using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using TestUWP.Interface;

namespace TestUWP.ViewModel
{
    class GroupViewModel
    {
        private readonly IGroup _group;

        public GroupViewModel(IGroup group)
        {
            _group = @group;
            _modules = new Lazy<IEnumerable<ModuleViewModel>>(GetModules);
        }

        private IEnumerable<ModuleViewModel> GetModules()
        {
           
          ContainerConfiguration cc = new ContainerConfiguration();
           var conf= cc.WithAssembly(typeof(IModule).GetTypeInfo().Assembly);
         var c=   conf.CreateContainer();
            var modules = c.GetExports<IModule>();
            var ms = modules.Where(x => x.Group.GetType() == _group.GetType());
            var vms = ms.Select(x => new ModuleViewModel(x));
            return vms;

        }

        public string Header
        {
            get { return _group.Name; } 
        }

        private Lazy<IEnumerable<ModuleViewModel>> _modules;
        public IEnumerable<ModuleViewModel> Modules { get { return _modules.Value; } }

    }
}
