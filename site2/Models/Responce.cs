using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace site.Models
{
    public class Response
    {
        public string text { get; set; }
        public string email { get; set; }
        public string feedback { get; set; }
    }
}