using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CompileItCLI
{
    public class Utility
    {
        public static void PlaySound(string fileName)
        {
            string path = $@"{Environment.CurrentDirectory}\..\..\..\..\sounds\{fileName}";

            Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '{path}').PlaySync();");
        }
    }
}
