using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkgConfigFake
{
    class Program
    {
        static int Main(string[] args)
        {
            int result = 1;
            if (args.Length == 1 && args[0] == "--version")
            {
                Console.WriteLine("1.0");
                result = 0;
            }
            else if (args.Length > 1 && args[0] == "--exists")
            {
                var lib = args.Last();
                if (lib == "libxml-2.0")
                {
                    Console.WriteLine($"{lib} is installed.");
                    result = 0;
                }
            }
            else if (args.Length > 1 && args[0] == "--libs")
            {
                var lib = args.Last();
                if (lib == "libxml-2.0")
                {
                    Console.WriteLine("-llibxml2 -lz");
                    result = 0;
                }
            }
            return result;
        }
    }
}
