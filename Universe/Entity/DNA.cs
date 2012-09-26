using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe.Entity
{
    public class DNA
    {
        private bool _IsMaster;
        private Guid _Id = Guid.NewGuid();
        //private List<Skill> _Skills;


        private void LoadSkillsFromDNA()
        {
        }

        public DNA()
        {
            this.LoadSkillsFromDNA();
        }

        public DNA(bool aIsMaster) : this()
        {
            this._IsMaster = aIsMaster;
        }
    }
}
