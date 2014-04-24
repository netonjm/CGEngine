using CGEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGEngine.Screen
{
    public class CGEScreenCave : CGEScreen, ICGEScreen
    {

        public CGEScreenCave()
            : base("cave.txt")
        {

        }

    }
}
