using CGEngine.Interfaces;
using CGEngine.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGEngine
{
    class CGESequence
    {

        private List<ICGEScreenObject> _objets;
        private List<ICGEScreen> _backgrounds;
        private char[,] _space;
        private int _selected;

        public ICGEScreen SelectedBackground { get { return _backgrounds[_selected]; } }

        public int GetWidth()
        {
            return _space.GetLength(1);
        }

        public int GetHeight()
        {
            return _space.GetLength(0);
        }

        private void FillBackground()
        {
            for (int i = 0; i < GetHeight(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    _space[i, j] = SelectedBackground.ActualFrameBackground[i, j];
                }
            }
        }

        public CGESequence()
        {
            //Creamos un background y un objeto
            InitializeData();

        }

        private void InitializeData()
        {
            _objets = new List<ICGEScreenObject>();
            _backgrounds = new List<ICGEScreen>();
        }

        public void SetBackgroundSelected(int id)
        {
            if (id >= 0 && id < _backgrounds.Count())
            {
                _selected = id;
                _space = new char[SelectedBackground.ActualFrameBackground.GetLength(0), SelectedBackground.ActualFrameBackground.GetLength(1)];
            }
        }

        public void AddScreenObject(ICGEScreenObject murcielago)
        {
            _objets.Add(murcielago);
        }

        public void AddFrameBackground(ICGEScreen fondo)
        {
            _backgrounds.Add(fondo);
        }

        public void Draw()
        {
            FillBackground(); //Cargamos el fondo en nuestro array de pintado

            if (_objets != null && _objets.Count > 0)
            {

                foreach (var _murcielago in _objets.OrderBy(item => item.Y))
                {
                    _murcielago.Draw(_space); //Pintamos al murcielago encima
                    _murcielago.UpdatePosition(); //Actualizamos la posicion del murcielgo
                }

            }

            DrawSecuence(); //Pintamos la secuencia
        }

        public void DrawSecuence()
        {
            for (int i = 0; i < _space.GetLength(0); i++)
            {
                for (int j = 0; j < _space.GetLength(1); j++)
                    Console.Write(_space[i, j]);
            }
        }

        internal void AddScreenObjects(ScreenObjectType type, int numObjects, bool hasMovement)
        {
            ICGEScreenObject tmp;

            for (int i = 1; i <= numObjects; i++)
            {

                switch (type)
                {
                    case ScreenObjectType.Bat:
                        tmp = new CGEScreenObjectBat(SelectedBackground);
                        break;
                    default:
                        tmp = new CGEScreenObjectTree(SelectedBackground);
                        break;
                }

                if (tmp != null)
                {
                    tmp.HasMovement = hasMovement;
                    AddScreenObject(tmp);
                }

            }
        }
    }
}
