using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUWP.Common;

namespace TestUWP.SampleGroup
{
    [Export(typeof(IGroup)]
    public class SampleGroup : IGroup
    {
        public SampleGroup()
        {
            Name = "SampleGroup";
            Path = "SampleGroupModules";
        }
        public string Name
        {
            get;private set;
        }

        public string Path
        {
            get;private set;
        }
    }
}
