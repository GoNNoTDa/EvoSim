using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Universe.Life;

namespace Universe.Entity
{
    class Master : LifeForm
    {
        public Master()
            : base()
        {
        }

        public Master(DNA aDna)
            : base(aDna)
        {
        }

        public Master(DNA aDna1, DNA aDna2)
            : base(aDna1, aDna2)
        {
        }
    }
}
