using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBdc.Entities.PlanBuilder
{
    public class Answer
    {
        private Question _question;
        private Choice _choice;
        private Plan _plan;

        public Guid AnswerId { get; set; }
        public string AnswerName { get; set; }
        public string AnswerContent { get; set; }
        public string AnswerVariable { get; set; }
        public virtual Guid QuestionId { get; set; }
        public virtual Guid ChoiceId { get; set; }
        public virtual Guid PlanId { get; set; }


        public virtual Question Question
        {
            get { return _question; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _question = value;
                QuestionId = value.QuestionId;
            }
        }

        public virtual Choice Choice
        {
            get { return _choice; }
            set
            {
                _choice = value;
                ChoiceId = value.ChoiceId;
            }
        }

        public virtual Plan Plan
        {
            get { return _plan; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _plan = value;
                PlanId = value.PlanId;
            }
        }

    }
}
