using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class GameState
    {
        [JsonIgnore]
        public List<Character> Party { get; private set; } = new();
        [JsonInclude]
        public List<Item>? Inventory { get; private set; } = new();
        public DateTime Time { get; private set; }
        [JsonInclude]
        public int Diff {  get; private set; }
        public DateTime TimePlayed { get; private set; }
        [JsonInclude]
        public int Money { get; private set; }
        [JsonInclude]
        public List<int> CurrentMap { get; private set; } = new();
        [JsonInclude]
        public int CurrentMapX { get; private set; }
        [JsonInclude]
        public int CurrentMapY { get; private set; }
        [JsonInclude]
        public int CurrentPosX { get; private set; }
        [JsonInclude]
        public int CurrentPosY { get; private set; }
        [JsonInclude]
        public string Char1Name { get; private set; } = null;
        [JsonInclude]
        public string Char2Name { get; private set; } = null;
        [JsonInclude]
        public string Char3Name { get; private set; } = null;
        [JsonInclude]
        public string Char4Name { get; private set; } = null;

        public GameState()
        {
            
        }

        public void Init(List<Character> party, List<Item> inventory, int diff, DateTime timePlayed, int money, List<int> currentMap)
        {
            Party = party;
            Inventory = inventory;
            TimePlayed = timePlayed;
            Money = money;
            CurrentMap = currentMap;
            Time = DateTime.Now;
            Diff = diff;
        }

        public void Update(List<Character> party, List<Item> inventory, DateTime timePlayed, int money, List<int> currentMap)
        {
            Char1Name = party[0].Name;
            if (party.Count == 2)
            {
                Char2Name = party[1].Name;
            }
            if (party.Count == 3)
            {
                Char2Name = party[1].Name;
                Char3Name = party[2].Name;
            }
            if (party.Count == 4)
            {
                Char2Name = party[1].Name;
                Char3Name = party[2].Name;
                Char4Name = party[3].Name;
            }
            Inventory = inventory;
            TimePlayed = timePlayed;
            Money = money;
            CurrentMapX = currentMap[0];
            CurrentMapY = currentMap[1];
            CurrentPosX = currentMap[2];
            CurrentPosY = currentMap[3];
            Time = DateTime.Now;
        }

        public void Save(int i)
        {
            List<int> currentMap = new List<int>() { Program.currentMapX, Program.currentMapY, GameScreen._kiryuPosX, GameScreen._kiryuPosY };
            Update(Program.Party, Program.inventory, DateTime.UtcNow, Program.money, currentMap);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true,
            };

            string fileName = "../../../Saves/Savefile" + i + ".json";
            using FileStream createStream = File.Create(fileName);
            JsonSerializer.SerializeAsync(createStream, this, options);
        }

        public void Load(int i)
        {
            string fileName = "../../../Saves/Savefile" + i + ".json";
            string jsonFile = File.ReadAllText(fileName);
            GameState tempGameState = JsonSerializer.Deserialize<GameState>(jsonFile);

            Inventory = tempGameState.Inventory;
            TimePlayed = tempGameState.TimePlayed;
            Money = tempGameState.Money;
            CurrentMap.Add(tempGameState.CurrentMapX);
            CurrentMap.Add(tempGameState.CurrentMapY);
            CurrentMap.Add(tempGameState.CurrentPosX);
            CurrentMap.Add(tempGameState.CurrentPosY);
            Time = DateTime.Now;
        }
    }
}
