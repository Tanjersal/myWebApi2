using PartyInvites.Models;
using System.Linq;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rsvp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Rsvp(GuestResponse newResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.Add(newResponse);

                return View("Thanks", newResponse);
            }
            else
                return View();
        }

        [ChildActionOnly] //call only as a child action
        public ActionResult Attendees()
        {
            return View(Repository.Responses.Where(x => x.WillAttend == true));
        }
    }
}