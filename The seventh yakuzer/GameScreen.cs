using System;
using System.Collections.Generic;
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

        public int _cursorPosX;
        public int _cursorPosY;

        public struct mapGrid
        {
            public char display;
            public bool isWall;
            public bool isKiryu;
            public int tpID;
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
                Console.SetCursorPosition(Console.WindowWidth - 30, i);
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

        }

        public void InitKiryu(int x, int y)
        {
            Console.SetCursorPosition(32 + x, y);
            Console.Write("K");
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
                        Console.Write('K');
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
                            Console.Write('K');
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
                            Console.Write('K');
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
                            Console.Write('K');
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
                    Console.Write('K');
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
                        Console.Write('K');
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
                            Console.Write('K');
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
                    Console.Write('K');
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

        public void SetFightUI()
        {
            _cursorPosX = 0;
            _cursorPosY = 0;

            Console.Clear();
            StreamReader sr = new StreamReader("../../../UI/Fight.txt");

            _line = sr.ReadLine();

            for (int i = 0; i < 56; i++)
            { 

                Console.Write(_line);
                //int posX = Console.GetCursorPosition().Left - 208;
                //int posY = Console.GetCursorPosition().Top + 1;

                //if (posY != 56)
                {
                //    Console.SetCursorPosition(posX, posY);
                }

                _line = sr.ReadLine();
            }

        }
    }
}
