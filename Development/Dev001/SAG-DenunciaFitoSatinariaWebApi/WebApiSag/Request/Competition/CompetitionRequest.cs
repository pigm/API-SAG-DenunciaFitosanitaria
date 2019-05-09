using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSag.Request.Competition
{
    public class CompetitionRequest
    {
        public string userCodeProfile { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}