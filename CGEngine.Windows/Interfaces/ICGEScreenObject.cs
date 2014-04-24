using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CGEngine.Interfaces
{

    public enum ScreenObjectType
    {
        Bat = 1, Tree = 2
    }

    interface ICGEScreenObject
    {
        void Draw(char[,] espacio);
        void UpdatePosition();

        bool HasMovement { get; set; }

        int Y { get; set; }
    }
}
