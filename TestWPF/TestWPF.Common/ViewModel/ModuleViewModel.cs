using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Common.ViewModel
{
    public class ModuleViewModel
    {
        private readonly IModule _module;

        public ModuleViewModel(IModule module)
        {
            _module = module;
        }
        public string Name { get { return _module.Name; } }
    }
}
