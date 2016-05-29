using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBdc.Entities.PlanBuilder
{
    public class QCA
    {
        public virtual Question Question { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
