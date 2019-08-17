using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sample_MultiSelect.Data.DbContexts;
using Sample_MultiSelect.Data.Models;
using Sample_MultiSelect.Web.ViewModels;

namespace Sample_MultiSelect.Web.Controllers
{
    public class TeamsController : Controller
    {
        private MultiSelectContext db = new MultiSelectContext();

        public ActionResult Index()
        {
            return View(db.Teams.ToList().OrderBy(i => i.Name));
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        public ActionResult Create()
        {
            return View(new CreateTeamViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] CreateTeamViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var team = new Team
                {
                    Id = Guid.NewGuid(),
                    Name = viewModel.Name
                };

                try
                {
                    db.Teams.Add(team);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Temas", "Index"));
                }

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(new EditTeamViewModel { Id = team.Id, Name = team.Name });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name")] EditTeamViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Team team = db.Teams.Find(viewModel.Id);
                if (team != null)
                {
                    team.Name = viewModel.Name;
                    try
                    {
                        db.Entry(team).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return View("Error", new HandleErrorInfo(ex, "Teams", "Index"));
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    Exception ex = new Exception("Unable to Retrive Team");
                    return View("Error", new HandleErrorInfo(ex, "Teams", "Index"));
                }
            }

            return View(viewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}