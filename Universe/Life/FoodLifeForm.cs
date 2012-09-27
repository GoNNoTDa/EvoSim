using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Universe.Life
{
    class FoodLifeForm : LifeForm
    {
        #region iLifeForm
        public override void MainTask()
        {
            Thread.Sleep(0);
        }
        #endregion

        #region Constructor
        public FoodLifeForm(LifeForm aMaster)
            : base(aMaster)
        {
        }
        #endregion
    }
}
