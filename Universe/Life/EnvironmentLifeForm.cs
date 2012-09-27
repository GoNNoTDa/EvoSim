using System.Threading;

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
        #endregion
    }
}
