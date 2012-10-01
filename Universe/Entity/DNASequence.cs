using System;
using System.Collections.Generic;
using System.Linq;
using Universe.Misc;

namespace Universe.Entity
{
    public class DNASequence
    {
        private readonly LifeFormTypes Type;
        public readonly Guid Id = Guid.NewGuid();
        //private List<Skill> _Skills;


        private static void LoadSkillsFromDNA(DNASequence aDna)
        {
            //
        }

        public DNASequence(LifeFormTypes aLifeFormType)
        {
            Type = aLifeFormType;
            LoadSkillsFromDNA(null);
        }

        public DNASequence(LifeFormTypes aLifeFormType, DNASequence aPatternDNA)
        {
            Type = aLifeFormType;
            LoadSkillsFromDNA(aPatternDNA);
        }
    }
}
