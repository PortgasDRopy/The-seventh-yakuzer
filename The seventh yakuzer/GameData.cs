using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal static class GameData
    {
        public static Dictionary<string, int> StatDictDefault { get; } = new Dictionary<string, int>()
        {
            {"PVMax", 0},
            {"PMMax", 0},
            {"Attack", 0},
            {"Defense", 0},
            {"Magic", 0},
            {"Willpower", 0},
            {"Agility", 0},
        };
        public enum Type { FIRE = 1, ICE = 2, ELEC = 3, BLUNT = 4, MAGIC = 5, GUN = 6, BLADE = 7 };
        public enum Status { BURN = 1, COLD = 2, PARA = 3, POISON = 4, BLEED = 5, DRUNK = 6, KO = 7, SLEEP = 8, FEAR = 9, DARKNESS = 10, RAGE = 11, SILENCE = 12, GOOD = 13 };
        public static Attack BasicBlunt { get; } = new Attack("Basic Blunt Attack", 0, new List<GameData.Type> { Type.BLUNT }, 0, 0, 0, 0, null);
        public static Attack BasicBluntFire { get; } = new Attack("Basic Blunt Fire Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.FIRE }, 0, 0, 0, 0, null);
        public static Attack BasicBluntIce { get; } = new Attack("Basic Blunt Ice Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.ICE }, 0, 0, 0, 0, null);
        public static Attack BasicBluntElec { get; } = new Attack("Basic Blunt Elec Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.ELEC }, 0, 0, 0, 0, null);
        public static Attack BasicMagic { get; } = new Attack("Basic Magic Attack", 0, new List<GameData.Type> { Type.MAGIC }, 0, 0, 0, 0, null);
        public static Attack BasicFire { get; } = new Attack("Basic Fire Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.FIRE }, 0, 0, 0, 0, null);
        public static Attack BasicIce { get; } = new Attack("Basic Ice Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.ICE }, 0, 0, 0, 0, null);
        public static Attack BasicElec { get; } = new Attack("Basic Elec Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.ELEC }, 0, 0, 0, 0, null);
        public static Attack BasicGun { get; } = new Attack("Basic Gun Attack", 0, new List<GameData.Type> { Type.GUN }, 0, 0, 0, 0, null);
        public static Attack BasicGunFire { get; } = new Attack("Basic Gun Fire Attack", 0, new List<GameData.Type> { Type.GUN, Type.FIRE }, 0, 0, 0, 0, null);
        public static Attack BasicGunIce { get; } = new Attack("Basic Gun Ice Attack", 0, new List<GameData.Type> { Type.GUN, Type.ICE }, 0, 0, 0, 0, null);
        public static Attack BasicGunElec { get; } = new Attack("Basic Gun Elec Attack", 0, new List<GameData.Type> { Type.GUN, Type.ELEC }, 0, 0, 0, 0, null);
        public static Attack BasicBlade { get; } = new Attack("Basic Blade Attack", 0, new List<GameData.Type> { Type.BLADE }, 0, 0, 0, 0, null);
        public static Attack BasicBladeFire { get; } = new Attack("Basic Blade Fire Attack", 0, new List<GameData.Type> { Type.BLADE, Type.FIRE }, 0, 0, 0, 0, null);
        public static Attack BasicBladeIce { get; } = new Attack("Basic Blade Ice Attack", 0, new List<GameData.Type> { Type.BLADE, Type.ICE }, 0, 0, 0, 0, null);
        public static Attack BasicBladeElec { get; } = new Attack("Basic Blade Elec Attack", 0, new List<GameData.Type> { Type.BLADE, Type.ELEC }, 0, 0, 0, 0, null);
        public static List<Attack> BasicAttack { get; } = new List<Attack>() { BasicBlunt, BasicBluntFire, BasicBluntIce, BasicBluntElec, BasicMagic, BasicFire, BasicIce, BasicElec, BasicGun, BasicGunFire, BasicGunIce, BasicGunElec, BasicBlade, BasicBladeFire, BasicBladeIce, BasicBladeElec };
        public static List<Attack> KiryuBrawlAttacks = new List<Attack>() { BasicBlunt, BasicBluntFire, BasicBluntIce };
        public static List<Attack> KiryuRushAttacks = new List<Attack>();
        public static List<Attack> KiryuBeastAttacks = new List<Attack>();
        public static List<Attack> KiryuLegendAttacks = new List<Attack>();
        public static List<Attack> NishikiAttacks = new List<Attack>() { BasicBluntElec, BasicMagic };
        public static List<Attack> KuzeAttacks = new List<Attack>() { BasicIce, BasicElec, BasicGun, BasicGunFire, BasicGunIce, BasicGunElec, BasicBlade, BasicBladeFire, BasicBladeIce, BasicBladeElec };
        public static List<Attack> KuzePipeAttacks = new List<Attack>();
        public static List<Attack> KashiwagiAttacks = new List<Attack>();
        public static List<Attack> YonedaAttacks = new List<Attack>();
        public static List<Attack> YonedaTantoAttacks = new List<Attack>();
        public static List<Attack> TachibanaAttacks = new List<Attack>();
        public static List<Attack> OdaAttacks = new List<Attack>();
        public static List<Attack> OdaTonfaAttacks = new List<Attack>();
        public static List<Attack> MajimaThugAttacks = new List<Attack>();
        public static List<Attack> MajimaSlugAttacks = new List<Attack>();
        public static List<Attack> MajimaBreakAttacks = new List<Attack>();
        public static List<Attack> MajimaLegendAttacks = new List<Attack>();
        public static List<Attack> LeeAttacks = new List<Attack>();
        public static Character KiryuBrawl { get;} = new Character("Kazuma Kiryu (Brawler)", "", new List<GameData.Type> {Type.BLUNT}, 7, 7, 3, 5, 4, 0, 0, KiryuBrawlAttacks);
        public static Character KiryuRush { get;} = new Character("Kazuma Kiryu (Rush)", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, KiryuRushAttacks);
        public static Character KiryuBeast { get;} = new Character("Kazuma Kiryu (Beast)", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, KiryuBeastAttacks);
        public static Character KiryuLegend { get;} = new Character("Kazuma Kiryu (Legend)", "", new List<GameData.Type> { Type.BLUNT, Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, KiryuLegendAttacks);
        public static Character Nishiki { get;} = new Character("Akira Nishikiyama", "", new List<GameData.Type> { Type.ICE }, 7, 7, 3, 5, 4, 0, 0, NishikiAttacks);
        public static Character Kuze { get;} = new Character("Daisaku Kuze", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, KuzeAttacks);
        public static Character KuzePipe { get;} = new Character("Daisaku Kuze (Pipe)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, KuzePipeAttacks);
        public static Character Kashiwagi { get;} = new Character("Osamu Kashiwagi", "", new List<GameData.Type> { Type.MAGIC }, 7, 7, 3, 5, 4, 0, 0, KashiwagiAttacks);
        public static Character Yoneda { get;} = new Character("Yoneda", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, YonedaAttacks);
        public static Character YonedaTanto { get; } = new Character("Yoneda (Tanto)", "", new List<GameData.Type> { Type.BLADE }, 7, 7, 3, 5, 4, 0, 0, YonedaTantoAttacks);
        public static Character Tachibana { get;} = new Character("Tetsu Tachibana", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, TachibanaAttacks);
        public static Character Oda { get;} = new Character("Jun Oda", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, OdaAttacks);
        public static Character OdaTonfa { get;} = new Character("Jun Oda (Tonfa)", "", new List<GameData.Type> { Type.MAGIC }, 7, 7, 3, 5, 4, 0, 0, OdaTonfaAttacks);
        public static Character MajimaThug { get;} = new Character("Goro Majima (Thug)", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, MajimaThugAttacks);
        public static Character MajimaSlug { get; } = new Character("Goro Majima (Slugger)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, MajimaSlugAttacks);
        public static Character MajimaBreak { get; } = new Character("Goro Majima (Breaker)", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, MajimaBreakAttacks);
        public static Character MajimaLegend { get; } = new Character("Goro Majima (Legend)", "", new List<GameData.Type> { Type.BLADE, Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, MajimaLegendAttacks);
        public static Character Lee { get; } = new Character("Wen Hai Lee", "", new List<GameData.Type> { Type.GUN }, 7, 7, 3, 5, 4, 0, 0, LeeAttacks);

        //public List<Character> Party = new List<Character>() { KiryuBrawl, Nishiki, Kuze }; 
    }
}
