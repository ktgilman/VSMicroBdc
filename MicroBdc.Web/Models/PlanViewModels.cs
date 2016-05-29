using System;
using System.ComponentModel.DataAnnotations;
using MicroBdc.Entities.PlanBuilder;

namespace MicroBdc.Web.Models
{

    public class PlanViewModel
    {

        public PlanViewModel(Plan PlanObject)
        {
            this.PlanId = PlanObject.PlanId;
            this.PlanName = PlanObject.PlanName;
        }

        public PlanViewModel()
        {

        }

        public Guid PlanId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Plan Name")]
        public string PlanName { get; set; }
        
    }
}