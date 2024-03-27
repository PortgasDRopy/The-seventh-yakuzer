﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class GameState
    {
        public List<Character> Party {  get; private set; }
        public Dictionary<string, List<Item>> Inventory { get; private set; }
        public DateTime Time { get; private set; }
        public string Diff {  get; private set; }
        public DateTime TimePlayed { get; private set; }
        public int Money { get; private set; }
        public int[,] Position { get; private set; }
        public GameState(List<Character> party, Dictionary<string, List<Item>> inventory, string diff, DateTime timePlayed, int money, int[,] position)
        {
            Party = party;
            Inventory = inventory;
            TimePlayed = timePlayed;
            Money = money;
            Position = position;
            Time = DateTime.Now;
        }
    }
}