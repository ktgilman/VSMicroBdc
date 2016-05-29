using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MicroBdc.Data.EntityFramework.Repositories.PlanBuilder;
using MicroBdc.Entities.Identity;
using MicroBdc.Entities.PlanBuilder;
using MicroBdc.Web.Identity;
using MicroBdc.Web.Models;
using MicroBdc.Web.Mappers.PlanBuilderMappers;

namespace MicroBdc.Web.Controllers
{
    public class PlansController : Controller
    {

        private string _currentUser;
        private PlanRepository _plans;
        private PlanViewModelMapper _planMapper;

        public PlansController()
        {
            _plans = new PlanRepository();
            _planMapper = new PlanViewModelMapper();

            try
            {
                _currentUser = System.Web.HttpContext.Current.User.Identity.GetUserId();
            }
            catch (Exception Ex)
            {
                _currentUser = null;
            }
            
        }

        /*protected HttpServerUtility User
        {
            get; set;
        }*/

        
        public ActionResult Index()
        {
            if (_currentUser == null)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else
            {
                List<Plan> PlanList = _plans.GetAll(Guid.Parse(_currentUser)).ToList();
                ViewBag.Plans = PlanList;
                return View();
            }
            
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PlanViewModel model)
        {
            if (ModelState.IsValid)
            {

                Plan PlanToAdd = new Plan();
                PlanToAdd.PlanName = model.PlanName;
                PlanToAdd.UserId = Guid.Parse(_currentUser);
                PlanToAdd.CreationDate = DateTime.Now;

                var result = _plans.Add(PlanToAdd);
                return RedirectToAction("Index", "Plans");
            }

            return View(model);
        }

        public ActionResult Show(string id)
        {
            if (_currentUser == null)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else if (id == null)
            {
                return RedirectToAction("Index", "Plans", null);
            }
            else
            {
                var result = _plans.Get(Guid.Parse(id));
                PlanViewModel PlanViewModel = _planMapper.Map(result);
                //ViewBag.Plan = result;
                return View(PlanViewModel);
            }
            
        }

        public ActionResult Edit(string id)
        {
            if (_currentUser == null)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else if (id == null)
            {
                return RedirectToAction("Index", "Plans", null);
            }
            else
            {
                var model = GetPlanViewModelById(id);
                return View(model);
            }
            
        }

       // [HttpPost]
       // [AllowAnonymous]
       // [ValidateAntiForgeryToken]
        //public ActionResult Edit(UpdatePlanViewModel model)
        //{

       // }

        public ActionResult Delete(string id)
        {
            if (_currentUser == null)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else if (id == null)
            {
                return RedirectToAction("Index", "Plans", null);
            }
            else
            {
                var model = GetPlanViewModelById(id);
                return View(model);
            }
            
        }

        public ActionResult ConfirmDelete(string id)
        {
            if (_currentUser == null)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else if (id == null)
            {
                return RedirectToAction("Index", "Plans", null);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }




        public PlanViewModel GetPlanViewModelById(string id)
        {
            var result = _plans.Get(Guid.Parse(id));
            PlanViewModel model = new PlanViewModel(result);
            return model;
        }
            
    }
}