using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class GameScreen
    {
        public string[,] MapMap { get; private set; } = new string[5, 8];
        public string[,] MenuTab { get; private set; } = new string[56, 30];
        public string[,] SpritesTab { get; private set; } = new string[56, 30];
        public string[,] _kiryuSprite = new string[10, 10];

        public string _line;
        public int _kiryuPosX;
        public int _kiryuPosY;

        //1 = Easy, 2 = Normal, 3 = Hard, 4 = Legend
        public int _initSave;

        //Upon entering the Fight Menu -> 0 : Attack, 1 : Skills, 2 : Party, 3 : Items, 4 : Run
        //In the Skills + Items Submenu, X = +1 and Y = +2
        //In the Party Submenu, Y = +1
        public int _cursorPosX;
        public int _cursorPosY;
        public int _prevCurX;
        public int _prevCurY;

        public string _curSMenu;

        //_selectMode 0 -> Only on the X axis, 0-4 : Fight Menu
        //_selectMode 1 -> Only on the Y axis, 0-3 : Party Submenu
        //_selectMode 2 -> On both axises, [0-3, 0-1] : Skills + Items Submenu
        public int _selectMode;

        public bool _game;
        public bool _mainMenu;

        public struct mapGrid
        {
            public char display;
            public bool isWall;
            public bool isKiryu;
            public int tpID;
        }

        public mapGrid[,] grid = new mapGrid[150,56];

        public void SetMainMenu()
        {
            Console.SetCursorPosition(0, 0);
            StreamReader sr = new StreamReader("../../../UI/MainMenu.txt");

            for (int i = 0; i < 56; i++) 
            {
                _line = sr.ReadLine();
                Console.Write(_line);
            }

            sr.Close();
            _selectMode = 1;

            SelectHoverMM(ConsoleColor.Blue);
        }

        public void SetMenuTab()
        {

            Console.SetCursorPosition(0, 0);
            Console.Write("Press Nmb for Menu");
            Console.SetCursorPosition(7, 5);
            Console.Write("1.Equipements");
            Console.SetCursorPosition(7, 8);
            Console.Write("2.Items");
            Console.SetCursorPosition(7, 11);
            Console.Write("3.Map");
            Console.SetCursorPosition(7, 14);
            Console.Write("4.Party");
            Console.SetCursorPosition(7, 17);
            Console.Write("5.Save/Load/Quit");
            Console.SetCursorPosition(7, 20);
            Console.Write("6.Settings");

            for (int i = 0; i < 56; i++)
            {
                Console.SetCursorPosition(30, i);
                Console.Write("|");
            }
        }

        public void SetSpritesTab(List<Character> Party)
        {
            for (int i = 0; i < 56; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 28, i);
                Console.Write("|");
            }

            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < Party.Count; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.SetCursorPosition(184, Console.CursorTop + 1);
                    Console.Write("######################");
                }

                Console.SetCursorPosition(184, Console.CursorTop + 2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(Party[i].Name);

                Console.SetCursorPosition(184, Console.CursorTop + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("HP ");
                Console.Write(Party[i].PV);
                Console.Write('/');
                Console.Write(Party[i].EquippedStyle.StatDict["PV"]);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write('|');

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("MP ");
                Console.Write(Party[i].PM);
                Console.Write('/');
                Console.Write(Party[i].EquippedStyle.StatDict["PM"]);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write('|');

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(Party[i].EquippedStyle.Status[0].ToString());
                Console.ForegroundColor = ConsoleColor.Gray;

                if (Console.CursorTop == 54)
                {
                    break;
                }

                Console.SetCursorPosition(184, Console.CursorTop + 2);
            }
        }

        public void SetMaps()
        {
            MapMap[0, 0] = "../../../MapsK/Map01.txt";
        }

        public void SetMapTab(int x, int y)
        {
            Console.SetCursorPosition(31, 0);

            StreamReader sr = new StreamReader(MapMap[x, y]);
            _line = sr.ReadLine();


            for (int i = 0; i < 56; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    grid[j,i].display = _line[j];
                    grid[j,i].isKiryu = false;
                    grid[j, i].isWall = true;

                    if (grid[j,i].display == ' ')
                    {
                        grid[j,i].isWall = false;
                    }
                    else if (grid[j,i].display == '1')
                    {
                        grid[j,i].isWall = false;
                        grid[j,i].tpID = 1;
                    }
                    else if (grid[j, i].display == '2')
                    {
                        grid[j, i].isWall = false;
                        grid[j, i].tpID = 2;
                    }
                    else if (grid[j, i].display == '3')
                    {
                        grid[j, i].isWall = false;
                        grid[j, i].tpID = 3;
                    }
                    else if (grid[j, i].display == '4')
                    {
                        grid[j, i].isWall = false;
                        grid[j, i].tpID = 4;
                    }
                    else if (grid[j, i].display == '5')
                    {
                        grid[j, i].isWall = false;
                        grid[j, i].tpID = 5;
                    }
                    else if (grid[j, i].display == '6')
                    {
                        grid[j, i].isWall = false;
                        grid[j, i].tpID = 6;
                    }
                }

                Console.Write(_line);
                int posX = Console.GetCursorPosition().Left - 150;
                int posY = Console.GetCursorPosition().Top + 1;

                if (posY != 56)
                {
                    Console.SetCursorPosition(posX, posY);
                }

                _line = sr.ReadLine();
            }

            sr.Close();

        }

        public void InitKiryu(int x, int y)
        {
            Console.SetCursorPosition(32 + x, y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write('K');
            Console.ForegroundColor = ConsoleColor.Gray;
            grid[x, y].isKiryu = true;
            _kiryuPosX = x + 1;
            _kiryuPosY = y;
        }

        public void MoveCharacter(string dir)
        {
            int cLPos = Console.CursorLeft;
            int cTPos = Console.CursorTop;
            int uCLPos;
            int uCTPos;

            switch (dir) 
            { 
                case "Up":
                    Console.SetCursorPosition(cLPos - 1, cTPos - 2);
                    
                    uCLPos = cLPos - 1;
                    uCTPos = cTPos - 2;

                    if (_kiryuPosY >= 2)
                    {
                        if (grid[_kiryuPosX, _kiryuPosY - 2].isWall == false)
                        {
                            Console.SetCursorPosition(uCLPos, cTPos);
                            Console.Write(' ');
                            Console.SetCursorPosition(uCLPos, uCTPos);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write('K');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            grid[_kiryuPosX, _kiryuPosY].isKiryu = false;
                            grid[_kiryuPosX, _kiryuPosY - 2].isKiryu = true;
                            _kiryuPosY -= 2;
                            break;
                        }
                    }
                    
                    if (_kiryuPosY >= 1)
                    {
                        if (grid[_kiryuPosX, _kiryuPosY - 1].isWall == false)
                        {
                            Console.SetCursorPosition(uCLPos, cTPos);
                            Console.Write(' ');
                            Console.SetCursorPosition(uCLPos, uCTPos + 1);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write('K');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            grid[_kiryuPosX, _kiryuPosY].isKiryu = false;
                            grid[_kiryuPosX, _kiryuPosY - 1].isKiryu = true;
                            _kiryuPosY -= 1;
                            break;
                        }
                    }

                    Console.SetCursorPosition(cLPos, cTPos);

                    break;



                case "Down":

                    uCLPos = cLPos - 1;
                    uCTPos = cTPos + 2;

                    if (_kiryuPosY <= 53)
                    {
                        if (grid[_kiryuPosX, _kiryuPosY + 2].isWall == false)
                        {
                            Console.SetCursorPosition(uCLPos, cTPos);
                            Console.Write(' ');
                            Console.SetCursorPosition(uCLPos, uCTPos);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write('K');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            grid[_kiryuPosX, _kiryuPosY].isKiryu = false;
                            grid[_kiryuPosX, _kiryuPosY + 2].isKiryu = true;
                            _kiryuPosY += 2;
                            break;
                        }
                    }

                    if (_kiryuPosY <= 55)
                    {
                        if (grid[_kiryuPosX, _kiryuPosY + 1].isWall == false)
                        {
                            Console.SetCursorPosition(uCLPos, cTPos);
                            Console.Write(' ');
                            Console.SetCursorPosition(uCLPos, uCTPos - 1);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write('K');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            grid[_kiryuPosX, _kiryuPosY].isKiryu = false;
                            grid[_kiryuPosX, _kiryuPosY + 1].isKiryu = true;
                            _kiryuPosY += 1;
                            break;
                        }
                    }

                    Console.SetCursorPosition(cLPos, cTPos);

                    break;



                case "Left":

                    uCLPos = cLPos - 4;
                    Console.SetCursorPosition(uCLPos, cTPos);

                    if (_kiryuPosX >= 3)
                    {
                        if (grid[_kiryuPosX - 3, _kiryuPosY].isWall == false && cLPos >= 31)
                        {
                            Console.SetCursorPosition(cLPos - 1, cTPos);
                            Console.Write(' ');
                            Console.SetCursorPosition(uCLPos, cTPos);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write('K');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            grid[_kiryuPosX, _kiryuPosY].isKiryu = false;
                            grid[_kiryuPosX - 3, _kiryuPosY].isKiryu = true;
                            _kiryuPosX -= 3;
                    break;
                        }
                    }

                    if (_kiryuPosX >= 1)
                    {
                        if (grid[_kiryuPosX - 1, _kiryuPosY].isWall == false)
                        {
                            Console.SetCursorPosition(cLPos - 1, cTPos);
                            Console.Write(' ');
                            Console.SetCursorPosition(uCLPos + 2, cTPos);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write('K');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            grid[_kiryuPosX, _kiryuPosY].isKiryu = false;
                            grid[_kiryuPosX - 1, _kiryuPosY].isKiryu = true;
                            _kiryuPosX -= 1;
                            break;
                        }
                    }
                    
                    Console.SetCursorPosition(cLPos, cTPos);

                    break;



                case "Right":

                    uCLPos = cLPos + 2;
                    Console.SetCursorPosition(uCLPos, cTPos);

                    if (_kiryuPosX <= 146)
                    {
                        if (grid[_kiryuPosX + 3, _kiryuPosY].isWall == false && cLPos <= Console.BufferWidth - 31)
                        {
                            Console.SetCursorPosition(cLPos - 1, cTPos);
                            Console.Write(' ');
                            Console.SetCursorPosition(uCLPos, cTPos);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write('K');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            grid[_kiryuPosX, _kiryuPosY].isKiryu = false;
                            grid[_kiryuPosX + 3, _kiryuPosY].isKiryu = true;
                            _kiryuPosX += 3;
                            break;
                        }
                    }

                    if (_kiryuPosX <= 148)
                    {
                         if (grid[_kiryuPosX + 1, _kiryuPosY].isWall == false && cLPos <= Console.BufferWidth - 30)
                        {
                            Console.SetCursorPosition(cLPos - 1, cTPos);
                            Console.Write(' ');
                            Console.SetCursorPosition(uCLPos - 2, cTPos);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write('K');
                            Console.ForegroundColor = ConsoleColor.Gray;
                            grid[_kiryuPosX, _kiryuPosY].isKiryu = false;
                            grid[_kiryuPosX + 1, _kiryuPosY].isKiryu = true;
                            _kiryuPosX += 1;
                            break;
                        }
                    }
                    
                    Console.SetCursorPosition(cLPos, cTPos);

                    break;
            }
        }

        public void SetFightUI(List<Character> Party)
        {
            Console.Clear();
            StreamReader sr = new StreamReader("../../../UI/Fight.txt");

            _line = sr.ReadLine();

            for (int i = 0; i < 56; i++)
            { 
                Console.Write(_line);
                _line = sr.ReadLine();

            }

            sr.Close();

            StreamReader sr2 = new StreamReader("../../../Sprites/FIGHT_Goku.txt");

            _line = sr2.ReadLine();

            for (int i = 0; i < 31; i++)
            {
                Console.SetCursorPosition(71, 7 + i);
                Console.Write(_line);
                _line = sr2.ReadLine();
            }

            sr2.Close();



            //Set the first party member's infos on the UI
            string curPlName = Party[0].EquippedStyle.Name;
            int curPlHP = Party[0].EquippedStyle.PV;
            int curPlHPM = Party[0].EquippedStyle.StatDict["PV"];
            int curPlMP = Party[0].EquippedStyle.PM;
            int curPlMPM = Party[0].EquippedStyle.StatDict["PM"];
            string curPlStt = Party[0].EquippedStyle.Status[0].ToString();

            //Draw said infos
            int y = 46;
            Console.SetCursorPosition(9, y);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(curPlName);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(Console.CursorLeft + 8, y);
            Console.Write('|');

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.CursorLeft + 8, y);
            Console.Write(curPlHP);
            Console.Write('/');
            Console.Write(curPlHPM);
            Console.Write(" HP");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(Console.CursorLeft + 8, y);
            Console.Write('|');

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(Console.CursorLeft + 8, y);
            Console.Write(curPlMP);
            Console.Write('/');
            Console.Write(curPlMPM);
            Console.Write(" MP");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.SetCursorPosition(Console.CursorLeft + 8, y);
            Console.Write('|');

            Console.ForegroundColor = ConsoleColor.Yellow;   
            Console.SetCursorPosition(Console.CursorLeft + 8, y);
            Console.Write("Status : ");
            Console.Write(curPlStt);
            Console.ForegroundColor = ConsoleColor.Gray;

            SelectHover(ConsoleColor.Blue, Party);
        }

        public void SetSubmenu(string sMenu, List<Character> Party, Dictionary<string, List<Item>> Inventory)
        {

            if (sMenu == "skills" || sMenu == "items" || sMenu == "party")
            {
                int curX = 36;

                _cursorPosY = 0; 
                _cursorPosX = 0;

                Console.SetCursorPosition(1, 46);
                Console.Write("                                                                                                            ");

                for (int i = 35; i < 48; i++)
                {
                    Console.SetCursorPosition(151, i);
                    Console.Write("|");
                }

                switch (sMenu)
                {
                    case "skills":

                        for (int i = 0; i < Party[0].EquippedStyle.AttackList.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.SetCursorPosition(9, curX);
                                Console.Write("-");

                                if (Party[0].EquippedStyle.AttackList[i].Type.Count == 1)
                                {
                                    Console.Write(Party[0].EquippedStyle.AttackList[i].Type[0]);
                                }

                                if (Party[0].EquippedStyle.AttackList[i].Type.Count == 2)
                                {
                                    Console.Write(Party[0].EquippedStyle.AttackList[i].Type[0]);
                                    Console.Write('/');
                                    Console.Write(Party[0].EquippedStyle.AttackList[i].Type[1]);
                                }

                                Console.Write(" - ");
                                Console.Write(Party[0].EquippedStyle.AttackList[i].Name);
                            }

                            if (i % 2 == 1)
                            {
                                Console.SetCursorPosition(91, curX);
                                Console.Write("-");

                                if (Party[0].EquippedStyle.AttackList[i].Type.Count == 1)
                                {
                                    Console.Write(Party[0].EquippedStyle.AttackList[i].Type[0]);
                                }

                                if (Party[0].EquippedStyle.AttackList[i].Type.Count == 2)
                                {
                                    Console.Write(Party[0].EquippedStyle.AttackList[i].Type[0]);
                                    Console.Write('/');
                                    Console.Write(Party[0].EquippedStyle.AttackList[i].Type[1]);
                                }

                                Console.Write(" - ");
                                Console.Write(Party[0].EquippedStyle.AttackList[i].Name);

                                curX += 3;
                            }
                        }

                        break;

                    case "items":
                        break;

                    case "party":

                        for (int i = 0; i < Party.Count; i++)
                        {
                            Console.SetCursorPosition(9, curX);
                            Console.Write("-");
                            Console.Write(Party[i].EquippedStyle.Name);

                            curX += 3;
                        }

                        break;
                }

            }

            if (sMenu == "MItems" || sMenu == "MParty")
            {
                Console.SetCursorPosition(31, 0);
                StreamReader sr = new StreamReader("../../../UI/PartyItems.txt");
                _line = sr.ReadLine();


                for (int i = 0; i < 56; i++)
                {

                    Console.Write(_line);
                    int posX = Console.GetCursorPosition().Left - 150;
                    int posY = Console.GetCursorPosition().Top + 1;

                    if (posY != 56)
                    {
                        Console.SetCursorPosition(posX, posY);
                    }

                    _line = sr.ReadLine();
                }

                sr.Close();

                if (sMenu == "MItems")
                {
                    Console.SetCursorPosition(31, 0);
                    Console.Write("Items:");

                    foreach (string key in Inventory.Keys)
                    {
                        Console.SetCursorPosition(31, 0);

                        if (key == "heal")
                        {
                            for (int i = 0; i < Inventory["heal"].Count; i++)
                            {
                                //Console.SetCursorPosition();
                            }
                        }
                    }
                }

                if (sMenu == "MParty")
                {
                    Console.SetCursorPosition(35, 1);
                    Console.Write("Party:");

                    Console.SetCursorPosition(43, 7);

                    for (int i = 0; i < Party.Count; i++)
                    {
                        Console.Write("-" + Party[i].EquippedStyle.Name);
                        Console.SetCursorPosition(43, Console.CursorTop + 12);
                    } 

                }
            }

        }


        public void SetSubmenuMM()
        {

            if (_curSMenu == "new")
            {
                Console.SetCursorPosition(70, 17);
                Console.Write("._______________________________________________________________________.");
                Console.SetCursorPosition(70, 18);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 19);
                Console.Write("|   Select a Difficulty :      |                                        |");
                Console.SetCursorPosition(70, 20);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 21);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 22);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 23);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 24);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 25);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 26);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 27);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 28);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 29);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 30);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 31);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 32);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 33);
                Console.Write("|______________________________|________________________________________|");

                Console.SetCursorPosition(76, 22);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("-Easy");

                Console.SetCursorPosition(76, 25);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("-Normal");

                Console.SetCursorPosition(76, 28);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("-Hard");

                Console.SetCursorPosition(76, 31);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("-Legend");

                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if (_curSMenu == "load")
            {
                Console.SetCursorPosition(70, 17);
                Console.Write("._______________________________________________________________________.");
                Console.SetCursorPosition(70, 18);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 19);
                Console.Write("|   Select a Save File :       |                                        |");
                Console.SetCursorPosition(70, 20);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 21);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 22);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 23);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 24);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 25);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 26);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 27);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 28);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 29);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 30);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 31);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 32);
                Console.Write("|                              |                                        |");
                Console.SetCursorPosition(70, 33);
                Console.Write("|______________________________|________________________________________|");

                bool isFile1 = File.Exists("../../..Saves/Save01.txt");
                Console.SetCursorPosition(76, 22);
                Console.Write("-Empty");
                if (isFile1)
                {
                    Console.SetCursorPosition(77, 22);
                    Console.Write("Savefile 1");
                }

                bool isFile2 = File.Exists("../../..Saves/Save02.txt");
                Console.SetCursorPosition(76, 25);
                Console.Write("-Empty");
                if (isFile2)
                {
                    Console.SetCursorPosition(77, 25);
                    Console.Write("Savefile 1");
                }

                bool isFile3 = File.Exists("../../..Saves/Save03.txt");
                Console.SetCursorPosition(76, 28);
                Console.Write("-Empty");
                if (isFile3)
                {
                    Console.SetCursorPosition(77, 28);
                    Console.Write("Savefile 1");
                }

                bool isFile4 = File.Exists("../../..Saves/Save04.txt");
                Console.SetCursorPosition(76, 31);
                Console.Write("-Empty");
                if (isFile4)
                {
                    Console.SetCursorPosition(77, 31);
                    Console.Write("Savefile 1");
                }
            }
        }


        public void MoveCursorMM(string dir)
        {
            if (dir == "u" && _cursorPosY != 0)
            {
                if (_curSMenu != null)
                {
                    SetSubmenuMM();
                }

                if (_curSMenu == null)
                {
                    SelectHoverMM(ConsoleColor.Gray);
                }
                _cursorPosY -= 1;
                SelectHoverMM(ConsoleColor.Blue);
            }

            if (_curSMenu == null)
            {
                if (dir == "d" && _cursorPosY != 2)
                {
                    SelectHoverMM(ConsoleColor.Gray);
                    _cursorPosY += 1;
                    SelectHoverMM(ConsoleColor.Blue);
                }
            }
            if (_curSMenu != null)
            {
                if (dir == "d" && _cursorPosY != 3)
                {
                    SetSubmenuMM();
                    _cursorPosY += 1;
                    SelectHoverMM(ConsoleColor.Blue);
                }
            }
        }

        public void MoveCursor(string dir, List<Character> Party)
        {

            if (dir == "r" && _selectMode != 1)
            {
                if (_selectMode == 0 && _cursorPosX < 4) 
                {
                    SelectHover(ConsoleColor.Gray, Party);
                    _cursorPosX += 1;
                    SelectHover(ConsoleColor.Blue, Party);
                }

                if (_selectMode == 2 && _cursorPosX < 1)
                {
                    SelectHover(ConsoleColor.Gray, Party);
                    _cursorPosX += 1;
                    SelectHover(ConsoleColor.Blue, Party);
                }
            }

            if (dir == "l" && _selectMode != 1)
            {
                if (_selectMode == 0 && _cursorPosX > 0)
                {
                    SelectHover(ConsoleColor.Gray, Party);
                    _cursorPosX -= 1;
                    SelectHover(ConsoleColor.Blue, Party);
                }

                if (_selectMode == 2 && _cursorPosX > 0)
                {
                    SelectHover(ConsoleColor.Gray, Party);
                    _cursorPosX -= 1;
                    SelectHover(ConsoleColor.Blue, Party);
                }
            }

            if (dir == "u" && _selectMode != 0)
            {
                if (_cursorPosY > 0)
                {
                    SelectHover(ConsoleColor.Gray, Party);
                    _cursorPosY -= 1;
                    SelectHover(ConsoleColor.Blue, Party);
                }
            }

            if (dir == "d" && _selectMode != 0)
            {
                if (_cursorPosY < 3)
                {
                    SelectHover(ConsoleColor.Gray, Party);
                    _cursorPosY += 1;
                    SelectHover(ConsoleColor.Blue, Party);
                }
            }
        }

        public void SelectHover(ConsoleColor color, List<Character> Party)
        {
            if (_curSMenu == "MParty")
            {
                Console.SetCursorPosition(43, _cursorPosY * 12 + 7);
                Console.ForegroundColor = color;
                Console.Write('-');
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.SetCursorPosition(0, 2);

                for (int j = 0; j < 9; j++)
                {
                    Console.SetCursorPosition(152, Console.CursorTop + 1);
                    Console.Write("######################");
                }

                Console.SetCursorPosition(148, 18);
                Console.Write("                                 ");
                Console.SetCursorPosition(148, 18);
                Console.Write(Party[_cursorPosY].EquippedStyle.Name);
                Console.SetCursorPosition(148, 19);
                Console.Write("                                 ");
                Console.SetCursorPosition(148, 19);

                if (Party[_cursorPosY].EquippedStyle.Type.Count == 2)
                {
                    Console.Write(Party[_cursorPosY].EquippedStyle.Type[0] + "/" + Party[_cursorPosY].EquippedStyle.Type[1]);
                }

                if (Party[_cursorPosY].EquippedStyle.Type.Count == 1)
                {
                    Console.Write(Party[_cursorPosY].EquippedStyle.Type[0]);
                }


                Console.SetCursorPosition(153, 21);
                Console.Write("                            ");
                Console.SetCursorPosition(153, 21);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("HP " + Party[_cursorPosY].EquippedStyle.PV + "/" + Party[_cursorPosY].EquippedStyle.StatDict["PV"]);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  |  ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("LVL " + Party[_cursorPosY].Level);

                Console.SetCursorPosition(153, 22);
                Console.Write("                            ");
                Console.SetCursorPosition(153, 22);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("MP " + Party[_cursorPosY].EquippedStyle.PV + "/" + Party[_cursorPosY].EquippedStyle.StatDict["PM"]);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  |  ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("EXP " + Party[_cursorPosY].Experience);


                Console.SetCursorPosition(153, 24);
                Console.Write("                            ");
                Console.SetCursorPosition(153, 24);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Atk: " + Party[_cursorPosY].EquippedStyle.StatDict["Attack"]);

                Console.SetCursorPosition(153, 25);
                Console.Write("                            ");
                Console.SetCursorPosition(153, 25);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("Def: " + Party[_cursorPosY].EquippedStyle.StatDict["Defense"]);

                Console.SetCursorPosition(153, 26);
                Console.Write("                            ");
                Console.SetCursorPosition(153, 26);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(Party[_cursorPosY].Status[0].ToString());

                Console.SetCursorPosition(163, 24);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Mgk: " + Party[_cursorPosY].EquippedStyle.StatDict["Magic"]);

                Console.SetCursorPosition(163, 25);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("WlP: " + Party[_cursorPosY].EquippedStyle.StatDict["Willpower"]);

                Console.SetCursorPosition(163, 26);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Agl: " + Party[_cursorPosY].EquippedStyle.StatDict["Agility"]);


                Console.SetCursorPosition(153, 28);
                Console.Write("                            ");
                Console.SetCursorPosition(153, 28);
                Console.ForegroundColor = ConsoleColor.White;
                if (Party[_cursorPosY].EquippedStyle.EquippedWeapon != null)
                {
                    Console.Write("Wpn: " + Party[_cursorPosY].EquippedStyle.EquippedWeapon.Name);
                }
                else
                {
                    Console.Write("Wpn: No Wpn");
                }

                Console.SetCursorPosition(153, 30);
                Console.Write("                            ");
                Console.SetCursorPosition(153, 30);
                Console.ForegroundColor = ConsoleColor.White;
                if (Party[_cursorPosY].EquippedStyle.EquippedArmor.Count == 0)
                {
                    Console.Write("Arm 1: No Arm");
                    Console.SetCursorPosition(153, 31);
                    Console.Write("                            ");
                    Console.SetCursorPosition(153, 31);
                    Console.Write("Arm 2: No Arm");
                    Console.SetCursorPosition(153, 32);
                    Console.Write("                            ");
                    Console.SetCursorPosition(153, 32);
                    Console.Write("Arm 3: No Arm");
                }
                if (Party[_cursorPosY].EquippedStyle.EquippedArmor.Count == 1)
                {
                    Console.Write("Arm 1: " + Party[_cursorPosY].EquippedStyle.EquippedArmor[0].Name);
                    Console.SetCursorPosition(153, 31);
                    Console.Write("                            ");
                    Console.SetCursorPosition(153, 31);
                    Console.Write("Arm 2: No Arm");
                    Console.SetCursorPosition(153, 32);
                    Console.Write("                            ");
                    Console.SetCursorPosition(153, 32);
                    Console.Write("Arm 3: No Arm");
                }
                if (Party[_cursorPosY].EquippedStyle.EquippedArmor.Count == 2)
                {
                    Console.Write("Arm 1: " + Party[_cursorPosY].EquippedStyle.EquippedArmor[0].Name);
                    Console.SetCursorPosition(153, 31);
                    Console.Write("                            ");
                    Console.SetCursorPosition(153, 31);
                    Console.Write("Arm 2: " + Party[_cursorPosY].EquippedStyle.EquippedArmor[1].Name);
                    Console.SetCursorPosition(153, 32);
                    Console.Write("                            ");
                    Console.SetCursorPosition(153, 32);
                    Console.Write("Arm 3: No Arm");
                }
                if (Party[_cursorPosY].EquippedStyle.EquippedArmor.Count == 3)
                {
                    Console.Write("Arm 1: " + Party[_cursorPosY].EquippedStyle.EquippedArmor[0].Name);
                    Console.SetCursorPosition(153, 31);
                    Console.Write("                            ");
                    Console.SetCursorPosition(153, 31);
                    Console.Write("Arm 2: " + Party[_cursorPosY].EquippedStyle.EquippedArmor[1].Name);
                    Console.SetCursorPosition(153, 32);
                    Console.Write("                            ");
                    Console.SetCursorPosition(153, 32);
                    Console.Write("Arm 3: " + Party[_cursorPosY].EquippedStyle.EquippedArmor[2].Name);
                }

                Console.SetCursorPosition(153, 34);
                Console.Write("                            ");
                Console.SetCursorPosition(153, 34);
                Console.ForegroundColor = ConsoleColor.White;
                if (Party[_cursorPosY].EquippedStyle.EquippedGears.Count == 0)
                {
                    Console.Write("Gear 1: No Gear");
                    Console.SetCursorPosition(153, 35);
                    Console.Write("                            ");
                    Console.SetCursorPosition(153, 35);
                    Console.Write("Gear 2: No Gear");
                }
                if (Party[_cursorPosY].EquippedStyle.EquippedGears.Count == 1)
                {
                    Console.Write("Gear 1: " + Party[_cursorPosY].EquippedStyle.EquippedGears[0].Name);
                    Console.SetCursorPosition(153, 35);
                    Console.Write("                            ");
                    Console.SetCursorPosition(153, 35);
                    Console.Write("Gear 2: No Gear");
                }
                if (Party[_cursorPosY].EquippedStyle.EquippedGears.Count == 2)
                {
                    Console.Write("Gear 1: " + Party[_cursorPosY].EquippedStyle.EquippedGears[0].Name);
                    Console.SetCursorPosition(153, 35);
                    Console.Write("                            ");
                    Console.SetCursorPosition(153, 35);
                    Console.Write("Gear 2: " + Party[_cursorPosY].EquippedStyle.EquippedGears[1].Name);
                }

                Console.SetCursorPosition(150, 38);
                Console.Write("Attacks :");
                Console.SetCursorPosition(153, 40);

                for (int i = 0; i < 10; i++)
                {
                    Console.Write("                           ");
                    Console.SetCursorPosition(153, 40 + i + 1);
                }

                Console.SetCursorPosition(153, 40);
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int i = 0; i < Party[_cursorPosY].EquippedStyle.AttackList.Count; i++)
                {
                    Console.Write(Party[_cursorPosY].EquippedStyle.AttackList[i].Name);
                    Console.SetCursorPosition(153, 40 + i + 1);
                }
            }

            if (_selectMode == 0)
            {
                if (_cursorPosX == 0)
                {
                    Console.SetCursorPosition(1, 48);
                    Console.ForegroundColor = color;
                    Console.WriteLine("       ___  _   _             _         ");
                    Console.SetCursorPosition(1, 49);
                    Console.WriteLine("      / _ \\| | | |           | |        ");
                    Console.SetCursorPosition(1, 50);
                    Console.WriteLine("     / /_\\ \\ |_| |_ __ _  ___| | __     ");
                    Console.SetCursorPosition(1, 51);
                    Console.WriteLine("     |  _  | __| __/ _` |/ __| |/ /     ");
                    Console.SetCursorPosition(1, 52);
                    Console.WriteLine("     | | | | |_| || (_| | (__|   <      ");
                    Console.SetCursorPosition(1, 53);
                    Console.WriteLine("     \\_| |_/\\__|\\__\\__,_|\\___|_|\\_\\     ");
                    Console.ForegroundColor = ConsoleColor.Gray;

                }

                if (_cursorPosX == 1)
                {
                    Console.SetCursorPosition(42, 48);
                    Console.ForegroundColor = color;
                    Console.WriteLine("          _____ _    _ _ _               ");
                    Console.SetCursorPosition(42, 49);
                    Console.WriteLine("         /  ___| |  (_) | |              ");
                    Console.SetCursorPosition(42, 50);
                    Console.WriteLine("         \\ `--.| | ___| | |___           ");
                    Console.SetCursorPosition(42, 51);
                    Console.WriteLine("          `--. \\ |/ / | | / __|          ");
                    Console.SetCursorPosition(42, 52);
                    Console.WriteLine("         /\\__/ /   <| | | \\__ \\          ");
                    Console.SetCursorPosition(42, 53);
                    Console.WriteLine("         \\____/|_|\\_\\_|_|_|___/          ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (_cursorPosX == 2)
                {
                    Console.SetCursorPosition(84, 48);
                    Console.ForegroundColor = color;
                    Console.WriteLine("        _____          _                 ");
                    Console.SetCursorPosition(84, 49);
                    Console.WriteLine("       | ___ \\        | |                ");
                    Console.SetCursorPosition(84, 50);
                    Console.WriteLine("       | |_/ /_ _ _ __| |_ _   _         ");
                    Console.SetCursorPosition(84, 51);
                    Console.WriteLine("       |  __/ _` | '__| __| | | |        ");
                    Console.SetCursorPosition(84, 52);
                    Console.WriteLine("       | | | (_| | |  | |_| |_| |        ");
                    Console.SetCursorPosition(84, 53);
                    Console.WriteLine("       \\_|  \\__,_|_|   \\__|\\__, |        ");
                    Console.SetCursorPosition(114, 54);
                    Console.WriteLine("/_|");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (_cursorPosX == 3)
                {
                    Console.SetCursorPosition(126, 48);
                    Console.ForegroundColor = color;
                    Console.WriteLine("       _____ _                           ");
                    Console.SetCursorPosition(126, 49);
                    Console.WriteLine("      |_   _| |                          ");
                    Console.SetCursorPosition(126, 50);
                    Console.WriteLine("        | | | |_ ___ _ __ ___  ___       ");
                    Console.SetCursorPosition(126, 51);
                    Console.WriteLine("        | | | __/ _ \\ '_ ` _ \\/ __|      ");
                    Console.SetCursorPosition(126, 52);
                    Console.WriteLine("       _| |_| ||  __/ | | | | \\__ \\      ");
                    Console.SetCursorPosition(126, 53);
                    Console.WriteLine("       \\___/ \\__\\___|_| |_| |_|___/      "); 
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (_cursorPosX == 4)
                {
                    Console.SetCursorPosition(168, 48);
                    Console.ForegroundColor = color;
                    Console.WriteLine("         ______            _ _          ");
                    Console.SetCursorPosition(168, 49);
                    Console.WriteLine("         | ___ \\          | | |         ");
                    Console.SetCursorPosition(168, 50);
                    Console.WriteLine("         | |_/ /   _ _ __ | | |         ");
                    Console.SetCursorPosition(168, 51);
                    Console.WriteLine("         |    / | | | '_ \\| | |         ");
                    Console.SetCursorPosition(168, 52);
                    Console.WriteLine("         | |\\ \\ |_| | | | |_|_|         ");
                    Console.SetCursorPosition(168, 53);
                    Console.WriteLine("         \\_| \\_\\__,_|_| |_(_|_)         ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            if (_selectMode == 1 && _curSMenu != "MParty")
            {
                Console.SetCursorPosition(9, _cursorPosY * 3 + 36);
                Console.ForegroundColor = color;
                Console.Write('-');
                Console.ForegroundColor = ConsoleColor.Gray;

                //Stats
                Console.SetCursorPosition(155, 36);
                Console.Write("Stats:");
                Console.SetCursorPosition(155, 38);
                Console.Write("         ");
                Console.SetCursorPosition(155, 38);

                if (Party[_cursorPosY].EquippedStyle.Type.Count == 2)
                {
                    Console.Write(Party[_cursorPosY].EquippedStyle.Type[0]);
                    Console.Write('/');
                    Console.Write(Party[_cursorPosY].EquippedStyle.Type[1]);
                }

                if (Party[_cursorPosY].EquippedStyle.Type.Count == 1)
                {
                    Console.Write(Party[_cursorPosY].EquippedStyle.Type[0]);
                }

                Console.SetCursorPosition(155, 39);
                Console.Write("          ");
                Console.SetCursorPosition(155, 39);
                Console.Write(Party[_cursorPosY].EquippedStyle.PV);
                Console.Write('/');
                int curPlHPM;
                Party[0].EquippedStyle.StatDict.TryGetValue("PV", out curPlHPM);
                Console.Write(curPlHPM);
                Console.Write(" HP");

                Console.SetCursorPosition(155, 40);
                Console.Write("          ");
                Console.SetCursorPosition(155, 40);
                Console.Write(Party[_cursorPosY].EquippedStyle.PM);
                Console.Write('/');
                int curPlMPM;
                Party[0].EquippedStyle.StatDict.TryGetValue("PM", out curPlMPM);
                Console.Write(curPlMPM);
                Console.Write(" MP");

                Console.SetCursorPosition(155, 41);
                Console.Write("          ");
                Console.SetCursorPosition(155, 41);
                Console.Write("Lvl ");
                Console.Write(Party[_cursorPosY].Level);

                Console.SetCursorPosition(155, 42);
                Console.Write("          ");
                Console.SetCursorPosition(155, 42);
                Console.Write(Party[_cursorPosY].EquippedStyle.Status[0].ToString());

                //Attacks
                Console.SetCursorPosition(179, 36);
                Console.Write("Attacks:");

                int loopNb = 0;
                int curX = 38;

                for (int i = 0; Party[_cursorPosY].EquippedStyle.AttackList.Count > i; i++)
                {
                    Console.SetCursorPosition(179, curX);
                    Console.Write("                       ");
                    Console.SetCursorPosition(179, curX);
                    Console.Write(Party[_cursorPosY].EquippedStyle.AttackList[i].Name);
                    curX += 1;
                    loopNb += 1;

                    if (i == 7)
                    {
                        break;
                    }
                }

                for (int i = loopNb; i < 8; i++)
                {
                    Console.SetCursorPosition(179, curX);
                    Console.Write("                       ");
                    curX += 1;
                }

            }

            if (_selectMode == 2 && _curSMenu != "MParty")
            {
                Console.SetCursorPosition(_cursorPosX * 82 + 9, _cursorPosY * 3 + 36);
                Console.ForegroundColor = color;
                Console.Write('-');
                Console.ForegroundColor = ConsoleColor.Gray;

                if (_prevCurX == 1)
                {
                    Console.SetCursorPosition(155, 36);
                    Console.Write("                         ");
                    Console.SetCursorPosition(155, 36);
                    Console.Write(Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].Name);

                    Console.SetCursorPosition(155, 40);
                    Console.Write("                         ");
                    Console.SetCursorPosition(155, 40);

                    if (Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].Type.Count == 2)
                    {
                        Console.Write(Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].Type[0]);
                        Console.Write('/');
                        Console.Write(Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].Type[1]);
                    }

                    if (Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].Type.Count == 1)
                    {
                        Console.Write(Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].Type[0]);
                    }

                    Console.SetCursorPosition(155, 41);
                    Console.Write("                         ");
                    Console.SetCursorPosition(155, 41);
                    Console.Write(Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].PMCost);
                    Console.Write(" MP");

                    Console.SetCursorPosition(155, 42);
                    Console.Write("                         ");
                    Console.SetCursorPosition(155, 42);
                    Console.Write(Party[0].EquippedStyle.StatDict["Attack"]);
                    Console.Write(" + ");
                    Console.Write(Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].DmgMin);
                    Console.Write("~");
                    Console.Write(Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].DmgMax);
                    Console.Write(" DMG");

                    Console.SetCursorPosition(155, 43);
                    Console.Write("                         ");
                    Console.SetCursorPosition(155, 43);
                    Console.Write(Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].Precision);
                    Console.Write(" PRC");

                    Console.SetCursorPosition(155, 44);
                    Console.Write("                         ");
                    Console.SetCursorPosition(155, 44);
                    if (Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].EffectList == null)
                    {
                        Console.Write("NO FCT");
                    }
                    else
                    {
                        Console.Write(Party[0].EquippedStyle.AttackList[_cursorPosX + (2 * _cursorPosY)].EffectList[0]);
                    }
                }
            }
        }

        public void SelectHoverMM(ConsoleColor color)
        {
            if  (_curSMenu == null)
            {
                if (_cursorPosY == 0)
                {
                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(8, 20);
                    Console.WriteLine("__   _   _                 _____");
                    Console.SetCursorPosition(8, 21);
                    Console.WriteLine("\\ \\ | \\ | |               |  __ \\");
                    Console.SetCursorPosition(8, 22);
                    Console.WriteLine(" \\ \\|  \\| | _____      __ | |  \\/ __ _ _ __ ___   ___");
                    Console.SetCursorPosition(8, 23);
                    Console.WriteLine("  > > . ` |/ _ \\ \\ /\\ / / | | __ / _` | '_ ` _ \\ / _ \\");
                    Console.SetCursorPosition(8, 24);
                    Console.WriteLine(" / /| |\\  |  __/\\ V  V /  | |_\\ \\ (_| | | | | | |  __/");
                    Console.SetCursorPosition(8, 25);
                    Console.WriteLine("/_/ \\_| \\_/\\___| \\_/\\_/    \\____/\\__,_|_| |_| |_|\\___|");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (_cursorPosY == 1)
                {
                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(8, 32);
                    Console.WriteLine("__   _                     _   _____");
                    Console.SetCursorPosition(8, 33);
                    Console.WriteLine("\\ \\ | |                   | | |  __ \\");
                    Console.SetCursorPosition(8, 34);
                    Console.WriteLine(" \\ \\| |     ___   __ _  __| | | |  \\/ __ _ _ __ ___   ___");
                    Console.SetCursorPosition(8, 35);
                    Console.WriteLine("  > > |    / _ \\ / _` |/ _` | | | __ / _` | '_ ` _ \\ / _ \\");
                    Console.SetCursorPosition(8, 36);
                    Console.WriteLine(" / /| |___| (_) | (_| | (_| | | |_\\ \\ (_| | | | | | |  __/");
                    Console.SetCursorPosition(8, 37);
                    Console.WriteLine("/_/ \\_____/\\___/ \\__,_|\\__,_|  \\____/\\__,_|_| |_| |_|\\___|");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (_cursorPosY == 2)
                {
                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(8, 43);
                    Console.WriteLine("__   _____     _ _");
                    Console.SetCursorPosition(8, 44);
                    Console.WriteLine("\\ \\ |  ___|   (_) |");
                    Console.SetCursorPosition(8, 45);
                    Console.WriteLine(" \\ \\| |____  ___| |_");
                    Console.SetCursorPosition(8, 46);
                    Console.WriteLine("  > >  __\\ \\/ / | __|");
                    Console.SetCursorPosition(8, 47);
                    Console.WriteLine(" / /| |___>  <| | |_");
                    Console.SetCursorPosition(8, 48);
                    Console.WriteLine("/_/ \\____/_/\\_\\_|\\__|");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            if (_curSMenu == "new")
            {
                if (_cursorPosY == 0)
                {
                    Console.SetCursorPosition(76, 22);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(">");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(104, 19);
                    Console.Write("-For those who want to focus on the");
                    Console.SetCursorPosition(104, 20);
                    Console.Write("story of the game.");

                    Console.SetCursorPosition(104, 21);
                    Console.Write("-Weak ennemies.");

                    Console.SetCursorPosition(104, 22);
                    Console.Write("-No status aliements.");

                    Console.SetCursorPosition(104, 23);
                    Console.Write("-No debuffs.");

                    Console.SetCursorPosition(104, 24);
                    Console.Write("-No switch.");

                    Console.SetCursorPosition(104, 25);
                    Console.Write("-They rarely use special moves.");

                    Console.SetCursorPosition(104, 26);
                    Console.Write("-No Leaders in REs.");
                }

                if (_cursorPosY == 1)
                {
                    Console.SetCursorPosition(76, 25);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(">");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(104, 19);
                    Console.Write("-A starter difficulty recommended for");
                    Console.SetCursorPosition(104, 20);
                    Console.Write("newcommers or casual players!");

                    Console.SetCursorPosition(104, 21);
                    Console.Write("-Negative effects and debuffs");
                    Console.SetCursorPosition(104, 22);
                    Console.Write("are quite rare and toned-down.");

                    Console.SetCursorPosition(104, 23);
                    Console.Write("-The ennemies are balanced.");

                    Console.SetCursorPosition(104, 24);
                    Console.Write("-They never switch mid fight.");

                    Console.SetCursorPosition(104, 25);
                    Console.Write("-They also rarely use special moves.");

                    Console.SetCursorPosition(104, 26);
                    Console.Write("-Leaders rarely appear in REs.");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(104, 28);
                    Console.Write("DON'T BE ASHAMED TO START HERE :)");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (_cursorPosY == 2)
                {
                    Console.SetCursorPosition(76, 28);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(">");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(104, 19);
                    Console.Write("-Real YAKUZA play on this difficulty!");

                    Console.SetCursorPosition(104, 20);
                    Console.Write("-The ennemies are stronger and more");
                    Console.SetCursorPosition(104, 21);
                    Console.Write("intelligent.");

                    Console.SetCursorPosition(104, 22);
                    Console.Write("-They frequently use debuff moves.");

                    Console.SetCursorPosition(104, 23);
                    Console.Write("-Your party gets more affected by");
                    Console.SetCursorPosition(104, 24);
                    Console.Write("status ailments.");

                    Console.SetCursorPosition(104, 25);
                    Console.Write("-The ennemies will use spe atcks.");

                    Console.SetCursorPosition(104, 26);
                    Console.Write("-The ennemies will often switch to");
                    Console.SetCursorPosition(104, 27);
                    Console.Write("a better ennemi if they have the");
                    Console.SetCursorPosition(104, 28);
                    Console.Write("type disadventage.");

                    Console.SetCursorPosition(104, 29);
                    Console.Write("-Frequent leaders in REs.");

                    Console.SetCursorPosition(104, 30);
                    Console.Write("-Will always hit super effective");
                    Console.SetCursorPosition(104, 31);
                    Console.Write("moves if possible.");
                }

                if (_cursorPosY == 3)
                {
                    Console.SetCursorPosition(76, 31);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(">");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(104, 19);
                    Console.Write("-The ennemies at their");
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    Console.Write(" HARDEST.");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.SetCursorPosition(104, 20);
                    Console.Write("-Status Effects are extremely likely");
                    Console.SetCursorPosition(104, 21);
                    Console.Write("to apply on your party.");
                    Console.SetCursorPosition(104, 22);
                    Console.Write("-The enemy AI will");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" ALWAYS ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("adapt.");

                    Console.SetCursorPosition(104, 23);
                    Console.Write("-Debuffs are emplified and more");
                    Console.SetCursorPosition(104, 24);
                    Console.Write("frequent.");

                    Console.SetCursorPosition(104, 25);
                    Console.Write("-The ennemies will use");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" MORE ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("spe atks.");

                    Console.SetCursorPosition(104, 26);
                    Console.Write("-Random encounters are even more");
                    Console.SetCursorPosition(104, 27);
                    Console.Write("likely to happen.");

                    Console.SetCursorPosition(104, 28);
                    Console.Write("-Low chance to have an extra leader");
                    Console.SetCursorPosition(104, 29);
                    Console.Write("in REs!");

                    Console.SetCursorPosition(104, 30);
                    Console.Write("-Ennemies will always try to hit");
                    Console.SetCursorPosition(104, 31);
                    Console.Write("super effect moves if possible.");
                }
            }

            if (_curSMenu == "load")
            {
                if (_cursorPosY == 0)
                {
                    Console.SetCursorPosition(76, 22);
                    Console.Write(">");
                }

                if (_cursorPosY == 1)
                {
                    Console.SetCursorPosition(76, 25);
                    Console.Write(">");
                }

                if (_cursorPosY == 2)
                {
                    Console.SetCursorPosition(76, 28);
                    Console.Write(">");
                }

                if (_cursorPosY == 3)
                {
                    Console.SetCursorPosition(76, 31);
                    Console.Write(">");
                }


            }
        }

        public void SelectOption(List<Character> Party)
        {
            //Main Fight Menu
            if (_selectMode == 0)
            {
                string sMenu;

                _prevCurX = _cursorPosX;
                _prevCurY = _cursorPosY;

                //Skills + Items
                if (_cursorPosX == 1 || _cursorPosX == 3)
                {
                    _selectMode = 2;

                    switch (_cursorPosX)
                    {
                        case 1:
                            sMenu = "skills";
                            SetSubmenu(sMenu, Party, null);
                            SelectHover(ConsoleColor.Blue, Party);
                            _curSMenu = sMenu;
                            break;

                        case 3:
                            sMenu = "items";
                            SetSubmenu(sMenu, Party, null);
                            SelectHover(ConsoleColor.Blue, Party);
                            _curSMenu = sMenu;
                            break;
                    }
                }

                //Party
                if (_cursorPosX == 2)
                {
                    _selectMode = 1;
                    sMenu = "party";
                    SetSubmenu(sMenu, Party, null);
                    SelectHover(ConsoleColor.Blue, Party);
                    _curSMenu = sMenu;
                }
            }
        }

        public void SelectOptionMM()
        {
            if (_curSMenu == "new")
            {
                switch (_cursorPosY)
                {
                    case 0:
                        _initSave = 1;
                        break;

                    case 1:
                        _initSave = 2;
                        break;

                    case 2:
                        _initSave = 3;
                        break;

                    case 3:
                        _initSave = 4;
                        break;
                }
            }

            if (_curSMenu == null)
            {
                _prevCurY = _cursorPosY;

                switch (_cursorPosY)
                {
                    case 0:
                        _curSMenu = "new";
                        SetSubmenuMM();
                        SelectHoverMM(ConsoleColor.Black);
                        break;

                    case 1:
                        _cursorPosY = 0;
                        _curSMenu = "load";
                        SetSubmenuMM();
                        SelectHoverMM(ConsoleColor.Black);
                        break;

                    case 2:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
