using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBdc.Domain.Repositories.PlanBuilder;

namespace MicroBdc.Domain.UnitsOfWork
{
    public interface ISectionUnitOfWork: IDisposable
    {
        IQuestionRepository QuestionRepository { get; }

        IChoiceRepository ChoiceRepository { get; }

        IAnswerRepository AnswerRepository { get; }

    }
}
