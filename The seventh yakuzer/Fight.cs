using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class Fight
    {
        public List<Character> Ennemy {get; private set;}
        public Random Randomizer {get; private set;}
        public int Turn { get; private set;}
        public List<Character> Party { get; private set;}
        public Fight(List<Character> ennemy, List<Character> party)
        {
            Ennemy = ennemy;
            Randomizer = new Random();
            Party = party;
            if (ennemy[0].EquippedStyle.StatDict["Agility"] > party[0].EquippedStyle.StatDict["Agility"])
            {
                Turn = 1;
            }
            else if (ennemy[0].EquippedStyle.StatDict["Agility"] < party[0].EquippedStyle.StatDict["Agility"])
            {
                Turn = 0;
            }
            else
            {
                Turn = Randomizer.Next(2);
            }
        }
        public bool IsEnnemy(GameScreen gs)
        {
            if (Randomizer.Next(101) <= gs.grid[gs._kiryuPosX, gs._kiryuPosY].danger)
            {
                return true;
            }
            return false;
        }

        public bool Run()
        {
            if (Randomizer.Next(101) <= Party[0].EquippedStyle.StatDict["Agility"])
            {
                return true;
            }
            Turn = (Turn + 1) % 2;
            return false;
        }

        public bool BasicAttack()
        {
            if (Randomizer.Next(101) <= Party[0].EquippedStyle.AttackList[0].Precision - Ennemy[0].EquippedStyle.StatDict["Agility"] + Party[0].EquippedStyle.StatDict["Agility"])
            {
                Turn = (Turn + 1) % 2;
                return true;
            }
            Turn = (Turn + 1) % 2;
            return false;
        }

        public bool Attack(Attack attack)
        {
            if (Randomizer.Next(101) <= attack.Precision - Ennemy[0].EquippedStyle.StatDict["Agility"] + Party[0].EquippedStyle.StatDict["Agility"])
            {
                Turn = (Turn + 1) % 2;
                return true;
            }
            Turn = (Turn + 1) % 2;
            return false;
        }

        public void UseItem(Item item, Character user)
        {
            item.Use(user);
            Turn = (Turn + 1) % 2;
        }
    }
}
