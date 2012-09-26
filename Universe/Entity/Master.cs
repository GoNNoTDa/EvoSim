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
        private Thread timeLine;
        private DateTime curDate;
        private bool TimeFlowing = false;
        private int TimeInterval = 2000;
        private int TimeMinLapse = 15;
        #endregion

        #region Constructor
        public Master()
            : base(new DNA(true))
        {
        }

        public Master(DNA aDna)
            : base(new DNA(true))
        {
        }

        public Master(DNA aDna1, DNA aDna2)
            : base(new DNA(true))
        {
        }
        #endregion

        #region IDisposable
        protected override void Dispose(bool b)
        {
            this.TimeFreeze();
        }
        #endregion

        #region Time Management
        private readonly System.Object lockTime = new System.Object();

        private void TimeFlow()
        {
            while (TimeFlowing)
            {
                curDate = curDate.AddMinutes(TimeMinLapse);
                Thread.Sleep(TimeInterval);
            }
        }

        public DateTime WhatTimeIsIt()
        {
            lock (lockTime)
            {
                return curDate;
            }
        }
        #endregion

        #region MainFunction
        public void BigBang()
        {
            curDate = new DateTime(1, 1, 1, 0, 0, 0);
            ActivateTime();
        }

        public void TimeFreeze()
        {
            TimeFlowing = false;
            timeLine = null;
        }

        public void ActivateTime()
        {
            TimeFlowing = true;
            timeLine = new Thread(TimeFlow);
            timeLine.Start();
        }
        #endregion
    }
}
