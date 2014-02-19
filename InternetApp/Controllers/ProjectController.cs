using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternetApp.Models;
using System.Web.Security;
using WebMatrix.WebData;
using InternetApp.Filters;

namespace InternetApp.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class ProjectController : Controller
    {
        private ProjectsContext db = new ProjectsContext();

        //
        // GET: /Project/
        public ActionResult Index()
        {
            var memberId = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.memberIdent = memberId;

            return View(db.Projects.ToList());
        }

        public ActionResult Search(string searchString = "0")
        {
            ViewBag.searchString = searchString;
            List<Project> projectList = (from p in db.Projects where p.Name.Contains(searchString) select p).ToList();

            //AccountSearchModel model = new AccountSearchModel();
            //model.UserProfiles = usrProfileList;

            return View(projectList);
        }

        //
        // GET: /Project/Details/5

        public ActionResult Details(int id = 0)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            var memberId = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.memberIdent = memberId;

            return View();
        }

        //
        // POST: /Project/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        //
        // GET: /Project/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var memberId = WebSecurity.GetUserId(User.Identity.Name);

            using (ProjectsContext db = new ProjectsContext())
            {
                // User id from selected project id
                int projUsrId = (from p in db.Projects
                                 where p.ProjectId == id
                                 select p.UserId).Single();

                Project project = db.Projects.Find(id);
                if (project == null)
                {
                    return HttpNotFound();
                }
                else if (memberId == projUsrId)
                {
                    return View(project);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        //
        // POST: /Project/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {

            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // GET: /Project/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var memberId = WebSecurity.GetUserId(User.Identity.Name);

            using (ProjectsContext db = new ProjectsContext())
            {
                int projUsrId = (from p in db.Projects
                                 where p.ProjectId == id
                                 select p.UserId).Single();

                Project project = db.Projects.Find(id);
                if (project == null)
                {
                    return HttpNotFound();
                }
                else if (memberId == projUsrId)
                {
                    return View(project);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        //
        // POST: /Project/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}