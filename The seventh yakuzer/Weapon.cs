using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class Weapon
    {
        public string Name { get; private set; }
        public string Sprite { get; private set; }
        public int Rarity { get; private set; }
        public WeaponType WeaponType { get; private set; }
        public GameData.Type Type { get; private set; }
        public List<string> EffectList { get; private set; }
        public Dictionary<string, int> StatDict { get; private set; }
        Weapon(string name, string sprite, int rarity, WeaponType weapontype, GameData.Type type, List<string> effectlist, int PV, int PM, int attack, int defense, int magic, int willpower, int agility) 
        { 
            Name = name;
            Sprite = sprite;
            Rarity = rarity;
            WeaponType = weapontype;
            Type = type;
            EffectList = effectlist;
            StatDict = GameData.StatDictDefault;
            StatDict["PVMax"] = PV;
            StatDict["PMMax"] = PM;
            StatDict["Attack"] = attack;
            StatDict["Defense"] = defense;
            StatDict["Magic"] = magic;
            StatDict["Willpower"] = willpower;
            StatDict["Agility"] = agility;
        }
    }
}
