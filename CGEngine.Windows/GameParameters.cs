using CGEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGEngine.Models
{

    class GameParameters
    {

        public int DEFAULT_FRAME_DELAY = 250;

        public int FrameDelay;
        public int Frame;

        public int NumObjects;
        public bool HasMovement;

        public ScreenObjectType ObjectType;
        public ICGEScreen Background;

        public GameParameters()
        {
            FrameDelay = DEFAULT_FRAME_DELAY;
            Frame = 0;
        }

    }
}
