using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBdc.Entities.PlanBuilder;
using MicroBdc.Entities.Identity;

namespace MicroBdc.Domain.Repositories.PlanBuilder
{
    public interface IPlanRepository
    {
        IEnumerable<Plan> GetAll(Guid UserId);

        Plan Get(Guid PlanId);

        string Add(Plan plan);
        void Update(Plan plan);
        void Remove(Plan plan);
    }
}
