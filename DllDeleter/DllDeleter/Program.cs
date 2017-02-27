using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DllDeleter
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = GetFolder();
            var files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
            string[] patternsTodelete = new[] { @"\w+.dll\d+", @"\w+.dll(_|\.)\d+" };
            foreach (var file in files)
            {  
                var fn = Path.GetFileName(file);
                foreach (var p in patternsTodelete)
                {
                    if (Regex.IsMatch(fn, p, RegexOptions.IgnoreCase))
                    {
                        File.Delete(file);
                    }

                }
                
            }

        }

        private static string GetFolder()
        {
            var p = "FOCUS_HOME_FOLDER";
            var path = Environment.GetEnvironmentVariable(p);
            return path;
        }
    }
}
