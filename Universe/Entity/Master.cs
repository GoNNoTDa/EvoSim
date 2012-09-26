using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Universe.Life;
using System.Threading;

namespace Universe.Entity
{
    public class Master : LifeForm
    {
        #region Private Atributes
        private DateTime curDate = new DateTime(1, 1, 1, 0, 0, 0);
        private int TimeInterval;
        private int TimeMinLapse;
        #endregion

        #region Constructor
        public Master()
            : base(new DNA(true))
        {
            this.TimeInterval = 2000;
            this.TimeMinLapse = 15;
        }

        public Master(int aTimeInterval, int aTimeMinLapse)
            : base(new DNA(true))
        {
            this.TimeInterval = aTimeInterval;
            this.TimeMinLapse = aTimeMinLapse;
        }
        #endregion

        #region IDisposable
        protected override void Dispose(bool b)
        {
            this.TimeFreeze();
        }
        #endregion

        #region iLifeForm
        public override void MainTask()
        {
            this.curDate = this.curDate.AddMinutes(this.TimeMinLapse);
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
