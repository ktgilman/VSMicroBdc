using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBdc.Entities.PlanBuilder
{
    public class Question
    {

        private ICollection<Choice> _choices;
        private ICollection<Answer> _answers;


        public Guid QuestionId {get; set;}
        public string QuestionName { get; set; }
        public string QuestionContent { get; set; }
        public string ChoiceType { get; set; }
            /* R - Radio;
             * H - Horizontal Radio;
             * C - Checkbox;
             * I - Horizontal Checkbox;
             * S - Select;
             * F - Freeform;
             */
        public int Section { get; set; }
            /* 1 - Initial
             * 2 - Industry
             * 3 - Customer
             * 4 - Etc.
             */
        public int Placement { get; set; }
        public string ChoiceSource { get; set; }
        public string VideoAidUrl { get; set; }

        public virtual ICollection<Choice> Choices
        {
            get { return _choices ?? (_choices = new List<Choice>()); }
            set { _choices = value; }
        }

        public virtual ICollection<Answer> Answers
        {
            get { return _answers ?? (_answers = new List<Answer>()); }
            set { _answers = value; }
        }
    }
}
