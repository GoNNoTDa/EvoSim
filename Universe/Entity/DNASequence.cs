using System;
using System.Collections.Generic;
using System.Linq;
using Universe.Misc;
using Universe.Life;

namespace Universe.Entity
{
    public class DNASequence
    {
        private LifeFormTypes LfType;
        public readonly Guid Id = Guid.NewGuid();
        public Dictionary<SkillTypes, Skill> SkillList = new Dictionary<SkillTypes, Skill>();

        private void Mutate(SkillTypes aSkillType, Int32 aNewValue)
        {
            if (SkillList.ContainsKey(aSkillType))
            {
                foreach (Skill sk in SkillList.Values)
                {
                    if (aSkillType == sk.Type)
                    {
                        sk.Value = aNewValue;
                        break;
                    }
                }
            }
            else
            {
                SkillList.Add(aSkillType, new Skill(aSkillType, aNewValue, 1, SkillList.Count + 1));
            }
        }

        private void LoadSkillsFromDNA(DNASequence aDna)
        {
            if (aDna != null)
            {
                int x = 0;
                foreach (Skill sk in aDna.SkillList.Values)
                {
                    SkillList.Add(sk.Type, new Skill(sk.Type, sk.Value, sk.Priority, x++));
                }
                LfType = (LifeFormTypes)GetAttribute(SkillTypes.LifeFormType);
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

        public void Mutate(SkillTypes aSkillType, Int32 aNewValue, LifeForm aLifeForm)
        {
            if ((aLifeForm.LfType == LifeFormTypes.MasterEntity) || (aLifeForm.LfType == LifeFormTypes.EnvironmentEntity))
                Mutate(aSkillType, aNewValue);
        }
    }
}
