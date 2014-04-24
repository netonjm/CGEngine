using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGEngine.Helpers
{
    class CGERandom
    {

        private static Random _rnd;
        public static Random Rnd
        {
            get
            {

                if (_rnd == null)
                    _rnd = new Random(DateTime.Now.Millisecond);

                return _rnd;
            }

        }
        public static int GetRandomPosition(int maxPosition)
        {
            return CGERandom.Next(0, maxPosition);
        }

        public static TypeDirection GetRandomDirection()
        {
            return (TypeDirection)CGERandom.Next(0, 7);
        }
        public static int Next(int minValue, int maxValue)
        {
            return Rnd.Next(minValue, maxValue);
        }
    }
}
