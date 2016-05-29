using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MicroBdc.Domain.Repositories.PlanBuilder;
using MicroBdc.Entities.PlanBuilder;
using MicroBdc.Data.EntityFramework.Context;

namespace MicroBdc.Data.EntityFramework.Repositories.PlanBuilder
{
    public class ChoiceRepository: IChoiceRepository
    {
        private PlanBuilderDbContext _context;

        public ChoiceRepository(PlanBuilderDbContext Context)
        {
            _context = Context;
        }

        public IEnumerable<Choice> GetByQuestion(Guid QuestionId)
        {
            IEnumerable<Choice> Choices = from x in _context.Choices
                                            where x.QuestionId == QuestionId
                                            orderby x.Placement
                                            select x;
            return Choices;
        }
    }
}
