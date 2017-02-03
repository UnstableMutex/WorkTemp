using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Common
{
    public interface IName
    {
        string Name { get; }
    }
    public interface IModule:IName
    {
        string FileName { get; }
    }
}
