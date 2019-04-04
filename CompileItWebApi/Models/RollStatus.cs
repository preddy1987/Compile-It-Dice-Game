using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompileItWebApi
{
    public class RollStatus : CompileIt.Status
    {
        public List<string> DieSides { get; set; } = new List<string>();
    }
}
