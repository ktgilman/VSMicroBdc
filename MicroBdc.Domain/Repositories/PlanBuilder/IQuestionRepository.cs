using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBdc.Entities.PlanBuilder;

namespace MicroBdc.Domain.Repositories.PlanBuilder
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetBySection(int Section);
    }
}
