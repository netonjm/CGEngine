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

    public class CGEScreenObject : ICGEScreenObject
    {
        private string FILE = "";
        private List<char[,]> _frames;
        private int _actualFrame = 0;
        private TypeDirection _direction = TypeDirection.Left;

        public bool HasMovement { get; set; }

        private int _positionH;
        private int _positionV;

        private int _distanceWidth;
        private int _distanceHeight;

        public int X { get { return _positionH; } set { _positionH = value; } }
        public int Y { get { return _positionV; } set { _positionV = value; } }

        public int Width
        {
            get { return _frames[_actualFrame].GetLength(1); }
        }

        public int Height
        {
            get { return _frames[_actualFrame].GetLength(0); }
        }

        public void SetFile(string file)
        {
            FILE = Path.Combine(GlovalVars.ScreenObjectDirectory, file);
        }

        private void ChangeRandomDirection()
        {
            _direction = CGERandom.GetRandomDirection();
        }

        public CGEScreenObject(ICGEScreen screen)
        {
            InitializeData();

            SetPosition(screen.Width - Width, screen.Height / 2);

            SetContainerDimensions(screen.Width, screen.Height);
        }

        public CGEScreenObject(ICGEScreen screen, string file)
        {
            SetFile(file);
            InitializeData();
            SetContainerDimensions(screen.Width, screen.Height);
            SetRandomPosition();
        }

        public void SetContainerDimensions(int distanceWidth, int distanceHeight)
        {
            _distanceWidth = distanceWidth;
            _distanceHeight = distanceHeight;
        }

        public void SetRandomPosition()
        {
            _positionV = CGERandom.GetRandomPosition(_distanceHeight - Height);
            _positionH = CGERandom.GetRandomPosition(_distanceWidth - Width);
        }

        public void SetPosition(int x, int y)
        {
            _positionH = x;
            _positionV = y;
        }

        private void InitializeData()
        {
            string[] lines = CGEUtilsHelper.GetLinesFromFile(FILE);

            InitializeArrayProperties(lines);
        }

        private void InitializeArrayProperties(string[] lines)
        {
            int countAnimationLine = 0;

            int actualFrame = 0;
            _frames = new List<char[,]>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (countAnimationLine == 0)
                {
                    int lineas = CGEUtilsHelper.GetLinesNumber(lines, i);
                    _frames.Add(new char[lineas, lines[i].Length]);
                }

                if (lines[i] == String.Empty)
                {
                    countAnimationLine = 0; // Contador i que se reinicia
                    actualFrame++; // Cambiamos de frame
                }
                else
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        _frames[actualFrame][countAnimationLine, j] = lines[i][j];
                    }

                    countAnimationLine++;
                }
            }
        }

        public void UpdatePosition()
        {

            if (!HasMovement)
                return;

            switch (_direction)
            {
                case TypeDirection.Left:
                    if (_positionH > 1)
                        _positionH--;
                    else
                        ChangeRandomDirection();

                    break;
                case TypeDirection.Right:

                    if (_positionH < (_distanceWidth - Width))
                        _positionH++;
                    else
                        ChangeRandomDirection();

                    break;
                case TypeDirection.Down:

                    if (_positionV < _distanceHeight - Height)
                        _positionV++;
                    else
                        ChangeRandomDirection();

                    break;
                case TypeDirection.Up:
                    if (_positionV > 0)
                        _positionV--;
                    else
                        ChangeRandomDirection();

                    break;
                case TypeDirection.UpRight:
                    if (_positionV > 0 && _positionH < (_distanceWidth - Width))
                    {
                        _positionV--;
                        _positionH++;

                    }
                    else
                        ChangeRandomDirection();
                    break;
                case TypeDirection.UpLeft:
                    if (_positionV > 0 && _positionH > 0)
                    {
                        _positionH--;
                        _positionV--;
                    }
                    else
                        ChangeRandomDirection();
                    break;
                case TypeDirection.DownRight:
                    if (_positionV < (_distanceHeight - Height) && _positionH < (_distanceWidth - Width))
                    {
                        _positionH++;
                        _positionV++;
                    }
                    else
                        ChangeRandomDirection();
                    break;
                case TypeDirection.DownLeft:
                    if (_positionV < (_distanceHeight - Height) && _positionH > 0)
                    {
                        _positionH--;
                        _positionV++;
                    }
                    else
                        ChangeRandomDirection();
                    break;
            }
        }

        void SetNextFrame()
        {
            if (_actualFrame < _frames.Count - 1)
                _actualFrame++;
            else
                _actualFrame = 0;
        }

        public void Draw(char[,] espacio)
        {
            SetNextFrame();

            for (int i = 0; i < _frames[_actualFrame].GetLength(0); i++)
            {
                for (int j = 0; j < _frames[_actualFrame].GetLength(1); j++)
                {
                    if (_frames[_actualFrame][i, j] != '#')
                        espacio[_positionV + i, _positionH + j] = _frames[_actualFrame][i, j];
                }
            }
        }


    }

}
