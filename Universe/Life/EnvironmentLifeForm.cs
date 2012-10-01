using System.Threading;
using Universe.Entity;
using System.Collections.Generic;
using System;
using Universe.Misc;

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
            : base(aMaster, LifeFormTypes.EnvironmentEntity)
        {
            BeginMainTask();
        }
        public EnvironmentLifeForm(LifeForm aMaster, LifeFormTypes aLifeFormType)
            : base(aMaster, aLifeFormType)
        {
            BeginMainTask();
        }
        public EnvironmentLifeForm(LifeForm aMaster, LifeFormTypes aLifeFormType, DNASequence aDna)
            : base(aMaster, aLifeFormType, aDna)
        {
            BeginMainTask();
        }         
        #endregion
    }
}
