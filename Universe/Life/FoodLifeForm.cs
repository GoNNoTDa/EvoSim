using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Universe.Entity;

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
        public FoodLifeForm(LifeForm aMaster, DNA aDna)
            : base(aMaster, aDna)
        {
            
        }
        public FoodLifeForm(LifeForm aMaster, DNA aDna1, DNA aDna2)
            : base(aMaster, aDna1, aDna2)
        {
            
        }
         
        #endregion
    }
}
