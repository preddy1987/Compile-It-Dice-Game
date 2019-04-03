using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompileItWebApi
{
    public class Players : CompileIt.Status
    {
        public List<Player> GamePlayers { get; set; }
    }
}
