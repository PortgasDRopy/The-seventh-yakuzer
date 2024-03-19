using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal static class GameData
    {
        private static Dictionary<string, int> StatDictDefault { get; } = new Dictionary<string, int>()
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
        private static Attack basicBlunt { get; } = new Attack("Basic Blunt Attack", 0, new List<GameData.Type> { Type.BLUNT }, 0, 0, 0, 0, null);
        private static Attack basicBluntFire { get; } = new Attack("Basic Blunt Fire Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.FIRE }, 0, 0, 0, 0, null);
        private static Attack basicBluntIce { get; } = new Attack("Basic Blunt Ice Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.ICE }, 0, 0, 0, 0, null);
        private static Attack basicBluntElec { get; } = new Attack("Basic Blunt Elec Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.ELEC }, 0, 0, 0, 0, null);
        private static Attack basicMagic { get; } = new Attack("Basic Magic Attack", 0, new List<GameData.Type> { Type.MAGIC }, 0, 0, 0, 0, null);
        private static Attack basicFire { get; } = new Attack("Basic Fire Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.FIRE }, 0, 0, 0, 0, null);
        private static Attack basicIce { get; } = new Attack("Basic Ice Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.ICE }, 0, 0, 0, 0, null);
        private static Attack basicElec { get; } = new Attack("Basic Elec Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.ELEC }, 0, 0, 0, 0, null);
        private static Attack basicGun { get; } = new Attack("Basic Gun Attack", 0, new List<GameData.Type> { Type.GUN }, 0, 0, 0, 0, null);
        private static Attack basicGunFire { get; } = new Attack("Basic Gun Fire Attack", 0, new List<GameData.Type> { Type.GUN, Type.FIRE }, 0, 0, 0, 0, null);
        private static Attack basicGunIce { get; } = new Attack("Basic Gun Ice Attack", 0, new List<GameData.Type> { Type.GUN, Type.ICE }, 0, 0, 0, 0, null);
        private static Attack basicGunElec { get; } = new Attack("Basic Gun Elec Attack", 0, new List<GameData.Type> { Type.GUN, Type.ELEC }, 0, 0, 0, 0, null);
        private static Attack basicBlade { get; } = new Attack("Basic Blade Attack", 0, new List<GameData.Type> { Type.BLADE }, 0, 0, 0, 0, null);
        private static Attack basicBladeFire { get; } = new Attack("Basic Blade Fire Attack", 0, new List<GameData.Type> { Type.BLADE, Type.FIRE }, 0, 0, 0, 0, null);
        private static Attack basicBladeIce { get; } = new Attack("Basic Blade Ice Attack", 0, new List<GameData.Type> { Type.BLADE, Type.ICE }, 0, 0, 0, 0, null);
        private static Attack basicBladeElec { get; } = new Attack("Basic Blade Elec Attack", 0, new List<GameData.Type> { Type.BLADE, Type.ELEC }, 0, 0, 0, 0, null);
        private static List<Attack> basicAttack { get; } = new List<Attack>() { basicBlunt, basicBluntFire, basicBluntIce, basicBluntElec, basicMagic, basicFire, basicIce, basicElec, basicGun, basicGunFire, basicGunIce, basicGunElec, basicBlade, basicBladeFire, basicBladeIce, basicBladeElec };
        private static Character KiryuBrawl { get;} = new Character("Kazuma Kiryu (Brawler)", "", new List<GameData.Type> {Type.BLUNT}, 7, 7, 3, 5, 4, 0, 0, kiryuBrawlAttacks);
        private static Character KiryuRush { get;} = new Character("Kazuma Kiryu (Rush)", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, kiryuRushAttacks);
        private static Character KiryuBeast { get;} = new Character("Kazuma Kiryu (Beast)", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, kiryuBeastAttacks);
        private static Character KiryuLegend { get;} = new Character("Kazuma Kiryu (Legend)", "", new List<GameData.Type> { Type.BLUNT, Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, kiryuLegendAttacks);
        private static Character Nishiki { get;} = new Character("Akira Nishikiyama", "", new List<GameData.Type> { Type.ICE }, 7, 7, 3, 5, 4, 0, 0, nishikiAttacks);
        private static Character Kuze { get;} = new Character("Daisaku Kuze", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, kuzeAttacks);
        private static Character KuzePipe { get;} = new Character("Daisaku Kuze (Pipe)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, kuzePipeAttacks);
        private static Character Kashiwagi { get;} = new Character("Osamu Kashiwagi", "", new List<GameData.Type> { Type.MAGIC }, 7, 7, 3, 5, 4, 0, 0, kashiwagiAttacks);
        private static Character Yoneda { get;} = new Character("Yoneda", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, yonedaAttacks);
        private static Character YonedaTanto { get; } = new Character("Yoneda (Tanto)", "", new List<GameData.Type> { Type.BLADE }, 7, 7, 3, 5, 4, 0, 0, yonedaTantoAttacks);
        private static Character Tachibana { get;} = new Character("Tetsu Tachibana", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, tachibanaAttacks);
        private static Character Oda { get;} = new Character("Jun Oda", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, odaAttacks);
        private static Character OdaTonfa { get;} = new Character("Jun Oda (Tonfa)", "", new List<GameData.Type> { Type.MAGIC }, 7, 7, 3, 5, 4, 0, 0, odaTonfaAttacks);
        private static Character MajimaThug { get;} = new Character("Goro Majima (Thug)", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, majimaThugAttacks);
        private static Character MajimaSlug { get; } = new Character("Goro Majima (Slugger)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, majimaSlugAttacks);
        private static Character MajimaBreak { get; } = new Character("Goro Majima (Breaker)", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, majimaBreakAttacks);
        private static Character MajimaLegend { get; } = new Character("Goro Majima (Legend)", "", new List<GameData.Type> { Type.BLADE, Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, majimaLegendAttacks);
        private static Character Lee { get; } = new Character("Wen Hai Lee", "", new List<GameData.Type> { Type.GUN }, 7, 7, 3, 5, 4, 0, 0, leeAttacks);
    }
}
