using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUWP.Interface
{
   public interface IModule
    {
        string Name { get; }
        string RelativeFN { get; }
        IGroup Group { get; }
    }
}
