using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class Item
    {
        public string Name { get; protected set; }
        public string Sprite { get; protected set; }
        public List<string> EffectList { get; private set; }
        public Item(string name, string sprite, List<string> effectList)
        {
            Name = name;
            Sprite = sprite;
            EffectList = effectList;
        }

        public void Use(Character user)
        {
            foreach (string effect in EffectList)
            {
                
            }
        }
    }
}
