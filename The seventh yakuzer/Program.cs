using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class Program
    {

        enum GameModes
        {
            MAP = 0,
            FIGHT = 1,
            DIALOG = 2,
            MENU = 3
        }

        static void Main(string[] args)
        {
            GameModes gMode = GameModes.MAP;

            bool game = true;
            int currentMapX = 0;
            int currentMapY = 0;

            Console.SetWindowPosition(0, 0);

            GameScreen gs = new GameScreen();

            gs.SetMenuTab();
            gs.SetSpritesTab();
            gs.SetMaps();
            gs.SetMapTab(currentMapX, currentMapY);
            gs.InitKiryu(100, 20);

            while (game)
            {

                while (gMode == GameModes.MAP)
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
                            gMode = GameModes.MENU;
                            break;

                        case ConsoleKey.D2:
                            gMode = GameModes.MENU;
                            break;

                        case ConsoleKey.D3:
                            gMode = GameModes.MENU;
                            break;

                        case ConsoleKey.D4:
                            gMode = GameModes.MENU;
                            break;

                        case ConsoleKey.D5:
                            gMode = GameModes.MENU;
                            break;

                        case ConsoleKey.D7:
                            gMode = GameModes.FIGHT;
                            gs.SetFightUI();
                            break;

                        case ConsoleKey.D8:
                            gMode = GameModes.DIALOG;
                            break;

                        case ConsoleKey.D9:
                            gMode = GameModes.MAP;
                            gs.SetMapTab(currentMapX, currentMapY);
                            break;
                    }
                }

                while (gMode == GameModes.FIGHT)
                {
                    switch (Console.ReadKey(true).Key)
                    {

                        case ConsoleKey.Enter:
                            break;

                        case ConsoleKey.UpArrow:
                            break;

                        case ConsoleKey.W:
                            break;

                        case ConsoleKey.DownArrow:
                            break;

                        case ConsoleKey.S:
                            break;

                        case ConsoleKey.LeftArrow:
                            break;

                        case ConsoleKey.A:
                            break;

                        case ConsoleKey.RightArrow:
                            break;

                        case ConsoleKey.D:
                            break;

                        case ConsoleKey.D1:
                            gMode = GameModes.MENU;
                            break;

                        case ConsoleKey.D2:
                            gMode = GameModes.MENU;
                            break;

                        case ConsoleKey.D3:
                            gMode = GameModes.MENU;
                            break;

                        case ConsoleKey.D4:
                            gMode = GameModes.MENU;
                            break;

                        case ConsoleKey.D5:
                            gMode = GameModes.MENU;
                            break;

                        case ConsoleKey.D7:
                            gMode = GameModes.FIGHT;
                            gs.SetFightUI();
                            break;

                        case ConsoleKey.D8:
                            gMode = GameModes.DIALOG;
                            break;

                        case ConsoleKey.D9:
                            gMode = GameModes.MAP;
                            Console.Clear();
                            gs.SetMenuTab();
                            gs.SetSpritesTab();
                            gs.SetMapTab(currentMapX, currentMapY);
                            gs.InitKiryu(gs._kiryuPosX, gs._kiryuPosY);
                            break;
                    }
                }

                while (gMode == GameModes.DIALOG)
                {

                }

                while (gMode == GameModes.MENU)
                {

                }
            }
        }
    }
}
