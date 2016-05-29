using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBdc.Entities.PlanBuilder
{
    public class Wizard
    {
        public virtual Plan Plan { get; set; }

        public virtual ICollection<QCA> QCAs { get; set; }
    }
}
