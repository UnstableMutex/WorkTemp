using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Common;
using TestWPF.Common.ViewModel;

namespace TestWPF.ViewModel
{
    class GroupViewModel
    {
        private readonly IModuleGroup _group;

        public GroupViewModel(IModuleGroup group)
        {
            _group = @group;
        }
        public IEnumerable<ModuleViewModel> Modules { get { return GetModules(); } }

        private IEnumerable<ModuleViewModel> GetModules()
        {
            IEnumerable<ModuleViewModel> result;
            result = _group.GetModules().Select(x => new ModuleViewModel(x)).ToList();
            return result;
        }
    }
}
