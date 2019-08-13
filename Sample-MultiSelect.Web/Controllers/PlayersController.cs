using Sample_MultiSelect.Data.DbContexts;
using Sample_MultiSelect.Data.Models;
using Sample_MultiSelect.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Sample_MultiSelect.Web.Controllers
{
    public class PlayersController : Controller
    {
        private MultiSelectContext db = new MultiSelectContext();

        public ActionResult Index()
        {
            return View(db.Players.ToList().OrderBy(i => i.Name));
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = db.Players.Find(id);

            if (player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }

        public ActionResult Create()
        {
            var teams = db.Teams.ToList();

            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var team in teams)
            {
                var item = new SelectListItem
                {
                    Value = team.Id.ToString(),
                    Text = team.Name
                };

                items.Add(item);
            }

            MultiSelectList teamsList = new MultiSelectList(items.OrderBy(i => i.Text), "Value", "Text");

            CreatePlayerViewModel viewModel = new CreatePlayerViewModel { Teams = teamsList };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, TeamIds")] CreatePlayerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Player player = new Player
                {
                    Id = Guid.NewGuid(),
                    Name = viewModel.Name
                };

                if (viewModel.TeamIds != null)
                {
                    foreach (var id in viewModel.TeamIds)
                    {
                        var teamId = Guid.Parse(id);

                        var team = db.Teams.Find(teamId);

                        try
                        {
                            player.Teams.Add(team);
                        }
                        catch (Exception ex)
                        {
                            return View("Error", new HandleErrorInfo(ex, "Players", "Index"));
                        }
                    }
                }

                try
                {
                    db.Players.Add(player);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Players", "Index"));
                }

                return RedirectToAction("Details", new { id = player.Id });
            }
            else
            {
                ModelState.AddModelError("", "Something failed.");
                return View(viewModel);
            }
        }
    }
}