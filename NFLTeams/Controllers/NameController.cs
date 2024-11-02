using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;

namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamsViewModel
            {
                Username = session.GetName(),
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Teams = session.GetMyTeams()
            };

            return View(model);
        }
        [HttpPost]
        public RedirectToActionResult Change(TeamsViewModel model)
        {
            var session = new NFLSession(HttpContext.Session);
            session.SetName(model.Username);

            return RedirectToAction("Index", "Home",
                new
                {
                   ActiveConf = session.GetActiveConf(),
                   ActiveDiv = session.GetActiveDiv(),
                });
        }
    }
}
