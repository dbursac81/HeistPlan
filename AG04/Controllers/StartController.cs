using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AG04.Models;

namespace AG04.Controllers
{
    public class StartController : Controller
    {
        private Ag04Entities db = new Ag04Entities();
               
        [HttpGet]
        public ActionResult Activation()
        {
            List<tblHeist> list = db.tblHeist.Where(m => m.Active == false).ToList();

            ViewBag.InactiveHeists = new SelectList(list);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Activation(tblHeist model)
        {
            if (model.Name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int heistID = Convert.ToInt32(model.Name);

            tblHeist heist = db.tblHeist.SingleOrDefault(m => m.HeistID == heistID);

            if (heist == null)
            {
                return HttpNotFound();
            }

            heist.Active = true;

            //check members numbers (required & assigned)
            var totall = db.tblHeistSkills.Where(m => m.HeistID == heist.HeistID).ToArray();

            int required = 0;

            ResultModel rm = new ResultModel();

            foreach (tblHeistSkills item in totall)
            {
                required += (Int32)item.MembersNo;
            }

            int assigned = db.tblHeistMembers.Where(m => m.HeistID == heist.HeistID).Count();

            if (assigned == 0)
            {
                TempData["ErrorMessage"] = "Not enough members have been assigned!";

                return RedirectToAction("Error", "Start");
            }

            if (assigned < required)
            {
                TempData["ErrorMessage"] = "Not enough members have been assigned!";

                return RedirectToAction("Error", "Start");
            }
            else
            {
                //getting status for members
                var random = new Random();
                var list = new List<string> { "EXPIRED", "INCARCERATED", "SURVIVED"};              

                var members = db.tblHeistMembers.Where(m => m.HeistID == heist.HeistID);

                int indexx = 0;

                foreach (tblHeistMembers member in members)
                {
                    indexx = random.Next(list.Count);
                    member.Status = list[indexx];
                }
                
                rm = GetHeistResult(members.ToList());
            }
            
            heist.Active = false;

            db.SaveChanges();       

            return View("HeistResult", rm);
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult HeistResult()
        {
            return View();
        }      

        public tblHeist GetHeistByID(int? id)
        {
            tblHeist heist = db.tblHeist.SingleOrDefault(m => m.HeistID == id);
            return heist;
        }

        public ResultModel GetHeistResult(List<tblHeistMembers> list)
        {
            ResultModel rm = new ResultModel();

            string result = null;

            int allMembers = list.Count();
            decimal halfTeam = allMembers / 2M;

            decimal oneThird = allMembers / 3M;

            decimal twoThirds = oneThird * 2M;

            int expiredCounter = 0;
            int incarceratedCounter = 0;

            foreach (tblHeistMembers member in list)
            {
                if (member.Status.Equals("EXPIRED"))
                {
                    expiredCounter++;
                }
                else if(member.Status.Equals("INCARCERATED"))
                {
                    incarceratedCounter++;
                }
            }

            rm.Total = allMembers;
            rm.ExpiredNo = expiredCounter;
            rm.IncarceratedNo = incarceratedCounter;

            decimal sumOfFails = expiredCounter + incarceratedCounter;

            if (sumOfFails > halfTeam) // <50
            {
                result = "FAILED";
            }
            else if (sumOfFails >= twoThirds) // 50-75
            {
                result = "FAILED";
            }
            else if (sumOfFails >= oneThird && expiredCounter == 0) // 75-100
            {
                result = "SUCCEEDED";
            }
            else if (sumOfFails >= oneThird) //50-75
            {
                result = "SUCCEEDED";
            }            
            else //100
            {
                result = "SUCCEEDED";
            }

            rm.Result = result;

            return rm;
        }
    }
}