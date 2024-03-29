using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class GoonBlunt : Character
    {
        public GoonBlunt(string name, int level)
            :base(name, "", new List<GameData.Type> { GameData.Type.BLUNT }, 20, 10, 3, 2, 1, 1, 1, GameData.GoonBluntAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }

    internal class GoonBlade : Character
    {   
        public GoonBlade(string name, int level)
            :base(name, "", new List<GameData.Type> { GameData.Type.BLADE }, 10, 20, 4, 1, 6, 3, 3, GameData.GoonBladeAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class GoonGun : Character
    {
        public GoonGun(string name, int level)
            : base(name, "", new List<GameData.Type> { GameData.Type.GUN, GameData.Type.MAGIC }, 20, 20, 5, 1, 5, 1, 2, GameData.GoonGunAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class BigG : Character
    {
        public BigG(string name, int level)
            : base(name, "", new List<GameData.Type> { GameData.Type.ICE, GameData.Type.GUN }, 30, 10, 5, 5, 2, 3, 1, GameData.BigGAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class Mage : Character
    {
        public Mage(string name, int level)
            :base(name, "", new List<GameData.Type> { GameData.Type.MAGIC, GameData.Type.ELEC }, 10, 50, 1, 1, 7, 5, 3, GameData.MageAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class Archer : Character
    {
        public Archer(string name, int level)
            : base(name, "", new List<GameData.Type> { GameData.Type.GUN, GameData.Type.FIRE }, 10, 30, 4, 2, 2, 3, 2, GameData.ArcherAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class Fighter : Character
    {
        public Fighter(string name, int level)
            : base(name, "", new List<GameData.Type> { GameData.Type.BLUNT, GameData.Type.ICE }, 30, 10, 5, 5, 3, 3, 3, GameData.FighterAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class WMaster : Character
    {
        public WMaster(string name, int level)
            : base(name, "", new List<GameData.Type> { GameData.Type.GUN, GameData.Type.BLADE }, 10, 10, 8, 3, 8, 3, 5, GameData.WMasterAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
}
