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
        public int Experience { get; set; }
        public int Level { get; set; }
        public int PV { get; set; }
        public int PM { get; set; }
        public List<GameData.Status> Status { get; set; }
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
            StatDict = new Dictionary<string, int>();
            foreach (string key in GameData.StatDictDefault.Keys)
            {
                StatDict[key] = GameData.StatDictDefault[key];
            }
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
        public event Action OnChangeHP;
        public event Action OnKO;
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

        public void SetHP(int hpModifier, Fight fight)
        {
            if (PV - hpModifier <= 0)
            {
                PV = 0;
                Status = new List<GameData.Status>() { GameData.Status.KO };
                Program.gs.UpdateFightUI(fight);
                OnKO?.Invoke();
            }
            else if (PV - hpModifier > EquippedStyle.StatDict["PV"])
            {
                PV = EquippedStyle.StatDict["PV"];
                Program.gs.UpdateFightUI(fight);
            } 
            else
            {
                PV -= hpModifier;
                Program.gs.UpdateFightUI(fight);
                OnChangeHP?.Invoke();
            }
        }
        public void SetMP(int mpModifier, Fight fight) 
        {
            if (PM - mpModifier <= 0)
            {
                PM = 0;
                Program.gs.UpdateFightUI(fight);
            }
            else if (PM - mpModifier >= EquippedStyle.StatDict["PM"])
            {
                PM = EquippedStyle.StatDict["PM"];
                Program.gs.UpdateFightUI(fight);
            }
            else
            {
                PM -= mpModifier;
                Program.gs.UpdateFightUI(fight);
            }
        }
    }
}