using System;
using System.Collections.Generic;
using System.Linq;

namespace Universe.Entity
{
    public class Skill
    {
        #region Public Attributes
        public String Name;
        public Int32 Value;
        public Int32 Priority;
        #endregion

        #region Constructor
        public Skill(String aName, Int32 aValue, Int32 aPriority)
        {
            Name = aName;
            Value = aValue;
            Priority = aPriority;
        }
        #endregion
    }
}
