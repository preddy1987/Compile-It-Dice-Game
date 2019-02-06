using System;
using System.Collections.Generic;
using System.Text;

namespace CompileItCLI
{
    public class Suicide
    {
        public void SuicideScreen()
        {
            var rando = new Random();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"                                                   
               ...                                 |
             ;::::;                                |
           ;::::; :;                               |
         ;:::::'   :;                              |
        ;:::::;     ;.                             |
       ,:::::'       ;           OOO\              |
       ::::::;       ;          OOOOO\             |
       ;:::::;       ;         OOOOOOOO            |
      ,;::::::;     ;'         / OOOOOOO           |
    ;:::::::::`. ,,,;.        /  / DOOOOOO         |
  .';:::::::::::::::::;,     /  /     DOOOO        |
 ,::::::;::::::;;;;::::;,   /  /        DOOO       |
;`::::::`'::::::;;;::::: ,#/  /          DOOO      |
:`:::::::`;::::::;;::: ;::#  /            DOOO     |
::`:::::::`;:::::::: ;::::# /              DOO     |
`:`:::::::`;:::::: ;::::::#/               DOO     |
 :::`:::::::`;; ;:::::::::##                OO     |
 ::::`:::::::`;::::::::;:::#                OO     |
 `:::::`::::::::::::;'`:;::#                O      |
  `:::::`::::::::;' /  / `:#                       |
   ::::::`:::::;'  /  /   `#                       |");

            Console.ResetColor();
            switch (rando.Next(1, 8))
            {
                case 1:
                    Console.WriteLine("Don't do drugs kids!");
                    break;
                case 2:
                    Console.WriteLine("Stay in School!");
                    break;
                case 3:
                    Console.WriteLine("You took the easy way out...");
                    break;
                case 4:
                    Console.WriteLine("You quit ASSHOLE!!!");
                    break;
                case 5:
                    Console.WriteLine("GAME OVER");
                    break;
                case 6:
                    Console.WriteLine("You died of DYSENTERY!");
                    break;
                case 7:
                    Console.WriteLine("Who let the dogs out?");
                    break;
                case 8:
                    Console.WriteLine("Has anyone really been far even as decided to use even go want to do look more like?");
                    break;
            }
            Console.ReadKey();
        }
    }
}
