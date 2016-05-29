using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MicroBdc.Entities.PlanBuilder;

namespace MicroBdc.Web.Models
{
    public class WizardViewModel
    {
        public PlanViewModel Plan { get; set; }

        public List<QCAViewModel> QCAs { get; set; }
    }

    public class QCAViewModel
    {
        public QuestionViewModel QuestionViewModel { get; set; }
        public List<AnswerViewModel> AnswersViewModel { get; set; }
    }

    public class QuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public string ChoiceType { get; set; }
    }

    public class AnswerViewModel
    {
        public Guid AnswerId { get; set; }
        public string AnswerContent { get; set; }
        public Guid QuestionId { get; set; }
        public Guid ChoiceId { get; set; }
        public string ChoiceType { get; set; }
        public bool IsSelected { get; set; }

        public List<ChoiceViewModel> ChoicesViewModel { get; set; }
    }
    
    public class ChoiceViewModel
    {
        public Guid ChoiceId { get; set; }
        public string ChoiceContent { get; set; }
    }
}