using System;
using System.Collections.Generic;
using System.Linq;
using Universe.Misc;

namespace Universe.Entity
{
    public class Skill
    {
        #region Public Attributes
        public SkillTypes Type;
        public Int32 Value;
        public Int32 Priority;
        public Int32 Order;
        #endregion

        #region Constructor
        public Skill(SkillTypes aSkill, Int32 aValue, Int32 aPriority, Int32 aOrder)
        {
            Type = aSkill;
            Value = aValue;
            Priority = aPriority;
            Order = aOrder;
        }
        #endregion
    }
}
