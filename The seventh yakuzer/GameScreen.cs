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

        string line;
        char[] _char = new char[148];

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
            line = sr.ReadLine();

            for (int i = 0; i < 56; i++)
            {
                Console.Write(line);
                int posX = Console.GetCursorPosition().Left - 150;
                int posY = Console.GetCursorPosition().Top + 1;

                if (posY != 56)
                {
                    Console.SetCursorPosition(posX, posY);
                }

                line = sr.ReadLine();
            }

        }

        public void InitKiryu(int x, int y)
        {
            Console.SetCursorPosition(Console.BufferWidth - 30 - x, Console.BufferHeight - y);
            Console.Write("K");
        }

        public void MoveCharacter(string dir)
        {
            int cLPos = Console.CursorLeft;
            int cTPos = Console.CursorTop;

            switch (dir) 
            { 
                case "Up":
                    Console.SetCursorPosition(cLPos - 1, cTPos - 2);
                    
                    if (Console.ReadLine()[(cLPos - 1) * (cTPos - 2)] == '\0')
                    {
                        Console.SetCursorPosition(cLPos - 1, cTPos);
                        Console.Write(' ');
                        Console.SetCursorPosition(cLPos - 1, cTPos - 2);
                        Console.Write('K');
                    }
                    
                    break;

                case "Down":
                    Console.SetCursorPosition(cLPos - 1, cTPos);
                    Console.Write(' ');
                    Console.SetCursorPosition(cLPos - 1, cTPos + 2);
                    Console.Write('K');
                    break;

                case "Left":
                    Console.SetCursorPosition(cLPos - 2, cTPos);
                    if (Console.ReadKey(true).KeyChar == '\0')
                    {
                        Console.SetCursorPosition(cLPos - 1, cTPos);
                        Console.Write(' ');
                        Console.SetCursorPosition(cLPos - 4, cTPos);
                        Console.Write('K');
                    }
                    
                    break;

                case "Right":
                    Console.SetCursorPosition(cLPos - 1, cTPos);
                    Console.Write(' ');
                    Console.SetCursorPosition(cLPos + 2, cTPos);
                    Console.Write('K');
                    break;
            }
        }
    }
}
