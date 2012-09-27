using System;
using System.Collections.Generic;
using System.Linq;

namespace Universe.Interface
{
    public interface iLifeForm
    {
        #region Life Cycle
        void BeginMainTask();
        void DoMainTask();
        void MainTask();
        void FinishMainTask();
        #endregion

        #region Handlers
        int GetActionInterval();
        #endregion
    }
}