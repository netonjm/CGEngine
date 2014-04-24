using CGEngine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CGEngine.Helpers
{

    class DrawingPrimitivesHelper
    {

        public static void Square(int width, int height, int max)
        {
            Square(0, width, height, max);
        }

        public static void Square(int offset, int width, int height, int max)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < offset; j++)
                    Console.Write(ReturnAleatoryChar());

                for (int j = 0; j < width; j++)
                {
                    Console.Write("*");
                }

                for (int j = offset + width; j < max + offset; j++)
                {
                    Console.Write(ReturnAleatoryChar());
                }

                Console.WriteLine();
            }
        }

        public static void Triangle(int offset, int width, int height, TriangleType recType)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < offset; j++)
                    Console.Write(ReturnAleatoryChar());


                switch (recType)
                {
                    case TriangleType.RectangleLeft:

                        for (int j = 0; j < i; j++)
                            Console.Write("*");
                        for (int j = 0; j <= width - i; j++)
                            Console.Write(ReturnAleatoryChar());

                        break;
                    case TriangleType.RectangleRight:

                        for (int j = 0; j < width - i - 1; j++)
                            Console.Write(ReturnAleatoryChar());
                        for (int j = 0; j < i; j++)
                            Console.Write("*");

                        break;
                    case TriangleType.Rectangle:

                        for (int j = 0; j < width - i - 1; j++)
                            Console.Write(ReturnAleatoryChar());
                        for (int j = 0; j < i; j++)
                            Console.Write("*");

                        for (int j = 0; j < i; j++)
                            Console.Write("*");
                        for (int j = 0; j < width - i - 1; j++)
                            Console.Write(ReturnAleatoryChar());

                        break;

                }

                Console.WriteLine();

            }
        }


        public static char[] _character = { '*', ' ', ' ', ' ', ' ', ' ', ' ' };

        public static char ReturnAleatoryChar()
        {
            return _character[CGERandom.Next(0, 6)];
        }

        public static void Tree(int offset)
        {
            int triangle_width = 20;
            int triangle_height = 20;

            int trunk_width = 5;
            int trunk_height = 10;

            Triangle(offset, triangle_width, triangle_height, TriangleType.Rectangle);
            Square(offset + ((((triangle_width - 1) * 2) - trunk_width) / 2), trunk_width, trunk_height, triangle_width);

        }


    }
}
