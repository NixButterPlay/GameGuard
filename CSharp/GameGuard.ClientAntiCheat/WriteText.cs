using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuard.ClientAntiCheat
{
    public class WriteText
    {
        public void WriteToTXT(string filename, string text)
        {
            File.WriteAllText(filename, text);
        }
    }
}
