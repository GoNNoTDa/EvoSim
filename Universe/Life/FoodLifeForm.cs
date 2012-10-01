using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Universe.Entity;

namespace Universe.Life
{
    class FoodLifeForm : LifeForm
    {
        #region Public Attributes
        public virtual int FeedMe(int aMaxFoodValue)
        {
            lock (lockFood)
            {
                FoodValue -= aMaxFoodValue;
                if (FoodValue <= 0)
                    Dead();
                return (FoodValue <= 0) ? FoodValue + aMaxFoodValue : aMaxFoodValue;
            }
        }
        #endregion

        #region Private Attributes
        private readonly Object lockFood = new Object();
        private int FoodValue;
        #endregion

        #region iLifeForm
        public override void MainTask()
        {
            int max = GetMaxFood();
            FoodValue += GetFoodGenRate();
            if (FoodValue > max)
                FoodValue = max;
        }

        public override void Dead()
        {
            base.Dead();
        }
        #endregion

        #region FoodLifeForm
        protected virtual int GetFoodGenRate()
        {
            return 500;
        }

        protected virtual int GetMaxFood()
        {
            return 10000;
        }
        #endregion

        #region Constructor
        public FoodLifeForm(LifeForm aMaster)
            : base(aMaster)
        {
            FoodValue = 0;
        }
        public FoodLifeForm(LifeForm aMaster, DNASequence aDna)
            : base(aMaster, aDna)
        {
            FoodValue = 0;
        }
        public FoodLifeForm(LifeForm aMaster, DNASequence aDna1, DNASequence aDna2)
            : base(aMaster, aDna1, aDna2)
        {
            FoodValue = 0;
        }
         
        #endregion
    }
}
