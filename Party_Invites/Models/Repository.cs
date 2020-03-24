using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Party_Invites.Models
{
    public class Repository
    {
        private static Dictionary<string, GuestResponse> _responses;

        static Repository()
        {
            _responses = new Dictionary<string, GuestResponse>();

            _responses.Add("Bob", new GuestResponse { Name = "Bob", Email = "bob@example.com", WillAttend = true });
            _responses.Add("Alice", new GuestResponse { Name = "Alice", Email = "alice@example.com", WillAttend = true });
            _responses.Add("Paul", new GuestResponse { Name = "Paul", Email = "paul@example.com", WillAttend = true });
        }


        /// <summary>
        /// Add a guest response
        /// </summary>
        /// <param name="guestResponse">newResponse</param>
        public static void Add(GuestResponse guestResponse)
        {
            string key = guestResponse.Name.ToLowerInvariant();

            if (_responses.ContainsKey(key))
            {
                _responses[key] = guestResponse;
            }
            else
            {
                _responses.Add(key, guestResponse);
            }
        }

        /// <summary>
        /// Get all responses
        /// </summary>
        public static IEnumerable<GuestResponse> Responses
        {
            get { return _responses.Values; }
        }

    }
}