using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class GameData
    {
        public static Dictionary<string, int> StatDictDefault { get; private set; } = new Dictionary<string, int>()
        {
            {"PVMax", 0},
            {"PMMax", 0},
            {"Attack", 0},
            {"Defense", 0},
            {"Magic", 0},
            {"Willpower", 0},
            {"Agility", 0},
        };
        public enum Type {FIRE = 1, ICE = 2, ELEC = 3, BLUNT = 4, MAGIC = 5, GUN = 6, BLADE = 7};
        public enum Status {BURN = 1, COLD = 2, PARA = 3, POISON = 4, BLEED = 5, DRUNK = 6, KO = 7, SLEEP = 8, FEAR = 9, DARKNESS = 10, RAGE = 11, SILENCE = 12, GOOD = 13};
        public static Character KiryuBrawl { get; private set; } = new Character("Kazuma Kiryu (Brawler)", "", new List<GameData.Type> {Type.BLUNT}, 7, 7, 3, 5, 4, 0, 0);
        public static Character KiryuRush { get; private set; } = new Character("Kazuma Kiryu (Rush)", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0);
        public static Character KiryuBeast { get; private set; } = new Character("Kazuma Kiryu (Beast)", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0);
        public static Character KiryuLegend { get; private set; } = new Character("Kazuma Kiryu (Legend)", "", new List<GameData.Type> { Type.BLUNT, Type.FIRE }, 7, 7, 3, 5, 4, 0, 0);
        public static Character Nishiki { get; private set; } = new Character("Akira Nishikiyama", "", new List<GameData.Type> { Type.ICE }, 7, 7, 3, 5, 4, 0, 0);
        public static Character Kuze { get; private set; } = new Character("Daisaku Kuze", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0);
        public static Character KuzePipe { get; private set; } = new Character("Daisaku Kuze (Pipe)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0);
        public static Character Kashiwagi { get; private set; } = new Character("Osamu Kashiwagi", "", new List<GameData.Type> { Type.MAGIC }, 7, 7, 3, 5, 4, 0, 0);
        public static Character Yoneda { get; private set; } = new Character("Yoneda", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0);
        public static Character YonedaTanto { get; private set; } = new Character("Yoneda (Tanto)", "", new List<GameData.Type> { Type.BLADE }, 7, 7, 3, 5, 4, 0, 0);
        public static Character Tachibana { get; private set; } = new Character("Tetsu Tachibana", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0);
        public static Character Oda { get; private set; } = new Character("Jun Oda", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0);
        public static Character OdaTonfa { get; private set; } = new Character("Jun Oda (Tonfa)", "", new List<GameData.Type> { Type.MAGIC }, 7, 7, 3, 5, 4, 0, 0);
        public static Character MajimaThug { get; private set; } = new Character("Goro Majima (Thug)", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0);
        public static Character MajimaSlug { get; private set; } = new Character("Goro Majima (Slugger)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0);
        public static Character MajimaBreak { get; private set; } = new Character("Goro Majima (Breaker)", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0);
        public static Character MajimaLegend { get; private set; } = new Character("Goro Majima (Legend)", "", new List<GameData.Type> { Type.BLADE, Type.ELEC }, 7, 7, 3, 5, 4, 0, 0);
        public static Character Lee { get; private set; } = new Character("Wen Hai Lee", "", new List<GameData.Type> { Type.GUN }, 7, 7, 3, 5, 4, 0, 0);
    }
}
