using CGEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGEngine.Screen
{
    public class CGEScreenEmpty : CGEScreen, ICGEScreen
    {

        public CGEScreenEmpty()
            : base("empty.txt")
        {

        }

    }
}
