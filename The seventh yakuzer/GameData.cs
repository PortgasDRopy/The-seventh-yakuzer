using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal static class GameData
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

        private static List<Attack> kiryuBrawlAttacks = new List<Attack>();
        private static List<Attack> kiryuRushAttacks = new List<Attack>();
        private static List<Attack> kiryuBeastAttacks = new List<Attack>();
        private static List<Attack> kiryuLegendAttacks = new List<Attack>();
        private static List<Attack> nishikiAttacks = new List<Attack>();
        private static List<Attack> kuzeAttacks = new List<Attack>();
        private static List<Attack> kuzePipeAttacks = new List<Attack>();
        private static List<Attack> kashiwagiAttacks = new List<Attack>();
        private static List<Attack> yonedaAttacks = new List<Attack>();
        private static List<Attack> yonedaTantoAttacks = new List<Attack>();
        private static List<Attack> tachibanaAttacks = new List<Attack>();
        private static List<Attack> odaAttacks = new List<Attack>();
        private static List<Attack> odaTonfaAttacks = new List<Attack>();
        private static List<Attack> majimaThugAttacks = new List<Attack>();
        private static List<Attack> majimaSlugAttacks = new List<Attack>();
        private static List<Attack> majimaBreakAttacks = new List<Attack>();
        private static List<Attack> majimaLegendAttacks = new List<Attack>();
        private static List<Attack> leeAttacks = new List<Attack>();
        public static Attack basicBlunt { get; } = new Attack("Basic Blunt Attack", 0, new List<GameData.Type> { Type.BLUNT }, 0, 0, 0, 0, null);
        public static Attack basicBluntFire { get; } = new Attack("Basic Blunt Fire Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.FIRE }, 0, 0, 0, 0, null);
        public static Attack basicBluntIce { get; } = new Attack("Basic Blunt Ice Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.ICE }, 0, 0, 0, 0, null);
        public static Attack basicBluntElec { get; } = new Attack("Basic Blunt Elec Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.ELEC }, 0, 0, 0, 0, null);
        public static Attack basicMagic { get; } = new Attack("Basic Magic Attack", 0, new List<GameData.Type> { Type.MAGIC }, 0, 0, 0, 0, null);
        public static Attack basicFire { get; } = new Attack("Basic Fire Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.FIRE }, 0, 0, 0, 0, null);
        public static Attack basicIce { get; } = new Attack("Basic Ice Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.ICE }, 0, 0, 0, 0, null);
        public static Attack basicElec { get; } = new Attack("Basic Elec Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.ELEC }, 0, 0, 0, 0, null);
        public static Attack basicGun { get; } = new Attack("Basic Gun Attack", 0, new List<GameData.Type> { Type.GUN }, 0, 0, 0, 0, null);
        public static Attack basicGunFire { get; } = new Attack("Basic Gun Fire Attack", 0, new List<GameData.Type> { Type.GUN, Type.FIRE }, 0, 0, 0, 0, null);
        public static Attack basicGunIce { get; } = new Attack("Basic Gun Ice Attack", 0, new List<GameData.Type> { Type.GUN, Type.ICE }, 0, 0, 0, 0, null);
        public static Attack basicGunElec { get; } = new Attack("Basic Gun Elec Attack", 0, new List<GameData.Type> { Type.GUN, Type.ELEC }, 0, 0, 0, 0, null);
        public static Attack basicBlade { get; } = new Attack("Basic Blade Attack", 0, new List<GameData.Type> { Type.BLADE }, 0, 0, 0, 0, null);
        public static Attack basicBladeFire { get; } = new Attack("Basic Blade Fire Attack", 0, new List<GameData.Type> { Type.BLADE, Type.FIRE }, 0, 0, 0, 0, null);
        public static Attack basicBladeIce { get; } = new Attack("Basic Blade Ice Attack", 0, new List<GameData.Type> { Type.BLADE, Type.ICE }, 0, 0, 0, 0, null);
        public static Attack basicBladeElec { get; } = new Attack("Basic Blade Elec Attack", 0, new List<GameData.Type> { Type.BLADE, Type.ELEC }, 0, 0, 0, 0, null);
        public static List<Attack> basicAttack { get; } = new List<Attack>() { basicBlunt, basicBluntFire, basicBluntIce, basicBluntElec, basicMagic, basicFire, basicIce, basicElec, basicGun, basicGunFire, basicGunIce, basicGunElec, basicBlade, basicBladeFire, basicBladeIce, basicBladeElec };
        public static Character KiryuBrawl { get;} = new Character("Kazuma Kiryu (Brawler)", "", new List<GameData.Type> {Type.BLUNT}, 7, 7, 3, 5, 4, 0, 0, kiryuBrawlAttacks);
        public static Character KiryuRush { get;} = new Character("Kazuma Kiryu (Rush)", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, kiryuRushAttacks);
        public static Character KiryuBeast { get;} = new Character("Kazuma Kiryu (Beast)", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, kiryuBeastAttacks);
        public static Character KiryuLegend { get;} = new Character("Kazuma Kiryu (Legend)", "", new List<GameData.Type> { Type.BLUNT, Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, kiryuLegendAttacks);
        public static Character Nishiki { get;} = new Character("Akira Nishikiyama", "", new List<GameData.Type> { Type.ICE }, 7, 7, 3, 5, 4, 0, 0, nishikiAttacks);
        public static Character Kuze { get;} = new Character("Daisaku Kuze", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, kuzeAttacks);
        public static Character KuzePipe { get;} = new Character("Daisaku Kuze (Pipe)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, kuzePipeAttacks);
        public static Character Kashiwagi { get;} = new Character("Osamu Kashiwagi", "", new List<GameData.Type> { Type.MAGIC }, 7, 7, 3, 5, 4, 0, 0, kashiwagiAttacks);
        public static Character Yoneda { get;} = new Character("Yoneda", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, yonedaAttacks);
        public static Character YonedaTanto { get; } = new Character("Yoneda (Tanto)", "", new List<GameData.Type> { Type.BLADE }, 7, 7, 3, 5, 4, 0, 0, yonedaTantoAttacks);
        public static Character Tachibana { get;} = new Character("Tetsu Tachibana", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, tachibanaAttacks);
        public static Character Oda { get;} = new Character("Jun Oda", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, odaAttacks);
        public static Character OdaTonfa { get;} = new Character("Jun Oda (Tonfa)", "", new List<GameData.Type> { Type.MAGIC }, 7, 7, 3, 5, 4, 0, 0, odaTonfaAttacks);
        public static Character MajimaThug { get;} = new Character("Goro Majima (Thug)", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, majimaThugAttacks);
        public static Character MajimaSlug { get; } = new Character("Goro Majima (Slugger)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, majimaSlugAttacks);
        public static Character MajimaBreak { get; } = new Character("Goro Majima (Breaker)", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, majimaBreakAttacks);
        public static Character MajimaLegend { get; } = new Character("Goro Majima (Legend)", "", new List<GameData.Type> { Type.BLADE, Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, majimaLegendAttacks);
        public static Character Lee { get; } = new Character("Wen Hai Lee", "", new List<GameData.Type> { Type.GUN }, 7, 7, 3, 5, 4, 0, 0, leeAttacks);
    }
}
