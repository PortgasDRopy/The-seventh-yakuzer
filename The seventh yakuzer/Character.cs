using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_seventh_yakuzer;

namespace The_seventh_yakuzer
{
    internal class Character
    {
        public string Name { get; private set; }
        public string Sprite { get; private set; }
        public List<GameData.Type> Type { get; private set; }
        public int Experience { get; private set; }
        public int Level { get; private set; }
        public int PV { get; private set; }
        public int PM { get; private set; }
        public List<GameData.Status> Status { get; private set; }
        public Dictionary<string, int> StatDict { get; private set; }
        public List<Attack> AttackList { get; private set; }

        public Character(string name, string sprite, List<GameData.Type> type, int PV, int PM, int attack, int defense, int magic, int willpower, int agility, List<Attack> attackList)
        {
            Name = name;
            Sprite = sprite;
            Type = type;
            StatDict = GameData.StatDictDefault;
            StatDict["PVMax"] = PV;
            StatDict["PMMax"] = PM;
            StatDict["Attack"] = attack;
            StatDict["Defense"] = defense;
            StatDict["Magic"] = magic;
            StatDict["Willpower"] = willpower;
            StatDict["Agility"] = agility;
            Experience = 0;
            Level = 1;
            PV = StatDict["PVMax"];
            PM = StatDict["PMMax"];
            Status = new List<GameData.Status>() { GameData.Status.GOOD };
            AttackList = attackList;
        }
    }
}