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
            :base(name, "", new List<GameData.Type> { GameData.Type.BLUNT }, 0, 0, 0, 0, 0, 0, 0, GameData.GoonBluntAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }

    internal class GoonBlade : Character
    {   
        public GoonBlade(string name, int level)
            :base(name, "", new List<GameData.Type> { GameData.Type.BLADE }, 0, 0, 0, 0, 0, 0, 0, GameData.GoonBladeAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class GoonGun : Character
    {
        public GoonGun(string name, int level)
            : base(name, "", new List<GameData.Type> { GameData.Type.GUN, GameData.Type.MAGIC }, 0, 0, 0, 0, 0, 0, 0, GameData.GoonGunAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class BigG : Character
    {
        public BigG(string name, int level)
            : base(name, "", new List<GameData.Type> { GameData.Type.ICE, GameData.Type.GUN }, 0, 0, 0, 0, 0, 0, 0, GameData.BigGAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class Mage : Character
    {
        public Mage(string name, int level)
            :base(name, "", new List<GameData.Type> { GameData.Type.MAGIC, GameData.Type.ELEC }, 0, 0, 0, 0, 0, 0, 0, GameData.MageAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class Archer : Character
    {
        public Archer(string name, int level)
            : base(name, "", new List<GameData.Type> { GameData.Type.GUN, GameData.Type.FIRE }, 0, 0, 0, 0, 0, 0, 0, GameData.ArcherAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class Fighter : Character
    {
        public Fighter(string name, int level)
            : base(name, "", new List<GameData.Type> { GameData.Type.BLUNT, GameData.Type.ICE }, 0, 0, 0, 0, 0, 0, 0, GameData.FighterAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
    internal class WMaster : Character
    {
        public WMaster(string name, int level)
            : base(name, "", new List<GameData.Type> { GameData.Type.GUN, GameData.Type.BLADE }, 0, 0, 0, 0, 0, 0, 0, GameData.WMasterAttacks, null, null)
        {
            for (int i = 1; i < level; i++) { LevelUp(); }
        }
    }
}
