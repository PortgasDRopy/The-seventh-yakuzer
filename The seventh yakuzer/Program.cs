using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
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
        static public GameState gameState = new GameState();

        static public List<Character> Party = new();
        static public List<Item> inventory = null;


        public static int currentMapX;
        public static int currentMapY;

        public static int money;

        static void Main(string[] args)
        {
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;

            bool mainMenu = true;
            bool game = true;
            string dir;

            gs.SetMainMenu();

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
                    if (gs._initSave < 5)
                    {
                        List<Character> gsParty = new List<Character>() { GameData.Kiryu, GameData.Kuze, GameData.Nishiki };
                        List<Item> gsInventory = new List<Item>();
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
                    
                    if (gs._initSave > 4)
                    {
                        gameState.Load(gs._initSave - 4);

                        break;
                    }
                }
            }

            Party.Add(GameData.Kiryu);
            Party.Add(GameData.Nishiki);
            Party.Add(GameData.Kuze);

            inventory = gameState.Inventory;
            GameData.SetWeaponList();
              
            Fight fight = new Fight(Party, Party);

            gs._cursorPosX = 0;
            gs._cursorPosY = 0;
            gs._selectMode = 0;

            money = gameState.Money;

            currentMapX = gameState.CurrentMap[0];
            currentMapY = gameState.CurrentMap[1];

            Console.Clear();

            gs.SetMenuTab();
            gs.SetSpritesTab(Party);
            gs.SetMaps();
            gs.SetMapTab(gameState.CurrentMap[0], gameState.CurrentMap[1]);
            gs.InitKiryu(gameState.CurrentMap[2], gameState.CurrentMap[3]);

            while (game)
            {

                while (gMode == GameModes.MAP)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            gs.Interact();
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
                            gs._curSMenu = "Equipements";
                            gs.SetSubmenu(gs._curSMenu, Party, inventory);
                            break;

                        case ConsoleKey.D2:
                            gMode = GameModes.MENU;
                            gs._curSMenu = "MItems";
                            gs._selectMode = 2;
                            gs._cursorPosX = 0;
                            gs._cursorPosY = 0;
                            gs.SetSubmenu(gs._curSMenu, Party, inventory);
                            gs.SelectHover(ConsoleColor.Blue, Party);
                            break;

                        case ConsoleKey.D3:
                            gMode = GameModes.MENU;
                            gs._curSMenu = "Map";
                            gs.SetSubmenu(gs._curSMenu, Party, inventory);
                            break;

                        case ConsoleKey.D4:
                            gMode = GameModes.MENU;
                            gs._curSMenu = "MParty";
                            gs._selectMode = 1;
                            gs._cursorPosX = 0;
                            gs.SetSubmenu(gs._curSMenu, Party, inventory);
                            gs.SelectHover(ConsoleColor.Blue, Party);
                            break;

                        case ConsoleKey.D5:
                            gMode = GameModes.MENU;
                            gs._curSMenu = "SLQ";
                            gs._selectMode = 1;
                            gs._cursorPosX = 0;
                            gs._cursorPosY = 0;
                            gs.SetSubmenu(gs._curSMenu, Party, inventory);
                            gs.SelectHover(ConsoleColor.Blue, Party);
                            break;

                        case ConsoleKey.D6:
                            gMode = GameModes.MENU;
                            gs._curSMenu = "Settings";
                            gs._cursorPosX = 0;
                            gs._cursorPosY = 0;
                            gs.SetSubmenu(gs._curSMenu, Party, inventory);
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
                            gs.SetDialogueUI();
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
                            gs.SelectOption(fight, gameState);
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
                            if (gs._selectMode == 2 && gs._curSMenu != "MItems" && gs._curSMenu != "Items")
                            {
                                if (Party[0].EquippedStyle.AttackList.Count > (gs._cursorPosX + (gs._cursorPosY + 1) * 2))
                                {
                                    gs.MoveCursor(dir, Party);
                                }
                            }
                            if (gs._selectMode != 2)
                            {
                                gs.MoveCursor(dir, Party);
                            }
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
                            gs.InitKiryu(GameScreen._kiryuPosX - 1, GameScreen._kiryuPosY);
                            break;
                    }


                }

                while (gMode == GameModes.DIALOG)
                {

                }

                while (gMode == GameModes.MENU)
                {
                    switch (Console.ReadKey(true).Key)
                    {

                        case ConsoleKey.Enter:
                            gs.SelectHover(ConsoleColor.DarkBlue, Party);
                            gs.SelectOption(fight, gameState);
                            break;

                        case ConsoleKey.Escape:
                            gs._cursorPosX = gs._prevCurX;
                            gs._cursorPosY = gs._prevCurY;
                            gs._selectMode = 0;

                            if (gs._curSMenu == "MParty" || gs._curSMenu == "MItems" || gs._curSMenu == "SLQ" || gs._curSMenu == "SLQSave" || gs._curSMenu == "SLQLoad")
                            {
                                gMode = GameModes.MAP;
                                gs._curSMenu = null;
                                gs.SetMapTab(currentMapX, currentMapY);
                                gs.InitKiryu(GameScreen._kiryuPosX - 1, GameScreen._kiryuPosY);
                            }

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
                    }
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
                gs.SetSpritesTab(fight.Party);
                gs.SetMapTab(currentMapX, currentMapY);
                gs.InitKiryu(GameScreen._kiryuPosX - 1, GameScreen._kiryuPosY);
            }
        }

        static public void changeMode(GameModes Mode)
        {
            if (Mode == GameModes.MAP)
            {
                gMode = GameModes.MAP;
                Console.Clear();
                gs.SetMenuTab();
                gs.SetSpritesTab(Party);
                gs.SetMapTab(currentMapX, currentMapY);
                gs.InitKiryu(GameScreen._kiryuPosX - 1, GameScreen._kiryuPosY);
            }
        }
    }
}

