using System;
using Universe.Life;
using System.Collections;
using System.Collections.Generic;
using Universe.Misc;

namespace Universe.Entity
{
    public class MasterLifeForm : LifeForm
    {
        #region Private Atributes
        private DateTime curDate = new DateTime(1, 1, 1, 0, 0, 0);
        private readonly int TimeInterval;
        private readonly int TimeMinLapse;
        private EnvironmentLifeForm environment;
        private Dictionary<Guid, LifeForm> LivingOnes = new Dictionary<Guid,LifeForm>();
        private Dictionary<Guid, LifeForm> DeadOnes = new Dictionary<Guid, LifeForm>();
        #endregion

        #region Public Attributes
        public ArrayList ListAllLivingOnes
        {
            get
            {
                ArrayList newList = new ArrayList();
                foreach (LifeForm lf in LivingOnes.Values)
                    newList.Add(lf);
                return newList;
            }
        }
        #endregion

        #region Constructor
        public MasterLifeForm()
            : base(null, LifeFormTypes.MasterEntity, null)
        {
            TimeInterval = 2000;
            TimeMinLapse = 15;
            environment = new EnvironmentLifeForm(this);
        }

        public MasterLifeForm(int aTimeInterval, int aTimeMinLapse)
            : base(null, LifeFormTypes.MasterEntity, null)
        {
            TimeInterval = aTimeInterval;
            TimeMinLapse = aTimeMinLapse;
            environment = new EnvironmentLifeForm(this);
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
            switch (aNotifyType)
            {
                case Life.NotificationType.Born:
                    if (!LivingOnes.ContainsValue(aLifeForm))
                        LivingOnes.Add(aLifeForm.dna.Id, aLifeForm);
                    break;
                case Life.NotificationType.Dead:
                    if (LivingOnes.ContainsValue(aLifeForm))
                    {
                        LivingOnes.Remove(aLifeForm.dna.Id);
                        DeadOnes.Add(aLifeForm.dna.Id, aLifeForm);
                    }
                    break;
            }
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
