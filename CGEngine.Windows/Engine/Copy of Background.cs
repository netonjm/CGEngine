using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Background2
    {

        public static string FILE = "Backgrounds.txt";

        private Muercielago _murcielago;

        private List<char[,]> _backgrounds;
        private char[,] _espacio;

        private int _actualBackground;
       
        public Background2()
        {
            InitializeData();
            SetBackground(0);
        }

        void SetBackground(int id)
        {
            if (id >= 0 && id < _backgrounds.Count())
            {
                _actualBackground = id;
                _espacio = new char[_backgrounds[id].GetLength(0), _backgrounds[id].GetLength(1)];
            }
         
        }

        private void InitializeData()
        {
            string[] lines = UtilsHelper.GetLinesFromFile(FILE);

            InitializeArrayProperties(lines);
        }

        public void InitializeArrayProperties(string[] lines)
        {
            int contadorLineaAnimacionActual = 0;

            int actualFrame = 0;
            _backgrounds = new List<char[,]>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (contadorLineaAnimacionActual == 0)
                {
                    int lineas = UtilsHelper.GetLinesNumber(lines, i);
                    _backgrounds.Add(new char[lineas, lines[i].Length]);
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
                        _backgrounds[actualFrame][contadorLineaAnimacionActual, j] = lines[i][j];
                        //actualj++;
                    }

                    contadorLineaAnimacionActual++;
                }
            }
        }

        public int GetWidth()
        {
           return _espacio.GetLength(1);
        }

        public int GetHeight()
        {
          return  _espacio.GetLength(0);
        }

        public void Draw()
        {
            SetBackground(); //Cargamos el fondo

            if (_murcielago != null)
            {
                _murcielago.Draw(_espacio); //Pintamos al murcielago encima
                _murcielago.UpdateMurcielagoPosition(); //Actualizamos la posicion del murcielgo
            }
            DrawSecuence(); //Pintamos la secuencia
        }
       
        private void SetBackground()
        {
            for (int i = 0; i < GetHeight(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    _espacio[i, j] = _backgrounds[_actualBackground][i,j];
                }
            }
        }

        public void DrawSecuence()
        {
            for (int i = 0; i < _espacio.GetLength(0); i++)
            {
                for (int j = 0; j < _espacio.GetLength(1); j++)
                    Console.Write(_espacio[i, j]);
               // Console.WriteLine();
            }
        }

        public void Add(Muercielago murcielago)
        {
            _murcielago = murcielago;
        }

    }
}
