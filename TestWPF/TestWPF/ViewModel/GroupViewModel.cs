using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Common;

namespace TestWPF.ViewModel
{
    class GroupViewModel
    {
        private readonly IModuleGroup _group;

        public GroupViewModel(IModuleGroup group)
        {
            _group = @group;
        }
    }
}
