using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUWP.Interface;

namespace TestUWP.ViewModel
{
    class ModuleViewModel
    {
        private readonly IModule _module;

        public ModuleViewModel(IModule module)
        {
            _module = module;
        }
        public string Caption { get { return _module.Name; } }

    }
}
