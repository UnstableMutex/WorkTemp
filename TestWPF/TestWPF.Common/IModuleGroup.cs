using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Common
{
    interface IModuleGroup:IName
    {
        string Directory { get; }
    }
}
