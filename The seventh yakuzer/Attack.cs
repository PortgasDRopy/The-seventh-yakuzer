using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_seventh_yakuzer
{
    internal class Attack
    {
        public string Name { get; private set; }
        public int RequiredLevel { get; private set; }  
        public List<GameData.Type> Type {  get; private set; }
        public int PMCost { get; private set; }
        public int DmgMin {  get; private set; }
        public int DmgMax {  get; private set; }
        public int Precision {  get; private set; }
        public List<string>? EffectList {  get; private set; }

        public Attack(string name, int requiredLevel, List<GameData.Type> type, int pMCost, int dmgMin, int dmgMax, int precision, List<string>? effectList)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Type = type;
            PMCost = pMCost;
            DmgMin = dmgMin;
            DmgMax = dmgMax;
            Precision = precision;
            EffectList = effectList;
        }
    }
}
