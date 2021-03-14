using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AG04.Controllers
{
    public class ActivationController : Controller
    {
        // GET: Activation
        public ActionResult Index()
        {
            return View();
        }

        // GET: Activation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Activation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Activation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Activation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Activation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Activation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
