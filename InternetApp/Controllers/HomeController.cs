using InternetApp.Filters;
using InternetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace InternetApp.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        private ProjectsContext db = new ProjectsContext();
        private UsersContext db2 = new UsersContext();
        private SkillLevelsContext dbSkillLvl = new SkillLevelsContext();
        private SkillsContext dvSkill = new SkillsContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Random message";
            int memberId = 0;
            memberId = WebSecurity.GetUserId(User.Identity.Name);

            List<string> skillList = (from p in dbSkillLvl.SkillLevels where p.UserId == memberId select p.SkillName).ToList();
            //List<int> skillLevel = (from p in dbSkillLvl.SkillLevels where p.UserId == memberId select p.Level).ToList();

            List<Project> projectList = (from p in db.Projects where skillList.Any(val => p.SkillName.Contains(val)) select p).ToList();

            return View(projectList);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
