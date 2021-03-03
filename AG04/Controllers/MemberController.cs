using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AG04.Models;

namespace AG04.Controllers
{
    public class MemberController : Controller
    {
        private Ag04Entities db = new Ag04Entities();

        private readonly SelectList sex = new SelectList(new[] { "M", "F" });


        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

    }
}