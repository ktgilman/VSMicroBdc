using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBdc.Entities.PlanBuilder;

namespace MicroBdc.Domain.Repositories.PlanBuilder
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAnswersByQuestion(Guid QuestionId, Guid PlanId);

        void SaveAnswer(Answer Answer);

        void DeleteAnswer(Guid AnswerId);
    }
}
