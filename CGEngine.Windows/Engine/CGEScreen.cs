using CGEngine.Helpers;
using CGEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGEngine
{
    public class CGEScreen : ICGEScreen
    {

        public static string FILE = "";

        private List<char[,]> _frameBackgrounds;

        private int _actualBackground;

        public char[,] ActualFrameBackground
        {
            get { return _frameBackgrounds[_actualBackground]; }
        }

        public CGEScreen()
        {
            InitializeData();
            SetBackground(0);
        }

        public CGEScreen(string file)
        {
            SetFile(file);
            InitializeData();
            SetBackground(0);
        }

        private void SetFile(string file)
        {
            FILE = Path.Combine(GlovalVars.BackgroundDirectory, file);
        }

        private void InitializeData()
        {
            string[] lines = CGEUtilsHelper.GetLinesFromFile(FILE);

            InitializeArrayProperties(lines);
        }

        public void InitializeArrayProperties(string[] lines)
        {
            int contadorLineaAnimacionActual = 0;

            int actualFrame = 0;
            _frameBackgrounds = new List<char[,]>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (contadorLineaAnimacionActual == 0)
                {
                    int lineas = CGEUtilsHelper.GetLinesNumber(lines, i);
                    _frameBackgrounds.Add(new char[lineas, lines[i].Length]);
                }

                if (lines[i] == String.Empty)
                {
                    contadorLineaAnimacionActual = 0; // Contador i que se reinicia
                    actualFrame++; // Cambiamos de frame
                    //actuali = 0;
                    //actualj = 0;
                }
                else
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        _frameBackgrounds[actualFrame][contadorLineaAnimacionActual, j] = lines[i][j];
                        //actualj++;
                    }

                    contadorLineaAnimacionActual++;
                }
            }
        }

        public void SetBackground(int id)
        {
            if (id >= 0 && id < _frameBackgrounds.Count())
            {
                _actualBackground = id;
            }

        }

        public int Width
        {
            get { return _frameBackgrounds[_actualBackground].GetLength(1); }
        }

        public int Height
        {
            get { return _frameBackgrounds[_actualBackground].GetLength(0); }
        }

    }
}
