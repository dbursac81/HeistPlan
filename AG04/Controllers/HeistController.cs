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

        private readonly SelectList heistkills = new SelectList(new[] { "COMBAT", "STRENGTH", "STAMINA", "DRIVING", "LOCK PICKING", "CAR BOOSTING", "MONEY LAUNDERING" });

        // GET: Heist
        public ActionResult Index()
        {
            List<tblHeist> heists = new List<tblHeist>();
            heists = db.tblHeist.Where(m => m.Active == true).ToList();

            return View(heists);
        }

        public ActionResult Create()
        {
            HeistModel hm = new HeistModel();
            hm.StartDate = DateTime.Now;
            hm.StartTime = DateTime.Now;
            hm.EndDate = DateTime.Now;
            hm.EndTime = DateTime.Now;
            hm.Active = true;

            return View(hm);
        }

        [HttpPost]
        public ActionResult Create(HeistModel model)
        {
            try
            {
                tblHeist heist = new tblHeist();
                {
                    heist.Name = model?.Name ?? null;
                    heist.Location = model?.Location ?? null;
                    heist.StartDate = model.StartDate;
                    heist.StartTime = model.StartTime;
                    heist.EndDate = model.EndDate;
                    heist.EndTime = model.EndTime;
                    heist.Active = model.Active;
                }

                db.tblHeist.Add(heist);
                db.SaveChanges();

                List<tblHeist> heists = new List<tblHeist>();
                heists = db.tblHeist.Where(m => m.Active == true).ToList();

                return View("Index", heists);
            }
            catch 
            { 
                return View("Create", model); 
            }
        }


        public ActionResult CreateHeistSkills(HeistModel model)
        {
            ViewBag.Skills = new SelectList(heistkills);

            bool result = false;
            if (!string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.Location)) 
            {
                result = HeistExists(model); 
            }

            if (result == false)
            {
                try
                {
                    tblHeist heist = new tblHeist();
                    {
                        heist.Name = model?.Name ?? "";
                        heist.Location = model?.Location ?? "";
                        heist.StartDate = model.StartDate;
                        heist.StartTime = model.StartTime;
                        heist.EndDate = model.EndDate;
                        heist.EndTime = model.EndTime;
                        heist.Active = model.Active;
                    }

                    db.tblHeist.Add(heist);
                    db.SaveChanges();

                    List<tblHeist> heists = new List<tblHeist>();
                    heists = db.tblHeist.Where(m => m.Active == true).ToList();

                    return View("Index", heists);
                }
                catch
                {
                    return View("Create", model);
                }
            }
            else
            {
                tblHeist heist = new tblHeist();
                heist = db.tblHeist.SingleOrDefault(m => m.Name.ToUpper() == model.Name.ToUpper() && m.Location.ToUpper() == model.Location.ToUpper() && m.StartDate == model.StartDate && m.EndDate == model.EndDate && m.StartTime == model.StartTime && m.EndTime == model.EndTime);

                int heistID = heist.HeistID;

                tblHeistSkills skills = new tblHeistSkills();
                skills.HeistID = heistID;

                return View("CreateHeistSkills", skills);
            }

            return View("Index");
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

        public bool HeistExists(HeistModel model)
        {
            bool result = false;

            List<tblHeist> heists = new List<tblHeist>();
            heists = db.tblHeist.Where(m => m.Active == true).ToList();

            for (int i = 0; i < heists.Count(); i++)
            {
                if (model.Name.ToUpper() == heists[i].Name.ToUpper() && model.Location.ToUpper() == heists[i].Location.ToUpper() && model.StartDate == heists[i].StartDate && model.EndDate == heists[i].EndDate && model.StartTime == heists[i].StartTime && model.EndTime == heists[i].EndTime)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}