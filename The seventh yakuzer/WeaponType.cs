using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class WeaponType
    {
        public string Name {  get; private set; }
        public string Sprite { get; private set; }
        public GameData.Type Type { get; private set; }
        public GameData.Weight Weight { get; private set; }
        public WeaponType(string name, string sprite, GameData.Type type, GameData.Weight weight)
        {
            Name = name;
            Sprite = sprite;
            Type = type;
            Weight = weight;
        }
    }
}
