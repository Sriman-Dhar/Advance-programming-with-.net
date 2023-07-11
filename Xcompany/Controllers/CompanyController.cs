using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xcompany.Models;

namespace Xcompany.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            ViewBag.CompanyName = "X Company";
            return View();
        }

        public ActionResult Services()
        {
            var S1 = new Services()
            {
                ServiceName = "Web Development",
                ServiceMoto = "Developing Next Gen Websites!!"
            };

            var S2 = new Services()
            {
                ServiceName = "Automation Development",
                ServiceMoto = "Making your job easier!!"
            };

            var S3 = new Services()
            {
                ServiceName = "App Development",
                ServiceMoto = "Empowering Ideas, Building Futures: Ignite Your App Journey!!"
            };

            Services[] ss = new Services[] { S1, S2, S3 };
            return View(ss);
        }

        public ActionResult TeamMember()
        {
            var t1 = new TeamMember()
            {
                TeamName = "Development Team"
            };

            var t2 = new TeamMember()
            {
                TeamName = "Testing Team"
            };

            var t3 = new TeamMember()
            {
                TeamName = "Designer Team"
            };

            TeamMember[] TT = new TeamMember[] { t1, t2, t3};
            return View(TT);
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}