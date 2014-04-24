using CGEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGEngine.Screen
{
    public class CGEScreenObjectTree : CGEScreenObject
    {
        public CGEScreenObjectTree(ICGEScreen screen)
            : base(screen, "tree.txt")
        {
        }


    }
}
