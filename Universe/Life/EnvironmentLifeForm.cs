using System.Threading;
using Universe.Entity;

namespace Universe.Life
{
    public class EnvironmentLifeForm : LifeForm
    {
        #region iLifeForm
        public override void MainTask()
        {
            Thread.Sleep(0);
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
