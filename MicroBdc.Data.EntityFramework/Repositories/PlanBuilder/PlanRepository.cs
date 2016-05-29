using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroBdc.Data.EntityFramework.Context;
using MicroBdc.Domain.Repositories.PlanBuilder;
using MicroBdc.Entities.Identity;
using MicroBdc.Entities.PlanBuilder;

namespace MicroBdc.Data.EntityFramework.Repositories.PlanBuilder
{
    public class PlanRepository : IPlanRepository
    {

        private PlanBuilderDbContext _context;

        public PlanRepository()
        {
            _context = new PlanBuilderDbContext();
        }

        public IEnumerable<Plan> GetAll(Guid UserId)
        {
            IEnumerable<Plan> Plans = from x in _context.Plans
                               where x.UserId == UserId
                               select x;
            return Plans;
        }

        public Plan Get(Guid PlanId)
        {
            IEnumerable<Plan> PlanQuery = from x in _context.Plans
                                where x.PlanId == PlanId
                                select x;
            Plan PlanToReturn = PlanQuery.FirstOrDefault<Plan>();
            return PlanToReturn;
        }

        public string Add(Plan plan)
        {
            try
            {
                plan.PlanId = Guid.NewGuid();
                _context.Plans.Add(plan);
                _context.SaveChanges();
                return "Succeeded";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
            

        }

        public void Update(Plan plan)
        {

        }

        public void Remove(Plan plan)
        {

        }
    }
}
