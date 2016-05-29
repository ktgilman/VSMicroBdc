using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBdc.Domain.Repositories.PlanBuilder;
using MicroBdc.Data.EntityFramework.Context;
using MicroBdc.Entities.PlanBuilder;

namespace MicroBdc.Data.EntityFramework.Repositories.PlanBuilder
{
    public class AnswerRepository: IAnswerRepository
    {
        private PlanBuilderDbContext _context;

        public AnswerRepository(PlanBuilderDbContext Context)
        {
            _context = Context;
        }

        public IEnumerable<Answer> GetAnswersByQuestion(Guid QuestionId, Guid PlanId)
        {
            IEnumerable<Answer> Answers = from x in _context.Answers
                                           where x.QuestionId == QuestionId && x.PlanId == PlanId
                                           select x;

            return Answers;
        }

        public void SaveAnswer(Answer Answer)
        {
            IEnumerable<Answer> OldAnswer = from x in _context.Answers
                                         where x.AnswerId == Answer.AnswerId
                                         select x;
            if (OldAnswer.Any())
            {
                OldAnswer.First().AnswerContent = Answer.AnswerContent;
                OldAnswer.First().ChoiceId = Answer.ChoiceId;
            }
            else
            {
                _context.Answers.Add(Answer);
            }

            _context.SaveChanges();

        }

        public void DeleteAnswer(Guid AnswerId)
        {
            var AnswerToDelete = (from x in _context.Answers
                                  where x.AnswerId == AnswerId
                                  select x).FirstOrDefault();
            if (AnswerToDelete != null)
            {
                _context.Answers.Remove(AnswerToDelete);
            }

            _context.SaveChanges();
        }
    }
}
