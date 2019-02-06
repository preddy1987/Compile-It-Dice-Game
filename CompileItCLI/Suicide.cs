using System;
using System.Collections.Generic;
using System.Text;

namespace CompileItCLI
{
    public class Suicide
    {
        public void SuicideScreen()
        {
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
            Console.ReadKey();
        }
    }
}
