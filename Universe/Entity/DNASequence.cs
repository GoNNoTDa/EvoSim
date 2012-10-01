using System;
using System.Collections.Generic;
using System.Linq;
using Universe.Misc;

namespace Universe.Entity
{
    public class DNASequence
    {
        private readonly LifeFormTypes LfType;
        public readonly Guid Id = Guid.NewGuid();
        public Dictionary<SkillTypes, Skill> SkillList = new Dictionary<SkillTypes, Skill>();


        private static void LoadSkillsFromDNA(DNASequence aDna)
        {
            if (aDna != null)
            {
                int x = 0;
                foreach (Skill sk in aDna.SkillList.Values)
                {
                    SkillList.Add(sk.Type, new Skill(sk.Type, sk.Value, sk.Priority, x++));
                }
                LfType = GetAttribute(SkillTypes.LifeFormType);
            }
            else
            {
                //We must stablish some pattern configs
            }
        }

        public Int32 GetAttribute(SkillTypes aSkillType)
        {
            int res = 0;
            foreach (Skill sk in SkillList.Values)
            {
                if (aSkillType == sk.Type)
                {
                    res = sk.Value;
                    break;
                }
            }
            return res;
        }


        public DNASequence(LifeFormTypes aLifeFormType)
        {
            LfType = aLifeFormType;
            LoadSkillsFromDNA(null);
        }

        public DNASequence(DNASequence aPatternDNA)
        {
            LoadSkillsFromDNA(aPatternDNA);
        }
    }
}
