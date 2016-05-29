using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBdc.Entities.PlanBuilder;
using MicroBdc.Domain.UnitsOfWork;
using MicroBdc.Domain.Repositories.PlanBuilder;

namespace MicroBdc.Domain.AppServices.PlanBuilder
{
    public class SectionBuilder
    {
        private ISectionUnitOfWork _sectionUnitOfWork;
        private IQuestionRepository _questionRepository;
        private IChoiceRepository _choiceRepository;
        private IAnswerRepository _answerRepository;

        public SectionBuilder(ISectionUnitOfWork SectionUnitOfWork)
        {
            this._sectionUnitOfWork = SectionUnitOfWork;
            this._questionRepository = SectionUnitOfWork.QuestionRepository;
            this._choiceRepository = SectionUnitOfWork.ChoiceRepository;
            this._answerRepository = SectionUnitOfWork.AnswerRepository;
        }

        public List<QCA> GetQuestionsWithChoicesAndAnswers(int Section, Guid PlanId)
        {
            List<QCA> QuestionsWithChoicesAndAnswers = new List<QCA>();
            IEnumerable<Question> SectionQuestions = GetSectionQuestions(Section);
            foreach (var Question in SectionQuestions)
            {
                QCA QuestionChoicesAndAnswers = new QCA();
                QuestionChoicesAndAnswers.Question = Question;
                QuestionChoicesAndAnswers.Choices = GetQuestionChoices(Question.QuestionId).ToList();
                QuestionChoicesAndAnswers.Answers = GetAnswersToQuestion(Question.QuestionId, PlanId).ToList();
                QuestionsWithChoicesAndAnswers.Add(QuestionChoicesAndAnswers);
            }
            return QuestionsWithChoicesAndAnswers;
        }

        public IEnumerable<Question> GetSectionQuestions(int Section)
        {
            IEnumerable<Question> SectionQuestions = _questionRepository.GetBySection(Section);
            return SectionQuestions;
        }

        public IEnumerable<Choice> GetQuestionChoices(Guid QuestionId)
        {
            IEnumerable<Choice> QuestionChoices = _choiceRepository.GetByQuestion(QuestionId);
            return QuestionChoices;
        }

        public IEnumerable<Answer> GetAnswersToQuestion(Guid QuestionId, Guid PlanId)
        {
            IEnumerable<Answer> Answers = _answerRepository.GetAnswersByQuestion(QuestionId, PlanId);
            return Answers;
        }

        public void SaveAnswer(Answer Answer)
        {
            _answerRepository.SaveAnswer(Answer);
        }

        public void DeleteAnswer(Guid AnswerId)
        {
            _answerRepository.DeleteAnswer(AnswerId);
        }
            
    }
}
