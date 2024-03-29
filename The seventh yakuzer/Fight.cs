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
        public Fight(GameState gamestate)
        {
            Randomizer = new Random();
            Party = new List<Character>();
            foreach (Character character in gamestate.Party) 
            {
                if (character.PV > 0)
                {
                    Party.Add(character);
                    character.OnKO += this.ChangeCharacter;
                }
            }
        }

        public void Init(List<Character> ennemy)
        {
            Ennemy = ennemy;
            if (Ennemy[0].EquippedStyle.StatDict["Agility"] > Party[0].EquippedStyle.StatDict["Agility"])
            {
                Turn = 1;
            }
            else if (Ennemy[0].EquippedStyle.StatDict["Agility"] < Party[0].EquippedStyle.StatDict["Agility"])
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
            if (Randomizer.Next(100) <= gs.grid[gs._kiryuPosX, gs._kiryuPosY].danger)
            {
                Ennemy = new List<Character>() { GameData.Kashiwagi };
                GameData.Kashiwagi.OnKO += this.ChangeCharacter;
                if (Ennemy[0].EquippedStyle.StatDict["Agility"] > Party[0].EquippedStyle.StatDict["Agility"])
                {
                    Turn = 1;
                }
                else if (Ennemy[0].EquippedStyle.StatDict["Agility"] < Party[0].EquippedStyle.StatDict["Agility"])
                {
                    Turn = 0;
                }
                else
                {
                    Turn = Randomizer.Next(2);
                }
                return true;
            }
            return false;
        }

        private void Kashiwagi_OnKO()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            if (Randomizer.Next(100) <= Party[0].EquippedStyle.StatDict["Agility"])
            {
                DisplayTurnInfo(" ran away ");
                System.Threading.Thread.Sleep(2000);
                GameData.Kashiwagi.PV = GameData.Kashiwagi.EquippedStyle.StatDict["PV"];
                GameData.Kashiwagi.Status = new List<GameData.Status>() { GameData.Status.GOOD };
                Program.changeMode(Program.GameModes.MAP);
            }
            else
            {
                DisplayTurnInfo(" tried to run away but failed ");
            }
            Turn = (Turn + 1) % 2;
        }

        public void BasicAttack(Character attacker, Character attacked)
        {
            if (Randomizer.Next(100) <= attacker.EquippedStyle.AttackList[0].Precision - attacked.EquippedStyle.StatDict["Agility"] + attacker.EquippedStyle.StatDict["Agility"])
            {
                DisplayTurnInfo(" attacked " + attacked.Name + " and dealt " + (attacker.EquippedStyle.StatDict["Attack"] + attacker.EquippedStyle.AttackList[0].DmgMax - attacked.EquippedStyle.StatDict["Defense"]) + " damages.");
                attacker.SetMP(attacker.EquippedStyle.AttackList[0].PMCost, this);
                attacked.SetHP(attacker.EquippedStyle.StatDict["Attack"] + attacker.EquippedStyle.AttackList[0].DmgMax - attacked.EquippedStyle.StatDict["Defense"], this);
            }
            else
            {
                DisplayTurnInfo(" missed his attack :( ");
            }
            Turn = (Turn + 1) % 2;
        }

        public void Attack(Attack attack)
        {
            if (Randomizer.Next(100) <= attack.Precision - Ennemy[0].EquippedStyle.StatDict["Agility"] + Party[0].EquippedStyle.StatDict["Agility"])
            {
                DisplayTurnInfo(" used " + attack.Name + " on " + Ennemy[0].Name + " and dealt " + (Party[0].EquippedStyle.StatDict["Magic"] + Party[0].EquippedStyle.AttackList[0].DmgMax - Ennemy[0].EquippedStyle.StatDict["Willpower"]) + " damages.");
                Party[0].SetMP(Party[0].EquippedStyle.AttackList[0].PMCost, this);
                Ennemy[0].SetHP(Party[0].EquippedStyle.StatDict["Magic"] + Party[0].EquippedStyle.AttackList[0].DmgMax - Ennemy[0].EquippedStyle.StatDict["Willpower"], this);
            }
            else
            {
                Party[0].SetMP(Party[0].EquippedStyle.AttackList[0].PMCost, this);
                DisplayTurnInfo(" missed his attack :( ");
            }
            Turn = (Turn + 1) % 2;
        }

        public void Change(Character character)
        {
            Party.Remove(character);
            Party.Insert(0, character);
        }

        public void UseItem(Item item, Character user)
        {
            item.Use(user);
            Turn = (Turn + 1) % 2;
        }

        public void ChangeCharacter()
        {

            if (Ennemy.Count != 0)
            {
                if (Ennemy[0].PV == 0)
                {
                    DisplayTurnInfo(" killed " + Ennemy[0].Name);
                    Ennemy.Remove(Ennemy[0]);
                    System.Threading.Thread.Sleep(1000);
                    if (Ennemy.Count == 0)
                    {
                        DisplayTurnInfo(" won the fight. You win !!!");
                        System.Threading.Thread.Sleep(2000);
                        GameData.Kashiwagi.PV = GameData.Kashiwagi.EquippedStyle.StatDict["PV"];
                        GameData.Kashiwagi.Status = new List<GameData.Status>() { GameData.Status.GOOD };
                        Program.changeMode(Program.GameModes.MAP);
                    }
                }
            }
            if (Party[0].PV == 0)
            {
                DisplayTurnInfo(" killed " + Party[0].Name);
                Party.Remove(Party[0]);
                System.Threading.Thread.Sleep(1000);
                if (Party.Count == 0)
                {
                    DisplayTurnInfo(" won the fight. You lost !!!");
                    Environment.Exit(0);
                }
            }
        }
        public void DisplayTurnInfo(string action)
        {
            if (Turn == 0)
            {
                Console.SetCursorPosition(21, 44);
                Console.Write("                                                                            ");
                Console.SetCursorPosition(21, 44);
                Console.Write(Party[0].Name + action);
            }
            else
            {
                Console.SetCursorPosition(21, 39);
                Console.Write("                                                                            ");
                Console.SetCursorPosition(21, 39);
                Console.Write(Ennemy[0].Name + action);
            }
        }

    }
}
