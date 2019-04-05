using CompileIt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompileItWebApi
{
    public class RollStatus : CompileIt.Status
    {
        public List<RollInfo> DieSides { get; set; } = new List<RollInfo>();
    }
}
