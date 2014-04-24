using CGEngine.Interfaces;
using CGEngine.Models;
using CGEngine.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CGEngine
{
    class Game
    {

        CGESequence _sequence;
        GameParameters Params;

        public Game()
        {
            InitializeInputParameters();

            InitializeScene();

            Run();
        }

        public void InitializeInputParameters()
        {
            Params = new GameParameters();

            Console.WriteLine("Scenary to draw [0:Empty, 1:Caves]?");
            Params.Background = (Console.ReadKey().KeyChar.ToString().Equals("0") ? (ICGEScreen)new CGEScreenEmpty() : new CGEScreenCave());
            Console.WriteLine();

            Console.WriteLine("Object to draw [0:bat, 1:tree]?");
            Params.ObjectType = (Console.ReadKey().KeyChar.ToString().Equals("0")) ? ScreenObjectType.Bat : ScreenObjectType.Tree;
            Console.WriteLine();

            Console.WriteLine("How many?");
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
                Params.NumObjects = number;
            else
                Params.NumObjects = 1;

            Console.WriteLine();

            Console.WriteLine("Movement?");
            Params.HasMovement = Console.ReadKey().KeyChar.ToString().Equals("0") ? false : true;
            Console.WriteLine();
        }

        public void InitializeScene()
        {
            //Scene creation
            _sequence = new CGESequence();
            _sequence.AddFrameBackground(Params.Background);
            _sequence.SetBackgroundSelected(0);

            //Initial creation objects
            _sequence.AddScreenObjects(Params.ObjectType, Params.NumObjects, Params.HasMovement);
        }

        private void Run()
        {

            while (true)
            {
                //Clear screen
                Console.Clear();

                //Draw the frame sequence
                _sequence.Draw();

                Thread.Sleep(Params.FrameDelay);

                Params.Frame++;
            }
        }

    }
}
