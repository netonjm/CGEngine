using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGEngine.Interfaces
{
    public interface ICGEScreen
    {
        void SetBackground(int id);

        int Width { get; }

        int Height { get; }

        char[,] ActualFrameBackground { get; }

    }
}
