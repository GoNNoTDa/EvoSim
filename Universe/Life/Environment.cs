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
        public override void MainTask()
        {
            Thread.Sleep(0);
        }
        #endregion

        #region Constructor
        public Environment()
        {
        }
        #endregion
    }
}
