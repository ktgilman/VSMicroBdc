using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBdc.Data.EntityFramework.Repositories.PlanBuilder;

namespace MicroBdc.AppServices.PlanBuilder
{
    public class SectionBuilder
    {
        private QuestionRepository _questionRepo;
        private int _section;

        public SectionBuilder(int Section)
        {
            _questionRepo = new QuestionRepository();
            _section = Section;
        }

        public List<QCAndA> GetSectionInfo()
        {

        }
    }
}
