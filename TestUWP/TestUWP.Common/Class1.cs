using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUWP.Common
{

    public interface IModule
    {
        string RelativeFN { get; set; }
        string Name { get; set; }
    }
    public interface IGroup
    {
        string Name { get; }
        string Path { get; }
    }
}
