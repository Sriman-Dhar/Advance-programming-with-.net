using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.EF;
using WebApplication1.EF.Models;

namespace WebApplication1.Controllers
{
    public class HungerZeroController : Controller
    {
        private readonly HungerDbContext _dbContext;

        public HungerZeroController()
        {
            _dbContext = new HungerDbContext();
        }

        // GET: HungerZero
        public ActionResult Index()
        {
            return View();
        }

        // GET: CollectRequest/Create
        public ActionResult CreateCollectRequest()
        {
            ViewBag.Restaurants = _dbContext.Restaurants.ToList();
            ViewBag.Employees = _dbContext.Employees.ToList();
            return View();
        }

        // POST: CollectRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCollectRequest(CollectRequest collectRequest)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CollectRequests.Add(collectRequest);
                _dbContext.SaveChanges();
                return RedirectToAction("IndexCollectRequest");
            }

            ViewBag.Restaurants = _dbContext.Restaurants.ToList();
            ViewBag.Employees = _dbContext.Employees.ToList();
            return View(collectRequest);
        }

        // GET: CollectRequest/Index
        public ActionResult IndexCollectRequest()
        {
            var collectRequests = _dbContext.CollectRequests.ToList();
            return View(collectRequests);
        }

        // GET: FoodDistribution/Create
        public ActionResult CreateFoodDistribution()
        {
            ViewBag.CollectRequests = _dbContext.CollectRequests.ToList();
            ViewBag.Restaurants = _dbContext.Restaurants.ToList();
            return View();
        }

        // POST: FoodDistribution/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFoodDistribution(FoodDistribution foodDistribution)
        {
            if (ModelState.IsValid)
            {
                _dbContext.FoodDistributions.Add(foodDistribution);
                _dbContext.SaveChanges();
                return RedirectToAction("IndexFoodDistribution");
            }

            ViewBag.CollectRequests = _dbContext.CollectRequests.ToList();
            ViewBag.Restaurants = _dbContext.Restaurants.ToList();
            return View(foodDistribution);
        }

        // GET: FoodDistribution/Index
        public ActionResult IndexFoodDistribution()
        {
            var foodDistributions = _dbContext.FoodDistributions.ToList();
            return View(foodDistributions);
        }

    }
}