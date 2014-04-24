using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CGEngine
{
    public enum TriangleType
    {
        RectangleLeft = 0,
        RectangleRight = 1,
        Rectangle = 2
    }

    public enum TypeDirection
    {
        Left = 0,
        Right = 1,
        Down = 2,
        Up = 3,
        UpLeft = 4,
        UpRight = 5,
        DownLeft = 6,
        DownRight = 7,
    }

    class GlovalVars
    {
        static string CONTENT_DIRECTORY = "Content";
        static string BACKGROUNDS_DIRECTORY = "Backgrounds";
        static string OBJECTS_DIRECTORY = "ScreenObject";

        public static string BackgroundDirectory = Path.Combine(CONTENT_DIRECTORY, BACKGROUNDS_DIRECTORY);
        public static string ScreenObjectDirectory = Path.Combine(CONTENT_DIRECTORY, OBJECTS_DIRECTORY);

        public static string AppDirectory = Assembly.GetExecutingAssembly().Location;
    }

}
