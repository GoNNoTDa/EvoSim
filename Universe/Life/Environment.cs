using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Universe.Entity;
using System.Threading;

namespace Universe.Life
{
    public class Environment : LifeForm
    {
        #region iLifeForm
        public override void DoMainTask()
        {
        }
        #endregion

        #region IDisposable
        protected override void Dispose(bool b)
        {
        }
        #endregion

        #region Constructor
        public Environment()
        {
        }

        public Environment(DNA aDna)
            : base(aDna)
        {
        }

        public Environment(DNA aDna1, DNA aDna2)
            : base(aDna1, aDna2)
        {
        }
        #endregion
    }
}
