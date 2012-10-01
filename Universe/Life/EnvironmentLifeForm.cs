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
        private Int32 MaxUnits;
        #endregion

        #region iLifeForm
        public override void MainTask()
        {
            Thread.Sleep(0);
        }

        public override void ManageMasterNotification(NotificationType aNotifyType, LifeForm aLifeForm)
        {
            switch (aNotifyType)
            {
                case Life.NotificationType.Born:
                    if (!ManagedOnes.ContainsValue(aLifeForm))
                        ManagedOnes.Add(aLifeForm.dna.Id, aLifeForm);
                    break;
                case Life.NotificationType.Dead:
                    if (ManagedOnes.ContainsValue(aLifeForm))
                        ManagedOnes.Remove(aLifeForm.dna.Id);
                    break;
            }
        }

        public override void NotifyMasterLifeForm(NotificationType aNotifyType, LifeForm aLifeForm)
        {
            ManageMasterNotification(aNotifyType, aLifeForm);
            base.NotifyMasterLifeForm(aNotifyType, aLifeForm);
        }
        #endregion

        #region Constructor
        public EnvironmentLifeForm(LifeForm aMaster)
            : base(aMaster)
        {
        }
        public EnvironmentLifeForm(LifeForm aMaster, DNASequence aDna)
            : base(aMaster, aDna)
        {
            
        }
        public EnvironmentLifeForm(LifeForm aMaster, DNASequence aDna1, DNASequence aDna2)
            : base(aMaster, aDna1, aDna2)
        {
            
        }
         
        #endregion
    }
}
