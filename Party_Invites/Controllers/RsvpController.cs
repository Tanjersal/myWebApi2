using Party_Invites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Party_Invites.Controllers
{
    public class RsvpController : ApiController
    {
        /// <summary>
        /// Return list of attendees - HTTP
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GuestResponse> GetAttendees()
        {
            return Repository.Responses.Where(x => x.WillAttend == true);
        }

        /// <summary>
        /// Add a response - HTTP
        /// </summary>
        /// <param name="guestResponse"></param>
        public void PostResponse(GuestResponse guestResponse)
        {
            if(ModelState.IsValid)
            {
                Repository.Add(guestResponse);
            }
        }
    }
}
