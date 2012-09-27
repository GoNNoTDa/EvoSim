using System.Threading;
using Universe.Entity;
using System.Collections.Generic;
using System;

namespace Universe.Life
{
    public class EnvironmentLifeForm : LifeForm
    {
        #region Private Attribute
        private Dictionary<Guid, LifeForm> ManagedOnes = new Dictionary<Guid, LifeForm>();
        #endregion

        #region iLifeForm
        public override void MainTask()
        {
            Thread.Sleep(0);
        }

        public override void ManageMasterNotification(NotificationType aNotifyType, LifeForm aLifeForm)
        {
            if (ManagedOnes.ContainsValue(aLifeForm))
                ManagedOnes.Remove(aLifeForm.dna.Id);
        }

        public override void NotifyMasterLifeForm(NotificationType aNotifyType, LifeForm aLifeForm)
        {
            if (NotificationType.Dead == aNotifyType)
                ManageMasterNotification(aNotifyType, aLifeForm);
            base.NotifyMasterLifeForm(aNotifyType, aLifeForm);
        }
        #endregion

        #region Constructor
        public EnvironmentLifeForm(LifeForm aMaster)
            : base(aMaster)
        {
        }
        public EnvironmentLifeForm(LifeForm aMaster, DNA aDna)
            : base(aMaster, aDna)
        {
            
        }
        public EnvironmentLifeForm(LifeForm aMaster, DNA aDna1, DNA aDna2)
            : base(aMaster, aDna1, aDna2)
        {
            
        }
         
        #endregion
    }
}
