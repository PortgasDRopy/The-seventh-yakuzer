using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class GoonBlunt
    {
        public Character Char { get; private set; }
        public GoonBlunt(string name, int level)
        {
            Char = new Character(name, "", new List<GameData.Type> { GameData.Type.BLUNT }, 0, 0, 0, 0, 0, 0, 0, GameData.GoonBluntAttacks);
            for (int i = 1; i < level; i++) { Char.LevelUp(); }
        }
    }

    internal class GoonBlade
    {
        public Character Char { get; private set; }
        public GoonBlade(string name, int level)
        {
            Char = new Character(name, "", new List<GameData.Type> { GameData.Type.BLADE }, 0, 0, 0, 0, 0, 0, 0, GameData.GoonBladeAttacks);
            for (int i = 1; i < level; i++) { Char.LevelUp(); }
        }
    }
    internal class GoonGun
    {
        public Character Char { get; private set; }
        public GoonGun(string name, int level)
        {
            Char = new Character(name, "", new List<GameData.Type> { GameData.Type.GUN, GameData.Type.MAGIC }, 0, 0, 0, 0, 0, 0, 0, GameData.GoonGunAttacks);
            for (int i = 1; i < level; i++) { Char.LevelUp(); }
        }
    }
    internal class BigG
    {
        public Character Char { get; private set; }
        public BigG(string name, int level)
        {
            Char = new Character(name, "", new List<GameData.Type> { GameData.Type.ICE, GameData.Type.GUN }, 0, 0, 0, 0, 0, 0, 0, GameData.BigGAttacks);
            for (int i = 1; i < level; i++) { Char.LevelUp(); }
        }
    }
    internal class Mage
    {
        public Character Char { get; private set; }
        public Mage(string name, int level)
        {
            Char = new Character(name, "", new List<GameData.Type> { GameData.Type.MAGIC, GameData.Type.ELEC }, 0, 0, 0, 0, 0, 0, 0, GameData.MageAttacks);
            for (int i = 1; i < level; i++) { Char.LevelUp(); }
        }
    }
    internal class Archer
    {
        public Character Char { get; private set; }
        public Archer(string name, int level)
        {
            Char = new Character(name, "", new List<GameData.Type> { GameData.Type.GUN, GameData.Type.FIRE }, 0, 0, 0, 0, 0, 0, 0, GameData.ArcherAttacks);
            for (int i = 1; i < level; i++) { Char.LevelUp(); }
        }
    }
    internal class Fighter
    {
        public Character Char { get; private set; }
        public Fighter(string name, int level)
        {
            Char = new Character(name, "", new List<GameData.Type> { GameData.Type.BLUNT, GameData.Type.ICE }, 0, 0, 0, 0, 0, 0, 0, GameData.FighterAttacks);
            for (int i = 1; i < level; i++) { Char.LevelUp(); }
        }
    }
    internal class WMaster
    {
        public Character Char { get; private set; }
        public WMaster(string name, int level)
        {
            Char = new Character(name, "", new List<GameData.Type> { GameData.Type.GUN, GameData.Type.BLADE }, 0, 0, 0, 0, 0, 0, 0, GameData.WMasterAttacks);
            for (int i = 1; i < level; i++) { Char.LevelUp(); }
        }
    }
}
