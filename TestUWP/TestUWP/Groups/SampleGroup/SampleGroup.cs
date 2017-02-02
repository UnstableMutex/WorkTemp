using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUWP.Interface;

namespace TestUWP.Groups.SampleGroup
{
    [Export(typeof(IGroup))]
   public class SampleGroup:IGroup
    {
        public SampleGroup()
        {
            Name = "SampleGroup";
        }
        public string Name { get; private set; }
    }
}
