using System;
using Universe.Life;

namespace Universe.Entity
{
    public class Master : LifeForm
    {
        #region Private Atributes
        private DateTime curDate = new DateTime(1, 1, 1, 0, 0, 0);
        private int TimeInterval;
        private int TimeMinLapse;
        private Universe.Life.Environment environment;
        #endregion

        #region Constructor
        public Master()
            : base(new DNA(true))
        {
            this.TimeInterval = 2000;
            this.TimeMinLapse = 15;
            this.environment = new Universe.Life.Environment();
        }

        public Master(int aTimeInterval, int aTimeMinLapse)
            : base(new DNA(true))
        {
            this.TimeInterval = aTimeInterval;
            this.TimeMinLapse = aTimeMinLapse;
            this.environment = new Universe.Life.Environment();
        }
        #endregion

        #region IDisposable
        protected override void Dispose(bool b)
        {
            this.TimeFreeze();
            if (this.environment != null)
            {
                this.environment.Dispose();
                this.environment = null;
            }
        }
        #endregion

        #region iLifeForm
        public override void MainTask()
        {
            this.curDate = this.curDate.AddMinutes(this.TimeMinLapse);
        }

        public override int GetActionInterval()
        {
            return this.TimeInterval;
        }
        #endregion

        #region Time Management
        private readonly System.Object lockTime = new System.Object();

        public DateTime WhatTimeIsIt()
        {
            lock (this.lockTime)
            {
                return this.curDate;
            }
        }
        #endregion

        #region MainFunction
        public void TimeFreeze()
        {
            this.FinishMainTask();
        }

        public void ActivateTime()
        {
            this.BeginMainTask();
        }
        #endregion
    }
}
