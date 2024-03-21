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

        public Item(string name, string sprite)
        {
            Name = name;
            Sprite = sprite;
        }
    }
}
