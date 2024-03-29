﻿using System;
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
            var libs = new Dictionary<string,string>()
            {
                { "libxml-2.0", "-llibxml2 -lz" },
                { "x265", "-lx265" },
                { "dav1d", "-llibdav1d" },
                { "openssl", "-lssl" },
            };

            if (args.Length == 1 && args[0] == "--version")
            {
                Console.WriteLine("1.0");
                result = 0;
            }
            else if (args.Length > 1 && args[0] == "--exists")
            {
                var lib = GetLibName(args);
                if (libs.ContainsKey(lib))
                {
                    Console.WriteLine($"{lib} is installed.");
                    result = 0;
                }
            }
            else if (args.Length > 1 && args[0] == "--libs")
            {
                var lib = GetLibName(args);
                if (libs.TryGetValue(lib, out string parameters))
                {
                    Console.WriteLine(parameters);
                    result = 0;
                }
            }
            return result;
        }

        static string GetLibName(string[] args)
        {
            foreach (var arg in args)
            {
                if (!arg.StartsWith("--"))
                {
                    return arg;
                }
            }
            return "";
        }
    }
}
