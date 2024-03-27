using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal static class GameData
    {
        public static Dictionary<string, int> StatDictDefault { get; } = new Dictionary<string, int>()
        {
            {"PV", 0},
            {"PM", 0},
            {"Attack", 0},
            {"Defense", 0},
            {"Magic", 0},
            {"Willpower", 0},
            {"Agility", 0},
        };

        public enum Type {FIRE = 1, ICE = 2, ELEC = 3, BLUNT = 4, MAGIC = 5, GUN = 6, BLADE = 7};
        public enum Status {BURN = 1, COLD = 2, PARA = 3, POISON = 4, BLEED = 5, DRUNK = 6, KO = 7, SLEEP = 8, FEAR = 9, DARKNESS = 10, RAGE = 11, SILENCE = 12, GOOD = 13};
        public enum Weight { LIGHT = 1, MEDIUM = 2, HEAVY = 3};
        public enum BodyPart { HEAD = 1, BODY = 2, FEET = 3 };
        public static Attack BasicBlunt { get; } = new Attack("Basic Blunt Attack", 0, new List<GameData.Type> { Type.BLUNT }, - 10, 0, 5, 90, null);
        public static Attack BasicBluntFire { get; } = new Attack("Basic Blunt Fire Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.FIRE }, -10, 0, 10, 90, null);
        public static Attack BasicBluntIce { get; } = new Attack("Basic Blunt Ice Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.ICE }, -10, 0, 10, 90, null);
        public static Attack BasicBluntElec { get; } = new Attack("Basic Blunt Elec Attack", 0, new List<GameData.Type> { Type.BLUNT, Type.ELEC }, -10, 0, 10, 90, null);
        public static Attack BasicMagic { get; } = new Attack("Basic Magic Attack", 0, new List<GameData.Type> { Type.MAGIC }, -10, 0, 5, 75, null);
        public static Attack BasicFire { get; } = new Attack("Basic Fire Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.FIRE }, -10, 0, 10, 75, null);
        public static Attack BasicIce { get; } = new Attack("Basic Ice Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.ICE }, -10, 0, 10, 75, null);
        public static Attack BasicElec { get; } = new Attack("Basic Elec Attack", 0, new List<GameData.Type> { Type.MAGIC, Type.ELEC }, -10, 0, 10, 75, null);
        public static Attack BasicGun { get; } = new Attack("Basic Gun Attack", 0, new List<GameData.Type> { Type.GUN }, -10, 0, 15, 60, null);
        public static Attack BasicGunFire { get; } = new Attack("Basic Gun Fire Attack", 0, new List<GameData.Type> { Type.GUN, Type.FIRE }, -10, 0, 20, 60, null);
        public static Attack BasicGunIce { get; } = new Attack("Basic Gun Ice Attack", 0, new List<GameData.Type> { Type.GUN, Type.ICE }, -10, 0, 20, 60, null);
        public static Attack BasicGunElec { get; } = new Attack("Basic Gun Elec Attack", 0, new List<GameData.Type> { Type.GUN, Type.ELEC }, -10, 0, 20, 60, null);
        public static Attack BasicBlade { get; } = new Attack("Basic Blade Attack", 0, new List<GameData.Type> { Type.BLADE }, -10, 0, 10, 90, null);
        public static Attack BasicBladeFire { get; } = new Attack("Basic Blade Fire Attack", 0, new List<GameData.Type> { Type.BLADE, Type.FIRE }, -10, 0, 15, 90, null);
        public static Attack BasicBladeIce { get; } = new Attack("Basic Blade Ice Attack", 0, new List<GameData.Type> { Type.BLADE, Type.ICE }, -10, 0, 15, 90, null);
        public static Attack BasicBladeElec { get; } = new Attack("Basic Blade Elec Attack", 0, new List<GameData.Type> { Type.BLADE, Type.ELEC }, -10, 0, 15, 90, null);
        public static List<Attack> BasicAttack { get; } = new List<Attack>() { BasicBlunt, BasicBluntFire, BasicBluntIce, BasicBluntElec, BasicMagic, BasicFire, BasicIce, BasicElec, BasicGun, BasicGunFire, BasicGunIce, BasicGunElec, BasicBlade, BasicBladeFire, BasicBladeIce, BasicBladeElec };
        public static List<Attack> KiryuBrawlAttacks { get; } = new List<Attack>();
        public static List<Attack> KiryuRushAttacks { get; } = new List<Attack>();
        public static List<Attack> KiryuBeastAttacks { get; } = new List<Attack>();
        public static List<Attack> KiryuLegendAttacks { get; } = new List<Attack>();
        public static List<Attack> NishikiAttacks { get; } = new List<Attack>();
        public static List<Attack> KuzeAttacks { get; } = new List<Attack>();
        public static List<Attack> KuzePipeAttacks { get; } = new List<Attack>();
        public static List<Attack> KashiwagiAttacks { get; } = new List<Attack>();
        public static List<Attack> YonedaAttacks { get; } = new List<Attack>();
        public static List<Attack> YonedaTantoAttacks { get; } = new List<Attack>();
        public static List<Attack> TachibanaAttacks { get; } = new List<Attack>();
        public static List<Attack> OdaAttacks { get; } = new List<Attack>();
        public static List<Attack> OdaTonfaAttacks { get; } = new List<Attack>();
        public static List<Attack> MajimaThugAttacks { get; } = new List<Attack>();
        public static List<Attack> MajimaSlugAttacks { get; } = new List<Attack>();
        public static List<Attack> MajimaBreakAttacks { get; } = new List<Attack>();
        public static List<Attack> MajimaLegendAttacks { get; } = new List<Attack>();
        public static List<Attack> LeeAttacks { get; } = new List<Attack>();
        public static List<Attack> GoonBluntAttacks { get; } = new List<Attack>();
        public static List<Attack> GoonBladeAttacks { get; } = new List<Attack>();
        public static List<Attack> GoonGunAttacks { get; } = new List<Attack>();
        public static List<Attack> BigGAttacks { get; } = new List<Attack>();
        public static List<Attack> MageAttacks { get; } = new List<Attack>();
        public static List<Attack> ArcherAttacks { get; } = new List<Attack>();
        public static List<Attack> FighterAttacks { get; } = new List<Attack>();
        public static List<Attack> WMasterAttacks { get; } = new List<Attack>();
        public static WeaponType PipesAndBatons { get; } = new WeaponType("Pipes and Batons", "", Type.BLUNT, Weight.MEDIUM);
        public static WeaponType Umbrellas { get; } = new WeaponType("Umbrellas", "", Type.MAGIC, Weight.MEDIUM);
        public static WeaponType Blackjacks { get; } = new WeaponType("Blackjacks", "", Type.BLUNT, Weight.LIGHT);
        public static WeaponType Daggers { get; } = new WeaponType("Daggers", "", Type.BLADE, Weight.LIGHT);
        public static WeaponType Knives { get; } = new WeaponType("Knives", "", Type.BLADE, Weight.LIGHT);
        public static WeaponType Broadswords { get; } = new WeaponType("Broadswords", "", Type.BLADE, Weight.MEDIUM);
        public static WeaponType StunGuns { get; } = new WeaponType("Stun Guns", "", Type.MAGIC, Weight.LIGHT);
        public static WeaponType Bats { get; } = new WeaponType("Bats", "", Type.BLUNT, Weight.MEDIUM);
        public static WeaponType GolfClubs { get; } = new WeaponType("Golf Clubs", "", Type.BLUNT, Weight.MEDIUM);
        public static WeaponType Swords { get; } = new WeaponType("Swords", "", Type.BLADE, Weight.MEDIUM);
        public static WeaponType Hammers { get; } = new WeaponType("Hammers", "", Type.BLUNT, Weight.HEAVY);
        public static WeaponType Longswords { get; } = new WeaponType("Longswords", "", Type.BLADE, Weight.HEAVY);
        public static WeaponType Staffs { get; } = new WeaponType("Staffs", "", Type.BLUNT, Weight.MEDIUM);
        public static WeaponType Spears { get; } = new WeaponType("Spears", "", Type.BLADE, Weight.HEAVY);
        public static WeaponType Shotguns { get; } = new WeaponType("Shotguns", "", Type.GUN, Weight.MEDIUM);
        public static WeaponType Knuckles { get; } = new WeaponType("Knuckles", "", Type.BLUNT, Weight.LIGHT);
        public static WeaponType BaghNakas { get; } = new WeaponType("Bagh Nakas", "", Type.BLADE, Weight.LIGHT);
        public static WeaponType Unorthodox { get; } = new WeaponType("Unorthodox", "", Type.MAGIC, Weight.LIGHT);
        public static WeaponType Launchers { get; } = new WeaponType("Launchers", "", Type.GUN, Weight.HEAVY);
        public static WeaponType Tonfas { get; } = new WeaponType("Tonfas", "", Type.BLUNT, Weight.MEDIUM);
        public static WeaponType Nunchakus { get; } = new WeaponType("Nunchakus", "", Type.BLUNT, Weight.MEDIUM);
        public static WeaponType KaliSticks { get; } = new WeaponType("Kali Sticks", "", Type.BLUNT, Weight.MEDIUM);
        public static WeaponType DualSwords { get; } = new WeaponType("Dual Swords", "", Type.BLADE, Weight.MEDIUM);
        public static WeaponType Handguns { get; } = new WeaponType("Handguns", "", Type.GUN, Weight.LIGHT);
        public static List<WeaponType> WeaponTypes { get; } = new List<WeaponType>() { PipesAndBatons, Umbrellas, Blackjacks, Daggers, Knives, Broadswords, StunGuns, Bats, GolfClubs, Swords, Hammers, Longswords, Staffs, Spears, Shotguns, Knuckles, BaghNakas, Unorthodox, Launchers, Tonfas, Nunchakus, KaliSticks, DualSwords, Handguns};
        public static List<WeaponType> LightAndMedium { get; } = new List<WeaponType>();
        public static List<WeaponType> Medium { get; } = new List<WeaponType>();
        public static List<WeaponType> Light { get; } = new List<WeaponType>();
        public static void SetWeaponList()
        {
           foreach (WeaponType weaponType in WeaponTypes)
            {
                if (weaponType.Weight == Weight.LIGHT || weaponType.Weight == Weight.MEDIUM)
                {
                    LightAndMedium.Add(weaponType);
                }
                if(weaponType.Weight == Weight.MEDIUM)
                {
                    Medium.Add(weaponType);
                }
                else if(weaponType.Weight == Weight.LIGHT)
                {
                    Light.Add(weaponType);
                }
            }
        }
        public static Weapon Unarmed { get; } = new Weapon("Unarmed", "", 0, Knuckles, null, null, 0, 0, 0, 0, 0, 0, 0);
        public static Weapon SturdyIronPipe { get; } = new Weapon("Sturdy Iron Pipe", "", 0, PipesAndBatons, null, null, 0, 0, 0, 0, 0, 0, 0);
        public static Weapon SturdyDagger { get; } = new Weapon("Sturdy Dagger", "", 0, Daggers, null, null, 0, 0, 0, 0, 0, 0, 0);
        public static Weapon SturdyTonfa { get; } = new Weapon("Sturdy Tonfa", "", 0, Tonfas, null, null, 0, 0, 0, 0, 0, 0, 0);
        public static Weapon SturdyBat { get; } = new Weapon("Sturdy Bat", "", 0, Bats, null, null, 0, 0, 0, 0, 0, 0, 0);
        public static Weapon SturdyKnife { get; } = new Weapon("Sturdy Knife", "", 0, Knives, null, null, 0, 0, 0, 0, 0, 0, 0);
        public static Character KiryuBrawl { get;} = new Character("Kazuma Kiryu (Brawler)", "", new List<GameData.Type> {Type.BLUNT}, 7, 7, 3, 5, 4, 0, 0, KiryuBrawlAttacks, LightAndMedium, null);
        public static Character KiryuRush { get;} = new Character("Kazuma Kiryu (Rush)", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, KiryuRushAttacks, new List<WeaponType> () { Knuckles, BaghNakas}, null);
        public static Character KiryuBeast { get;} = new Character("Kazuma Kiryu (Beast)", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, KiryuBeastAttacks, WeaponTypes, null);
        public static Character KiryuLegend { get;} = new Character("Kazuma Kiryu (Legend)", "", new List<GameData.Type> { Type.BLUNT, Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, KiryuLegendAttacks, LightAndMedium, null);
        public static Character Kiryu { get; } = new Character("Kazuma Kiryu", "", new List<Character>() { KiryuBrawl, KiryuRush, KiryuBeast, KiryuLegend});
        public static Character Nishiki { get;} = new Character("Akira Nishikiyama", "", new List<GameData.Type> { Type.ICE }, 7, 7, 3, 5, 4, 0, 0, NishikiAttacks, LightAndMedium, null);
        public static Character KuzeUnarmed { get;} = new Character("Daisaku Kuze (Unarmed)", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, KuzeAttacks, new List<WeaponType>() { Knuckles, BaghNakas }, null);
        public static Character KuzePipe { get;} = new Character("Daisaku Kuze (Pipe)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, KuzePipeAttacks, new List<WeaponType>() { PipesAndBatons }, SturdyIronPipe);
        public static Character Kuze { get; } = new Character("Daisaku Kuze", "", new List<Character>() { KuzeUnarmed, KuzePipe });
        public static Character Kashiwagi { get;} = new Character("Osamu Kashiwagi", "", new List<GameData.Type> { Type.MAGIC }, 7, 7, 3, 5, 4, 0, 0, KashiwagiAttacks, null, null);
        public static Character YonedaUnarmed { get;} = new Character("Yoneda (Unarmed)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, YonedaAttacks, null, null);
        public static Character YonedaTanto { get; } = new Character("Yoneda (Tanto)", "", new List<GameData.Type> { Type.BLADE }, 7, 7, 3, 5, 4, 0, 0, YonedaTantoAttacks, new List<WeaponType>() { Daggers, Knives }, SturdyDagger);
        public static Character Yoneda { get; } = new Character("Yoneda", "", new List<Character>() { YonedaUnarmed, YonedaTanto });
        public static Character Tachibana { get;} = new Character("Tetsu Tachibana", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, TachibanaAttacks,  null, null);
        public static Character OdaUnarmed { get;} = new Character("Jun Oda (Unarmed)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, OdaAttacks, null, null);
        public static Character OdaTonfa { get; } = new Character("Jun Oda (Tonfa)", "", new List<GameData.Type> { Type.MAGIC }, 7, 7, 3, 5, 4, 0, 0, OdaTonfaAttacks, new List<WeaponType>() { Tonfas }, SturdyTonfa);
        public static Character Oda { get; } = new Character("Jun Oda", "", new List<Character>() { OdaUnarmed, OdaTonfa });
        public static Character MajimaThug { get;} = new Character("Goro Majima (Thug)", "", new List<GameData.Type> { Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, MajimaThugAttacks, LightAndMedium, null);
        public static Character MajimaSlug { get; } = new Character("Goro Majima (Slugger)", "", new List<GameData.Type> { Type.BLUNT }, 7, 7, 3, 5, 4, 0, 0, MajimaSlugAttacks, Medium, SturdyBat);
        public static Character MajimaBreak { get; } = new Character("Goro Majima (Breaker)", "", new List<GameData.Type> { Type.FIRE }, 7, 7, 3, 5, 4, 0, 0, MajimaBreakAttacks, Light, null);
        public static Character MajimaLegend { get; } = new Character("Goro Majima (Legend)", "", new List<GameData.Type> { Type.BLADE, Type.ELEC }, 7, 7, 3, 5, 4, 0, 0, MajimaLegendAttacks, new List<WeaponType>() { Daggers}, SturdyDagger);
        public static Character Majima { get; } = new Character("Goro Majima", "", new List<Character>() { MajimaThug, MajimaSlug, MajimaBreak, KiryuLegend });
        public static Character Lee { get; } = new Character("Wen Hai Lee", "", new List<GameData.Type> { Type.GUN }, 7, 7, 3, 5, 4, 0, 0, LeeAttacks, new List<WeaponType>() { Knives }, SturdyKnife);
    }
}
