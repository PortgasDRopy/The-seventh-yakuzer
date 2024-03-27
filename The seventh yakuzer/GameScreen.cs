using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public struct mapGrid
        {
            public char display;
            public bool isWall;
            public bool isKiryu;
            public int tpID;
            public int danger;
        }

        public mapGrid[,] grid = new mapGrid[150,56];

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

        public void SetSpritesTab()
        {
            Console.SetCursorPosition(Console.WindowWidth - 13, 0);
            Console.Write("Party Members");

            for (int i = 0; i < 56; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 28, i);
                Console.Write("|");
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
                        grid[j, i].danger = 10;
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

        public void SetFightUI(Fight fight)
        {
            Console.Clear();
            StreamReader sr = new StreamReader("../../../UI/Fight.txt");

            _line = sr.ReadLine();

            for (int i = 0; i < 56; i++)
            {
                Console.SetCursorPosition(0, i);
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
            string curPlName = fight.Party[0].Name;
            int curPlHP = fight.Party[0].PV;
            int curPlHPM;
            fight.Party[0].StatDict.TryGetValue("PVMax", out curPlHPM);
            int curPlMP = fight.Party[0].PM;
            int curPlMPM;
            fight.Party[0].StatDict.TryGetValue("MPMax", out curPlMPM);
            string curPlStt = fight.Party[0].Status[0].ToString();

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

            SelectHover(ConsoleColor.Blue, fight.Party);
        }

        public void SetSubmenu(string sMenu, List<Character> Party)
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

                        for (int i = 0; i < Party[0].AttackList.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.SetCursorPosition(9, curX);
                                Console.Write("-");

                                if (Party[0].AttackList[i].Type.Count == 1)
                                {
                                    Console.Write(Party[0].AttackList[i].Type[0]);
                                }

                                if (Party[0].AttackList[i].Type.Count == 2)
                                {
                                    Console.Write(Party[0].AttackList[i].Type[0]);
                                    Console.Write('/');
                                    Console.Write(Party[0].AttackList[i].Type[1]);
                                }

                                Console.Write(" - ");
                                Console.Write(Party[0].AttackList[i].Name);
                            }

                            if (i % 2 == 1)
                            {
                                Console.SetCursorPosition(91, curX);
                                Console.Write("-");

                                if (Party[0].AttackList[i].Type.Count == 1)
                                {
                                    Console.Write(Party[0].AttackList[i].Type[0]);
                                }

                                if (Party[0].AttackList[i].Type.Count == 2)
                                {
                                    Console.Write(Party[0].AttackList[i].Type[0]);
                                    Console.Write('/');
                                    Console.Write(Party[0].AttackList[i].Type[1]);
                                }

                                Console.Write(" - ");
                                Console.Write(Party[0].AttackList[i].Name);

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
                            Console.Write(Party[i].Name);

                            curX += 3;
                        }

                        break;
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

            if (_selectMode == 1)
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

                if (Party[_cursorPosY].Type.Count == 2)
                {
                    Console.Write(Party[_cursorPosY].Type[0]);
                    Console.Write('/');
                    Console.Write(Party[_cursorPosY].Type[1]);
                }

                if (Party[_cursorPosY].Type.Count == 1)
                {
                    Console.Write(Party[_cursorPosY].Type[0]);
                }

                Console.SetCursorPosition(155, 39);
                Console.Write("          ");
                Console.SetCursorPosition(155, 39);
                Console.Write(Party[_cursorPosY].PV);
                Console.Write('/');
                int curPlHPM;
                Party[0].StatDict.TryGetValue("PVMax", out curPlHPM);
                Console.Write(curPlHPM);
                Console.Write(" HP");

                Console.SetCursorPosition(155, 40);
                Console.Write("          ");
                Console.SetCursorPosition(155, 40);
                Console.Write(Party[_cursorPosY].PM);
                Console.Write('/');
                int curPlMPM;
                Party[0].StatDict.TryGetValue("PMMax", out curPlMPM);
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
                Console.Write(Party[_cursorPosY].Status[0].ToString());

                //Attacks
                Console.SetCursorPosition(179, 36);
                Console.Write("Attacks:");

                int loopNb = 0;
                int curX = 38;

                for (int i = 0; Party[_cursorPosY].AttackList.Count > i; i++)
                {
                    Console.SetCursorPosition(179, curX);
                    Console.Write("                       ");
                    Console.SetCursorPosition(179, curX);
                    Console.Write(Party[_cursorPosY].AttackList[i].Name);
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

            if (_selectMode == 2)
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
                    Console.Write(Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].Name);

                    Console.SetCursorPosition(155, 40);
                    Console.Write("                         ");
                    Console.SetCursorPosition(155, 40);

                    if (Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].Type.Count == 2)
                    {
                        Console.Write(Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].Type[0]);
                        Console.Write('/');
                        Console.Write(Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].Type[1]);
                    }

                    if (Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].Type.Count == 1)
                    {
                        Console.Write(Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].Type[0]);
                    }

                    Console.SetCursorPosition(155, 41);
                    Console.Write("                         ");
                    Console.SetCursorPosition(155, 41);
                    Console.Write(Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].PMCost);
                    Console.Write(" MP");

                    Console.SetCursorPosition(155, 42);
                    Console.Write("                         ");
                    Console.SetCursorPosition(155, 42);
                    Console.Write(Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].DmgMin);
                    Console.Write(" - ");
                    Console.Write(Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].DmgMax);
                    Console.Write(" DMG");

                    Console.SetCursorPosition(155, 43);
                    Console.Write("                         ");
                    Console.SetCursorPosition(155, 43);
                    Console.Write(Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].Precision);
                    Console.Write(" PRC");

                    Console.SetCursorPosition(155, 44);
                    Console.Write("                         ");
                    Console.SetCursorPosition(155, 44);
                    if (Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].EffectList == null)
                    {
                        Console.Write("NO FCT");
                    }
                    else
                    {
                        Console.Write(Party[0].AttackList[_cursorPosX + (2 * _cursorPosY)].EffectList[0]);
                    }
                }
            }
        }

        public void SelectOption(Fight fight)
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
                            SetSubmenu(sMenu, fight.Party);
                            SelectHover(ConsoleColor.Blue, fight.Party);
                            _curSMenu = sMenu;
                            break;

                        case 3:
                            sMenu = "items";
                            SetSubmenu(sMenu, fight.Party);
                            SelectHover(ConsoleColor.Blue, fight.Party);
                            _curSMenu = sMenu;
                            break;
                    }
                }

                //Party
                if (_cursorPosX == 0)
                {
                    if (fight.BasicAttack())
                    {
                        fight.Ennemy[0].PV -= fight.Party[0].EquippedStyle.AttackList[0].DmgMax;
                        fight.Party[0].PM -= fight.Party[0].EquippedStyle.AttackList[0].PMCost;
                    }
                }
                if (_cursorPosX == 2)
                {
                    _selectMode = 1;
                    sMenu = "party";
                    SetSubmenu(sMenu, fight.Party);
                    SelectHover(ConsoleColor.Blue, fight.Party);
                    _curSMenu = sMenu;
                }

                if (_cursorPosX == 4)
                {
                    if (fight.Run())
                    {
                        Program.changeMode(Program.GameModes.MAP, fight);
                    }
                }
            }
        }
    }
}
