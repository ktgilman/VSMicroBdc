using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBdc.Entities.PlanBuilder;

namespace MicroBdc.Domain.Repositories.PlanBuilder
{
    public interface IChoiceRepository
    {
        IEnumerable<Choice> GetByQuestion(Guid QuestionId);
    }
}
