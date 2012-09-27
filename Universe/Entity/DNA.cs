using System;
using System.Collections.Generic;
using System.Linq;

namespace Universe.Entity
{
    public class DNA
    {
        private readonly bool _IsMaster;
        public readonly Guid Id = Guid.NewGuid();
        //private List<Skill> _Skills;


        private static void LoadSkillsFromDNA()
        {
            //
        }

        public DNA()
        {
            LoadSkillsFromDNA();
        }

        public DNA(bool aIsMaster) : this()
        {
            _IsMaster = aIsMaster;
        }
    }
}
