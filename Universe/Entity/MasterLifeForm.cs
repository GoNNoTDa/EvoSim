using System;
using Universe.Life;

namespace Universe.Entity
{
    public class MasterLifeForm : LifeForm
    {
        #region Private Atributes
        private DateTime curDate = new DateTime(1, 1, 1, 0, 0, 0);
        private readonly int TimeInterval;
        private readonly int TimeMinLapse;
        private EnvironmentLifeForm environment;
        #endregion

        #region Constructor
        public MasterLifeForm()
            : base(null, new DNA(true))
        {
            TimeInterval = 2000;
            TimeMinLapse = 15;
            environment = new EnvironmentLifeForm(this);
        }

        public MasterLifeForm(int aTimeInterval, int aTimeMinLapse)
            : base(null, new DNA(true))
        {
            TimeInterval = aTimeInterval;
            TimeMinLapse = aTimeMinLapse;
            environment = new EnvironmentLifeForm(this);
        }
        public MasterLifeForm(LifeForm aMaster)
            : base(aMaster)
        {
            
        }
        public MasterLifeForm(LifeForm aMaster, DNA aDna)
            : base(aMaster, aDna)
        {
            
        }
        public MasterLifeForm(LifeForm aMaster, DNA aDna1, DNA aDna2)
            : base(aMaster, aDna1, aDna2)
        {
            
        }
         
        #endregion

        #region IDisposable
        protected override void Dispose(bool b)
        {
            TimeFreeze();
            if (environment != null)
            {
                environment.Dispose();
                environment = null;
            }
        }
        #endregion

        #region iLifeForm
        public override void MainTask()
        {
            curDate = curDate.AddMinutes(TimeMinLapse);
        }

        public override int GetActionInterval()
        {
            return TimeInterval;
        }

        public override void ManageMasterNotification(NotificationType aNotifyType, LifeForm aLifeForm)
        {
            //FINAL RELEASE
        }
        #endregion

        #region Time Management
        private readonly Object lockTime = new Object();

        public DateTime WhatTimeIsIt()
        {
            lock (lockTime)
            {
                return curDate;
            }
        }
        #endregion

        #region MainFunction
        public void TimeFreeze()
        {
            FinishMainTask();
        }

        public void ActivateTime()
        {
            BeginMainTask();
        }
        #endregion
    }
}
