using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGEngine.Interfaces;

namespace CGEngine.Screen
{
    public class CGEScreenObjectBat : CGEScreenObject, ICGEScreenObject
    {

        public CGEScreenObjectBat(ICGEScreen screen)
            : base(screen, "bat.txt")
        {
        }


    }
}
