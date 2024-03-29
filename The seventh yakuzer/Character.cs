using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class Character
    {
        public string Name { get; private set; }
        [JsonIgnore]
        public string Sprite { get; private set; }
        [JsonIgnore]
        public List<GameData.Type>? Type { get; private set; }
        public int Experience { get; private set; }
        public int Level { get; private set; }
        public int PV { get; set; }
        public int PM { get; set; }
        public List<GameData.Status> Status { get; private set; }
        [JsonIgnore]
        public Dictionary<string, int>? StatDict { get; private set; }
        [JsonIgnore]
        public List<Attack>? AttackList { get; private set; }
        [JsonIgnore]
        public Weapon EquippedWeapon { get; private set; }
        [JsonIgnore]
        public List<WeaponType>? PossibleWeapon {  get; private set; }
        [JsonIgnore]
        public List<Character>? StyleList { get; private set; }
        [JsonIgnore]
        public Character EquippedStyle { get; private set; }
        [JsonIgnore]
        public List<Armor> EquippedArmor { get; private set; }
        [JsonIgnore]
        public List<Gear> EquippedGears { get; private set; }
        public Character(string name, string sprite, List<GameData.Type> type, int pv, int pm, int attack, int defense, int magic, int willpower, int agility, List<Attack> attackList, List<WeaponType>? possibleWeapon, Weapon? defaultWeapon)
        {
            Name = name;
            Sprite = sprite;
            Type = type;
            StatDict = GameData.StatDictDefault;
            StatDict["PV"] = pv;
            StatDict["PM"] = pm;
            StatDict["Attack"] = attack;
            StatDict["Defense"] = defense;
            StatDict["Magic"] = magic;
            StatDict["Willpower"] = willpower;
            StatDict["Agility"] = agility;
            Experience = 0;
            Level = 1;
            PV = StatDict["PV"];
            PM = StatDict["PM"];
            Status = new List<GameData.Status>() {GameData.Status.GOOD};
            AttackList = attackList;
            StyleList = null;
            EquippedStyle = this;
            PossibleWeapon = possibleWeapon;
            if (defaultWeapon == null)
            {
                EquippedWeapon = GameData.Unarmed;
            }
            else
            {
                EquippedWeapon = defaultWeapon;
            }
            EquippedArmor = new List<Armor>();
            EquippedGears = new List<Gear>();
        }

        public Character(string name, string sprite, List<Character> styleList)
        {
            Name = name;
            Sprite = sprite;
            StyleList = styleList;
            EquippedStyle = StyleList[0];
            Status = new List<GameData.Status>() { GameData.Status.GOOD };
            PV = EquippedStyle.StatDict["PV"];
            PM = EquippedStyle.StatDict["PM"];
            Experience = 0;
            Level = 1;
            EquippedArmor = new List<Armor>();
            EquippedGears = new List<Gear>();
            EquippedWeapon = EquippedStyle.EquippedWeapon;
        }

        public void LevelUp()
        {
            Level += 1;
            foreach (var stat in EquippedStyle.StatDict)
            {
                StatDict[stat.Key] += 1;
            }
        }
    }
}