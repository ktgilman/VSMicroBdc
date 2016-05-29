using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBdc.Domain.Repositories.PlanBuilder;
using MicroBdc.Domain.UnitsOfWork;
using MicroBdc.Data.EntityFramework.Context;
using MicroBdc.Data.EntityFramework.Repositories.PlanBuilder;

namespace MicroBdc.Data.EntityFramework.UnitsOfWork
{
    public class SectionUnitOfWork: ISectionUnitOfWork
    {
        private readonly PlanBuilderDbContext _context;
        private IQuestionRepository _questionRepository;
        private IChoiceRepository _choiceRepository;
        private IAnswerRepository _answerRepository;

        public SectionUnitOfWork()
        {
            _context = new PlanBuilderDbContext();
        }

        public IQuestionRepository QuestionRepository
        {
            get { return _questionRepository ?? (_questionRepository = new QuestionRepository()); }
        }

        public IChoiceRepository ChoiceRepository
        {
            get { return _choiceRepository ?? (_choiceRepository = new ChoiceRepository(_context)); }
        }

        public IAnswerRepository AnswerRepository
        {
            get { return _answerRepository ?? (_answerRepository = new AnswerRepository(_context)); }
        }



        public void Dispose()
        {
            _questionRepository = null;
            _context.Dispose();
        }
    }
}
