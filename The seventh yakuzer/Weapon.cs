using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class Weapon : Item
    {
        public int Rarity { get; private set; }
        public WeaponType WeaponType { get; private set; }
        public GameData.Type? Type { get; private set; }
        public Dictionary<string, int> StatDict { get; private set; }
        public Weapon(string name, string sprite, int rarity, WeaponType weapontype, GameData.Type? type, List<string>? effectList, int PV, int PM, int attack, int defense, int magic, int willpower, int agility)
            : base(name, sprite, effectList)
        { 
            Rarity = rarity;
            WeaponType = weapontype;
            Type = type;
            StatDict = GameData.StatDictDefault;
            StatDict["PV"] = PV;
            StatDict["PM"] = PM;
            StatDict["Attack"] = attack;
            StatDict["Defense"] = defense;
            StatDict["Magic"] = magic;
            StatDict["Willpower"] = willpower;
            StatDict["Agility"] = agility;
        }
    }
}
