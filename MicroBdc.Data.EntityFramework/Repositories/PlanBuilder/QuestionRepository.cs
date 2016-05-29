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
    public class QuestionRepository: IQuestionRepository
    {

        private PlanBuilderDbContext _context;

        public QuestionRepository()
        {
            _context = new PlanBuilderDbContext();
        }

        public IEnumerable<Question> GetBySection(int Section)
        {
            IEnumerable<Question> Questions = from x in _context.Questions
                                               where x.Section == Section
                                               orderby x.Placement
                                               select x;

            return Questions;
        }
    }
}
