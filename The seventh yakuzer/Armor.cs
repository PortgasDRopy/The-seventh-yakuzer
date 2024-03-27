using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class Armor : Item
    {
        public int Rarity { get; private set; }
        public GameData.BodyPart BodyPart { get; private set; }
        public List<string> EffectList { get; private set; }
        public Dictionary<string, int> StatDict { get; private set; }
        public Armor(string name, string sprite, int rarity, GameData.BodyPart bodyPart, List<string> effectList, int PV, int PM, int attack, int defense, int magic, int willpower, int agility)
            : base (name, sprite)
        {
            Rarity = rarity;
            BodyPart = bodyPart;
            EffectList = effectList;
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
