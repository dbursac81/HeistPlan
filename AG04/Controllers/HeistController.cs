using AG04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AG04.Controllers
{
    public class HeistController : Controller     
    {
        private Ag04Entities db = new Ag04Entities();

        // GET: Heist
        public ActionResult Index()
        {
            return View();
        }
    }
}