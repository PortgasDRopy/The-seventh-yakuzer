using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class Program
    {

        static void Main(string[] args)
        {


            bool game = true;
            Console.SetWindowPosition(0, 0);

            GameScreen gs = new GameScreen();

            gs.SetMenuTab();
            gs.SetSpritesTab();
            gs.SetMaps();
            gs.SetMapTab(0, 0);
            gs.InitKiryu(70, 20);

            while (game)
            {

                switch (Console.ReadKey(true).Key)
                { 

                    case ConsoleKey.Enter:
                        break;

                    case ConsoleKey.UpArrow:
                        gs.MoveCharacter("Up");
                        break;

                    case ConsoleKey.W:
                        gs.MoveCharacter("Up");
                        break;

                    case ConsoleKey.DownArrow:
                        gs.MoveCharacter("Down");
                        break;

                    case ConsoleKey.S:
                        gs.MoveCharacter("Down");
                        break;

                    case ConsoleKey.LeftArrow:
                        gs.MoveCharacter("Left");
                        break;

                    case ConsoleKey.A:
                        gs.MoveCharacter("Left");
                        break;

                    case ConsoleKey.RightArrow:
                        gs.MoveCharacter("Right");
                        break;

                    case ConsoleKey.D:
                        gs.MoveCharacter("Right");
                        break;

                    case ConsoleKey.D1:
                        break;

                    case ConsoleKey.D2:
                        break;

                    case ConsoleKey.D3:
                        break;

                    case ConsoleKey.D4:
                        break;

                    case ConsoleKey.D5:
                        break;

                }


            }
        }
    }
}
