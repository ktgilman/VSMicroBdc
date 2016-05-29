using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBdc.Entities.Identity;

namespace MicroBdc.Entities.PlanBuilder
{
    public class Plan
    {
        private ICollection<Answer> _answers;

        public Guid PlanId { get; set; }
        public string PlanName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageLocation { get; set; }
        public DateTime CreationDate { get; set; }

        public Guid UserId { get; set; }

        public virtual ICollection<Answer> Answers
        {
            get { return _answers ?? (_answers = new List<Answer>()); }
            set { _answers = value; }
        }
    }
}
