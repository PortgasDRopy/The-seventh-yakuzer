using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static The_seventh_yakuzer.GameData;

namespace The_seventh_yakuzer
{
    internal class Program
    {

        public enum GameModes
        {
            MAP = 0,
            FIGHT = 1,
            DIALOG = 2,
            MENU = 3
        }

        static public GameScreen gs = new GameScreen();
        static GameModes gMode = GameModes.MAP;

        static void Main(string[] args)
        {
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;

            GameScreen gs = new GameScreen();
            GameState gameState = new GameState();
          
            bool mainMenu = true;
            bool game = true;
            string dir;

            gs.SetMainMenu();

            while (game)
            {

                while (mainMenu)
                {

                    switch (Console.ReadKey(true).Key)
                    {

                        case ConsoleKey.Enter:
                            gs.SelectHoverMM(ConsoleColor.DarkBlue);
                            gs.SelectOptionMM();
                            break;

                        case ConsoleKey.Escape:
                            if (gs._curSMenu != null)
                            {
                                gs._cursorPosY = gs._prevCurY;
                                gs._curSMenu = null;
                                gs.SetMainMenu();
                                gs.SelectHoverMM(ConsoleColor.Blue);
                            }
                            break;

                        case ConsoleKey.UpArrow:
                            dir = "u";
                            gs.MoveCursorMM(dir);
                            break;

                        case ConsoleKey.W:
                            dir = "u";
                            gs.MoveCursorMM(dir);
                            break;

                        case ConsoleKey.DownArrow:
                            dir = "d";
                            gs.MoveCursorMM(dir);
                            break;

                        case ConsoleKey.S:
                            dir = "d";
                            gs.MoveCursorMM(dir);
                            break;
                    }

                    if (gs._initSave != 0)
                    {
                        List<Character> gsParty = new List<Character>() { GameData.Kiryu };
                        Dictionary<string, List<Item>> gsInventory = new Dictionary<string, List<Item>>();
                        DateTime dateTime = DateTime.Now;
                        List<int> currentMap = new List<int>() { 0, 0, 73, 50 };

                        if (gs._initSave == 1)
                        {
                            gameState.Init(gsParty, gsInventory, 0, dateTime, 10000, currentMap);
                        }

                        if (gs._initSave == 2)
                        {
                            gameState.Init(gsParty, gsInventory, 1, dateTime, 5000, currentMap);
                        }

                        if (gs._initSave == 3)
                        {
                            gameState.Init(gsParty, gsInventory, 2, dateTime, 1000, currentMap);
                        }

                        if (gs._initSave == 4)
                        {
                            gameState.Init(gsParty, gsInventory, 3, dateTime, 500, currentMap);
                        }

                        break;
                    }
                }

                List<Character> Party = gameState.Party;
                Dictionary<string, List<Item>> inventory = gameState.Inventory;
                GameData.SetWeaponList();
              
                Fight fight = new Fight(Party, Party);

                GameModes gMode = GameModes.MAP;

                int currentMapX = gameState.CurrentMap[0];
                int currentMapY = gameState.CurrentMap[1];

                Console.Clear();

                gs.SetMenuTab();
                gs.SetSpritesTab(Party);
                gs.SetMaps();
                gs.SetMapTab(currentMapX, currentMapY);
                gs.InitKiryu(gameState.CurrentMap[2], gameState.CurrentMap[3]);

            

                while (gMode == GameModes.MAP)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            break;

                        case ConsoleKey.UpArrow:
                            gs.MoveCharacter("Up");
                            if (fight.IsEnnemy(gs))
                            {
                                gs.SetFightUI(fight);
                                gMode = GameModes.FIGHT;
                            }
                            break;

                        case ConsoleKey.W:
                            gs.MoveCharacter("Up");
                            if (fight.IsEnnemy(gs))
                            {
                                gs.SetFightUI(fight);
                                gMode = GameModes.FIGHT;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            gs.MoveCharacter("Down");
                            if (fight.IsEnnemy(gs))
                            {
                                gs.SetFightUI(fight);
                                gMode = GameModes.FIGHT;
                            }
                            break;

                        case ConsoleKey.S:
                            gs.MoveCharacter("Down");
                            if (fight.IsEnnemy(gs))
                            {
                                gs.SetFightUI(fight);
                                gMode = GameModes.FIGHT;
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            gs.MoveCharacter("Left");
                            if (fight.IsEnnemy(gs))
                            {
                                gs.SetFightUI(fight);
                                gMode = GameModes.FIGHT;
                            }
                            break;

                        case ConsoleKey.A:
                            gs.MoveCharacter("Left");
                            if (fight.IsEnnemy(gs))
                            {
                                gs.SetFightUI(fight);
                                gMode = GameModes.FIGHT;
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            gs.MoveCharacter("Right");
                            if (fight.IsEnnemy(gs))
                            {
                                gs.SetFightUI(fight);
                                gMode = GameModes.FIGHT;
                            }
                            break;

                        case ConsoleKey.D:
                            gs.MoveCharacter("Right");
                            if (fight.IsEnnemy(gs))
                            {
                                gs.SetFightUI(fight);
                                gMode = GameModes.FIGHT;
                            }
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
                            gs.SetFightUI(fight);
                            gs._cursorPosX = 0;
                            gs._cursorPosY = 0;
                            gs._selectMode = 0;
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
                            gs.SelectHover(ConsoleColor.DarkBlue, Party);
                            gs.SelectOption(fight);
                            break;

                        case ConsoleKey.Escape:
                            gs._cursorPosX = gs._prevCurX;
                            gs._cursorPosY = gs._prevCurY;
                            gs._selectMode = 0;
                            gs.SelectHover(ConsoleColor.Blue, Party);
                            gs.SetFightUI(fight);
                            break;

                        case ConsoleKey.UpArrow:
                            dir = "u";
                            gs.MoveCursor(dir, Party);
                            break;

                        case ConsoleKey.W:
                            dir = "u";
                            gs.MoveCursor(dir, Party);
                            break;

                        case ConsoleKey.DownArrow:
                            dir = "d";
                            gs.MoveCursor(dir, Party);
                            break;

                        case ConsoleKey.S:
                            dir = "d";
                            gs.MoveCursor(dir, Party);
                            break;

                        case ConsoleKey.LeftArrow:
                            dir = "l";
                            gs.MoveCursor(dir, Party);
                            break;

                        case ConsoleKey.A:
                            dir = "l";
                            gs.MoveCursor(dir, Party);
                            break;

                        case ConsoleKey.RightArrow:
                            dir = "r";
                            gs.MoveCursor(dir, Party);
                            break;

                        case ConsoleKey.D:
                            dir = "r";
                            gs.MoveCursor(dir, Party);
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
                            Console.Clear();
                            gs.SetFightUI(fight);
                            break;

                        case ConsoleKey.D8:
                            //gMode = GameModes.DIALOG;
                            break;

                        case ConsoleKey.D9:
                            gMode = GameModes.MAP;
                            Console.Clear();
                            gs.SetMenuTab();
                            gs.SetSpritesTab(Party);
                            gs.SetMapTab(currentMapX, currentMapY);
                            gs.InitKiryu(gs._kiryuPosX - 1, gs._kiryuPosY);
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

        static public void changeMode(GameModes Mode, Fight fight)
        {
            if (Mode == GameModes.FIGHT)
            {
                gMode = GameModes.FIGHT;
                Console.Clear();
                gs.SetFightUI(fight);
            }
            else if (Mode == GameModes.MAP)
            {
                gMode = GameModes.MAP;
                Console.Clear();
                gs.SetMenuTab();
                gs.SetSpritesTab();
                gs.SetMapTab(0, 0);
                gs.InitKiryu(gs._kiryuPosX - 1, gs._kiryuPosY);
            }
        }
    }
}
