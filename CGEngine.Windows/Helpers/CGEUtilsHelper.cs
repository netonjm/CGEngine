using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CGEngine.Helpers
{
    class CGEUtilsHelper
    {

        public static string[] GetLinesFromFile(string file)
        {
            var finfo = new FileInfo(GlovalVars.AppDirectory);
            finfo = new FileInfo(Path.Combine(finfo.Directory.FullName, file));
            return finfo.Exists ? File.ReadAllLines(finfo.FullName) : null;
        }

        public static int GetLinesNumber(string[] lines, int fromLine)
        {
            if (fromLine >= lines.Length || fromLine < 0)
                return -1;

            int contador = 0;
            for (int i = fromLine; i < lines.Length; i++)
            {
                if (lines[i] == String.Empty)
                    return contador;

                contador++;
            }

            return contador;
        }


    }
}
