using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MicroBdc.Web.Models;
using MicroBdc.Web.Mappers.PlanBuilderMappers;
using MicroBdc.Domain.AppServices.PlanBuilder;
using MicroBdc.Domain.UnitsOfWork;
using MicroBdc.Entities.PlanBuilder;
using MicroBdc.Data.EntityFramework.Repositories.PlanBuilder;

namespace MicroBdc.Web.Controllers
{
    public class WizardController : Controller
    {
        private ISectionUnitOfWork _sectionUnitOfWork;
        private SectionBuilder _sectionBuilder;
        private PlanViewModelMapper _planMapper;
        private QuestionViewModelMapper _questionMapper;
        private ChoiceViewModelMapper _choiceMapper;
        private AnswerViewModelMapper _answerMapper;
        private QCAViewModelMapper _qcaMapper;

        public WizardController(ISectionUnitOfWork SectionUnitOfWork)
        {
            _sectionUnitOfWork = SectionUnitOfWork;
            _sectionBuilder = new SectionBuilder(_sectionUnitOfWork);
            _planMapper = new PlanViewModelMapper();
            _questionMapper = new QuestionViewModelMapper();
            _choiceMapper = new ChoiceViewModelMapper();
            _answerMapper = new AnswerViewModelMapper();
            _qcaMapper = new QCAViewModelMapper(_questionMapper, _choiceMapper, _answerMapper);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Initial(PlanViewModel PlanViewModel, int Section = 1)
        {
                
            //try
            //{
                //var Plan = _plans.Get(Guid.Parse(id));
                
                List<QCA> QuestionsChoicesAndAnswers = _sectionBuilder.GetQuestionsWithChoicesAndAnswers(Section, PlanViewModel.PlanId);
                Plan Plan = _planMapper.MapFrom(PlanViewModel);
                Wizard wizard = new Wizard { Plan = Plan, QCAs = QuestionsChoicesAndAnswers };
                WizardViewModelMapper WizardMapper = new WizardViewModelMapper(_planMapper, _qcaMapper);
                WizardViewModel WizardView = WizardMapper.Map(wizard);
                
                return View(WizardView);
            //}
            //catch
            //{
            //    return RedirectToAction("Index", "Plans");
            //}
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(WizardViewModel WizardViewModel, int Section = 1)
        {
            List<Answer> AnswersToSave = GetAnswersFromWizard(WizardViewModel);
            foreach (var Answer in AnswersToSave)
            {
                _sectionBuilder.SaveAnswer(Answer);
            }

            List<QCA> QuestionsChoicesAndAnswers = _sectionBuilder.GetQuestionsWithChoicesAndAnswers(Section, WizardViewModel.Plan.PlanId);
            Plan Plan = _planMapper.MapFrom(WizardViewModel.Plan);
            Wizard wizard = new Wizard { Plan = Plan, QCAs = QuestionsChoicesAndAnswers };
            WizardViewModelMapper WizardMapper = new WizardViewModelMapper(_planMapper, _qcaMapper);
            WizardViewModel WizardView = WizardMapper.Map(wizard);

            return View(WizardView);
        }



        public List<Answer> GetAnswersFromWizard(WizardViewModel WVM)
        {
            List<Answer> AnswerList = new List<Answer>();
            Guid PlanId = WVM.Plan.PlanId;
            foreach(var QCA in WVM.QCAs){
                foreach (var AVM in QCA.AnswersViewModel)
                {
                    if (AVM.IsSelected)
                    {
                        Answer Answer = new Answer();
                        Answer.AnswerId = AVM.AnswerId;
                        Answer.ChoiceId = AVM.ChoiceId;
                        Answer.QuestionId = AVM.QuestionId;
                        Answer.PlanId = PlanId;
                        if (AVM.ChoicesViewModel != null)
                        {
                            foreach (var Choice in AVM.ChoicesViewModel)
                            {
                                if (AVM.ChoiceId == Choice.ChoiceId)
                                {
                                    Answer.AnswerContent = Choice.ChoiceContent;
                                }
                            }
                        }
                        else
                        {
                            Answer.AnswerContent = AVM.AnswerContent;
                        }
                        
                        AnswerList.Add(Answer);
                    }
                //Delete Answers that that have been deselected or deleted.
                    else
                    {
                        _sectionBuilder.DeleteAnswer(AVM.AnswerId);
                        
                    }
                }
            }

            return AnswerList;
            
        }
    }
}