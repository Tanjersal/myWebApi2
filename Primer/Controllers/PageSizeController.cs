using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Primer.Controllers
{
    public class PageSizeController : ApiController
    {
        private static string TargetUrl = "http://apress.com";

        /// <summary>
        /// Returns page size
        /// </summary>
        /// <returns></returns>
        public long GetPageSize()
        {
            WebClient client = new WebClient();
            Stopwatch sw = new Stopwatch();

            byte[] data = client.DownloadData(TargetUrl);
            Debug.WriteLine("Elpased ms: {0}", sw.ElapsedMilliseconds);
            return data.LongLength;
        }
    }
}
