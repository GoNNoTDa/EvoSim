using System;
using System.Collections.Generic;
using System.Linq;
using Universe.Life;
using Universe.Entity;
using Universe.Misc;

namespace Universe.Interface
{
    public interface iLifeForm
    {
        #region Life Cycle
        void BeginMainTask();
        void DoMainTask();
        void MainTask();
        void FinishMainTask();
        void Dead();
        void NotifyMasterLifeForm(NotificationType aNotifyType, LifeForm aLifeForm);
        #endregion

        #region Handlers
        void ManageMasterNotification(NotificationType aNotifyType, LifeForm aLifeForm);
        Int32 GetAttribute(SkillTypes aSkill);
        #endregion
    }
}