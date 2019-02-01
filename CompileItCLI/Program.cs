using System;
using System.Collections.Generic;
using CompileIt;

namespace CompileItCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            CompileItGame game = new CompileItGame();
            CompileItCLI cli = new CompileItCLI(game);
            cli.MainMenu();
        }
    }
}
