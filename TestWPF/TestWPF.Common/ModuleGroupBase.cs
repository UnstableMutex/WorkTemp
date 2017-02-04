using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Common
{

    public class ModuleGroupBase : IModuleGroup
    {
        public ModuleGroupBase(string name)
        {
            Name = name;
            Directory = name;
        }
        public string Name { get; private set; }
        public string Directory { get; private set; }
    }
}
