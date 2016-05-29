using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MicroBdc.Entities.PlanBuilder;
using MicroBdc.Web.Models;

namespace MicroBdc.Web.Mappers.PlanBuilderMappers
{
    public class PlanViewModelMapper:IMapToNew<Plan, PlanViewModel>, IMapToExisting<Plan, PlanViewModel>
    {
        public PlanViewModel Map(Plan Plan)
        {
            PlanViewModel PVM = new PlanViewModel();
            PVM.PlanId = Plan.PlanId;
            PVM.PlanName = Plan.PlanName;
            return PVM;
        }

        public void Map(Plan plan, PlanViewModel PlanViewModel)
        {
            PlanViewModel.PlanId = plan.PlanId;
            PlanViewModel.PlanName = plan.PlanName;
        }

        public Plan MapFrom(PlanViewModel PlanViewModel)
        {
            Plan Plan = new Plan();
            Plan.PlanId = PlanViewModel.PlanId;
            Plan.PlanName = PlanViewModel.PlanName;
            return Plan;
        }
    }
}