using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompileIt
{
    public class Status
    {
        public bool IsSuccessful { get; set; } = true;
        public string Message { get; set; } = "";
        public TurnStatus TurnStatus { get; set; }
        public GameStatus GameStatus { get; set; } = new GameStatus();

        public Status()
        {

        }

        public Status(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
