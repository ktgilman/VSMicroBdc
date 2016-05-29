using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBdc.Entities.PlanBuilder
{
    public class Choice
    {

        private Question _question;
        private ICollection<Answer>  _answers;

        public Guid ChoiceId { get; set; }
        public string ChoiceName { get; set; }
        public string ChoiceContent { get; set; }
        public string ChoiceType { get; set; }
        public int Placement { get; set; }
        public virtual Guid QuestionId { get; set; }

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

        public virtual ICollection<Answer> Answers
        {
            get { return _answers ?? (_answers = new List<Answer>()); }
            set { _answers = value; }
        }
    }
}
