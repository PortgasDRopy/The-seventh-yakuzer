﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class Character
    {
        public string Name { get; private set; }
        public string Sprite { get; private set; }
        public List<GameData.Type>? Type { get; private set; }
        public int Experience { get; private set; }
        public int Level { get; private set; }
        public int PV { get; private set; }
        public int PM { get; private set; }
        public List<GameData.Status> Status { get; private set; }
        public Dictionary<string, int>? StatDict { get; private set; }
        public List<Attack>? AttackList { get; private set; }
        public Weapon EquippedWeapon { get; private set; }
        public List<WeaponType>? PossibleWeapon {  get; private set; }
        public List<Character>? StyleList { get; private set; }
        public Character EquippedStyle { get; private set; }
        public List<Armor> EquippedArmor { get; private set; }
        public List<Gear> EquippedGears { get; private set; }
        public Character(string name, string sprite, List<GameData.Type> type, int PV, int PM, int attack, int defense, int magic, int willpower, int agility, List<Attack> attackList, List<WeaponType>? possibleWeapon, Weapon? defaultWeapon)
        {
            Name = name;
            Sprite = sprite;
            Type = type;
            StatDict = GameData.StatDictDefault;
            StatDict["PV"] = PV;
            StatDict["PM"] = PM;
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
            Status = new List<GameData.Status>();
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