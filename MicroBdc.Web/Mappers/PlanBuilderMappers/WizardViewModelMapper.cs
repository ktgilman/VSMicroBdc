using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MicroBdc.Entities.PlanBuilder;
using MicroBdc.Web.Models;

namespace MicroBdc.Web.Mappers.PlanBuilderMappers
{
    public class WizardViewModelMapper:IMapToNew<Wizard, WizardViewModel>
    {
        private readonly QCAViewModelMapper _qcaMapper;
        private readonly PlanViewModelMapper _planMapper;

        public WizardViewModelMapper(PlanViewModelMapper PlanMapper, QCAViewModelMapper QCAMapper)
        {
            _planMapper = PlanMapper;
            _qcaMapper = QCAMapper;
        }

        public WizardViewModel Map(Wizard wizard)
        {
            WizardViewModel WVM = new WizardViewModel();
            WVM.Plan = _planMapper.Map(wizard.Plan);

            WVM.QCAs = new List<QCAViewModel>();
            foreach (var QCA in wizard.QCAs)
            {
                WVM.QCAs.Add(_qcaMapper.Map(QCA));
            }
            

            return WVM;
        }
    }

    public class QCAViewModelMapper : IMapToNew<QCA, QCAViewModel>
    {
        private readonly QuestionViewModelMapper _questionMapper;
        private readonly ChoiceViewModelMapper _choiceMapper;
        private readonly AnswerViewModelMapper _answerMapper;

        public QCAViewModelMapper(QuestionViewModelMapper QuestionMapper, ChoiceViewModelMapper ChoiceMapper, AnswerViewModelMapper AnswerMapper)
        {
            _questionMapper = QuestionMapper;
            _choiceMapper = ChoiceMapper;
            _answerMapper = AnswerMapper;
        }

        public QCAViewModel Map(QCA QCA)
        {
            QCAViewModel QCAViewModel = new QCAViewModel();
            QCAViewModel.QuestionViewModel = _questionMapper.Map(QCA.Question);
            QCAViewModel.AnswersViewModel = new List<AnswerViewModel>();
            string ChoiceType = QCA.Question.ChoiceType;

            if(ChoiceType == "R")
            {
                if (!QCA.Answers.Any())
                {
                    AnswerViewModel AVM = new AnswerViewModel { AnswerId = Guid.NewGuid(), QuestionId = QCA.Question.QuestionId };
                    QCAViewModel.AnswersViewModel.Add(AVM);
                }
                else
                {
                    foreach (var Answer in QCA.Answers)
                    {
                        QCAViewModel.AnswersViewModel.Add(_answerMapper.Map(Answer));
                    }
                }
                QCAViewModel.AnswersViewModel.First().ChoicesViewModel = new List<ChoiceViewModel>();
                foreach(var Choice in QCA.Choices)
                {
                    QCAViewModel.AnswersViewModel.First().ChoicesViewModel.Add(_choiceMapper.Map(Choice));
                }
                QCAViewModel.AnswersViewModel.ForEach(x => x.IsSelected = true);
                QCAViewModel.AnswersViewModel.ForEach(x => x.ChoiceType = "R");
            }

            if (ChoiceType == "C")
            {
                foreach (var Choice in QCA.Choices)
                {
                    AnswerViewModel AVM = new AnswerViewModel();
                    
                    foreach (var Answer in QCA.Answers)
                    {
                        if (Answer.ChoiceId == Choice.ChoiceId)
                        {
                            AVM.AnswerId = Answer.AnswerId;
                            AVM.AnswerContent = Answer.AnswerContent;
                            AVM.ChoiceId = Answer.ChoiceId;
                            AVM.IsSelected = true;
                        }
                    }

                    if (string.IsNullOrEmpty(AVM.AnswerContent))
                    {
                        AVM.AnswerId = Guid.NewGuid();
                        AVM.AnswerContent = Choice.ChoiceContent;
                        AVM.ChoiceId = Choice.ChoiceId;
                        AVM.IsSelected = false;
                    }

                    //Add QuestionId to AnswerViewModel

                    AVM.QuestionId = Choice.QuestionId;

                    //Add Choice type to AnswerViewModel
                    AVM.ChoiceType = "C";
                    
                    //Add ChoicesViewModel to the AnswerViewModel (Should only be one ChoiceViewModel for each AnswerViewModel with "CheckBox"
                    AVM.ChoicesViewModel = new List<ChoiceViewModel>();
                    ChoiceViewModel CVM = new ChoiceViewModel();
                    CVM.ChoiceId = Choice.ChoiceId;
                    CVM.ChoiceContent = Choice.ChoiceContent;
                    AVM.ChoicesViewModel.Add(CVM);


                    QCAViewModel.AnswersViewModel.Add(AVM);
                }
            }
            if (ChoiceType == "F")
            {
                
                if (!QCA.Answers.Any())
                {
                    AnswerViewModel AVM = new AnswerViewModel();
                    AVM.AnswerId = Guid.NewGuid();
                    AVM.QuestionId = QCA.Question.QuestionId;
                    QCAViewModel.AnswersViewModel.Add(AVM);
                }
                else
                {
                    foreach (var Answer in QCA.Answers)
                    {
                        AnswerViewModel AVM = new AnswerViewModel();
                        AVM.AnswerId = Answer.AnswerId;
                        AVM.QuestionId = Answer.QuestionId;
                        AVM.AnswerContent = Answer.AnswerContent;
                        QCAViewModel.AnswersViewModel.Add(AVM);
                    }
                }
                QCAViewModel.AnswersViewModel.ForEach(x => x.IsSelected = true);
                QCAViewModel.AnswersViewModel.ForEach(x => x.ChoiceType = "F");
                QCAViewModel.AnswersViewModel.ForEach(x => x.ChoiceId = QCA.Choices.First().ChoiceId);
                
            }
            
            return QCAViewModel;
        }
    }

    public class QuestionViewModelMapper:IMapToNew<Question, QuestionViewModel>
    {
        public QuestionViewModel Map(Question Question)
        {
            QuestionViewModel QuestionViewModel = new QuestionViewModel();
            QuestionViewModel.QuestionId = Question.QuestionId;
            QuestionViewModel.QuestionContent = Question.QuestionContent;
            QuestionViewModel.ChoiceType = Question.ChoiceType;

            return QuestionViewModel;
        }
    }

    public class ChoiceViewModelMapper : IMapToNew<Choice, ChoiceViewModel>
    {
        public ChoiceViewModel Map(Choice Choice)
        {
            ChoiceViewModel ChoiceViewModel = new ChoiceViewModel();
            ChoiceViewModel.ChoiceId = Choice.ChoiceId;
            ChoiceViewModel.ChoiceContent = Choice.ChoiceContent;
            return ChoiceViewModel;
        }
    }

    public class AnswerViewModelMapper : IMapToNew<Answer, AnswerViewModel>
    {
        public AnswerViewModel Map(Answer Answer)
        {
            AnswerViewModel AnswerViewModel = new AnswerViewModel();
            AnswerViewModel.AnswerId = Answer.AnswerId;
            AnswerViewModel.AnswerContent = Answer.AnswerContent;
            AnswerViewModel.QuestionId = Answer.QuestionId;
            AnswerViewModel.ChoiceId = Answer.ChoiceId;
            
            return AnswerViewModel;
        }
    }
}