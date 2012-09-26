using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Universe.Interface
{
    public interface iLifeForm
    {
        #region Life Cycle
        void BeginMainTask();
        void DoMainTask();
        void FinishMainTask();
        #endregion
    }
}