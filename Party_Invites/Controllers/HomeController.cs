using Party_Invites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Party_Invites.Controllers
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
        public ActionResult Rsvp(GuestResponse guestResponse)
        {
            if(ModelState.IsValid)
            {
                Repository.Add(guestResponse);

                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }


        [ChildActionOnly]
        public ActionResult Attendees()
        {
            return View(Repository.Responses.Where(x => x.WillAttend == true));
        }
    }
}