using AG04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AG04.Controllers
{
    public class HeistController : Controller
    {
        private Ag04Entities db = new Ag04Entities();

        private readonly SelectList heistkills = new SelectList(new[] { "COMBAT", "STRENGTH", "STAMINA", "DRIVING", "LOCK PICKING", "CAR BOOSTING", "MONEY LAUNDERING" });

        
        [HttpGet]
        public ActionResult Index()
        {
            List<tblHeist> heists = new List<tblHeist>();
            heists = db.tblHeist.Where(m => m.Active == false).ToList();

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
        [ValidateAntiForgeryToken]
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
                    heist.Active = false;
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

        public ActionResult CreateHeistSkills(int id)
        {
            ViewBag.Skills = new SelectList(heistkills);

            ViewBag.HeistID = id;

            tblHeistSkills skill = new tblHeistSkills();
            skill.HeistID = id;

            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHeistSkills(tblHeistSkills model)
        {
            ViewBag.Skills = new SelectList(heistkills);

            tblHeistSkills skill = new tblHeistSkills
            {
                HeistID = model.HeistID,
                Name = model.Name,
                SkillLevel = model.SkillLevel,
                MembersNo = model.MembersNo
            };

            db.tblHeistSkills.Add(skill);
            db.SaveChanges();

            return RedirectToAction("Details", "Heist", new { @id = model.HeistID });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tblHeist heist = GetHeistByID(id);

            if (heist == null)
            {
                return HttpNotFound();
            }

            return View(heist);
        }

        public ActionResult DeleteHeistSkill(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tblHeistSkills hs = GetHeistSkillByID(id);

            if (hs == null)
            {
                return HttpNotFound();
            }

            return View(hs);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                tblHeist heist = GetHeistByID(id);

                db.tblHeist.Remove(heist);
                db.SaveChanges();

                List<tblHeist> heists = new List<tblHeist>();
                heists = db.tblHeist.Where(m => m.Active == true).ToList();

                return View("Index", heists);
            }
            catch
            {
                return View("Delete", db.tblHeist.Where(m => m.HeistID == id));
            }
        }

        [HttpPost, ActionName("DeleteHeistSkill")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSkillConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                tblHeistSkills hs = GetHeistSkillByID(id);
                db.tblHeistSkills.Remove(hs);
                db.SaveChanges();

                return RedirectToAction("Details", "Heist", new { @id = hs.HeistID });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tblHeist heist = GetHeistByID(id);

            if (heist == null)
            {
                return HttpNotFound();
            }

            return View(heist);
        }

        public ActionResult EditHeistSkill(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tblHeistSkills hs = GetHeistSkillByID(id);

            if (hs == null)
            {
                return HttpNotFound();
            }

            return View(hs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblHeist model)
        {
            try
            {
                tblHeist heist = GetHeistByID(model.HeistID);

                heist.Name = model?.Name ?? null;
                heist.Location = model?.Location ?? null;
                heist.StartDate = model.StartDate;
                heist.StartTime = model.StartTime;
                heist.EndDate = model.EndDate;
                heist.EndTime = model.EndTime;
                heist.Active = model.Active;

                db.SaveChanges();

                List<tblHeist> heists = new List<tblHeist>();
                heists = db.tblHeist.Where(m => m.Active == true).ToList();

                return View("Index", heists);
            }
            catch
            {
                return View("Edit", db.tblHeist.Where(m => m.HeistID == model.HeistID));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHeistSkill(tblHeistSkills model)
        {
            try
            {
                tblHeistSkills hs = GetHeistSkillByID(model.SkillsID);

                hs.HeistID = model.HeistID;
                hs.Name = model.Name;
                hs.SkillLevel = model.SkillLevel;
                hs.MembersNo = model.MembersNo;

                db.SaveChanges();

                return RedirectToAction("Details", "Heist", new { @id = model.HeistID });
            }
            catch
            {
                return RedirectToAction("EditHeistSkill", "Heist", new { @id = model.HeistID });
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.HeistID = id;

            var totall = db.tblHeistSkills.Where(m => m.HeistID == id).ToArray();

            int total = 0;
            foreach (tblHeistSkills item in totall)
            {
                total += (Int32)item.MembersNo;
            }

            ViewBag.MembersRequiredTotal = total;

            ViewBag.MembersAssignedTotal = db.tblHeistMembers.Where(m => m.HeistID == id).Count();

            tblHeist heist = GetHeistByID(id);

            var _skillsList = heist.tblHeistSkills.OrderBy(m => m.HeistID).ToArray();

            HeistModel hm = new HeistModel();

            hm.HeistID = heist.HeistID;
            hm.Name = heist.Name;
            hm.Location = heist.Location;
            hm.StartDate = heist.StartDate;
            hm.StartTime = heist.StartTime;
            hm.EndDate = heist.EndDate;
            hm.EndTime = heist.EndTime;

            //Setting skills
            hm.HeistSkills = GetHeistSkills(id);

            //Setting members
            var _allMembers = db.tblHeistMembers.ToArray();
            hm.HeistMembers = GetHeistMembers(id);

            return View(hm);
        }

        public ActionResult AddHeistMember(int? heistID)
        {
            tblHeist heist = GetHeistByID(heistID);

            var _skillsList = heist.tblHeistSkills.OrderBy(m => m.HeistID).ToArray();

            HeistModel hm = new HeistModel();

            //Getting skills
            hm.HeistSkills = new List<HeistSkillModel>();
            for (int i = 0; i < _skillsList.Count(); i++)
            {
                HeistSkillModel mod = new HeistSkillModel
                {
                    HeistID = _skillsList[i].HeistID,
                    SkillID = _skillsList[i].SkillsID,
                    Name = _skillsList[i].Name,
                    Level = _skillsList[i].SkillLevel,
                    MembersNo = (Int16)_skillsList[i].MembersNo
                };

                hm.HeistSkills.Add(mod);
            }

            //getting members
            var _allMembers = GetMatchingMembers(heistID);

            List<HeistMemberModel> _list = _allMembers.ToList();
            hm.HeistMembers = _allMembers as List<HeistMemberModel>;

            ViewBag.MatchingMembers = new SelectList(_list);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHeistMember(HeistMemberModel model)
        {
            tblHeist heist = GetHeistByID(model.HeistID);

            var _skillsList = heist.tblHeistSkills.OrderBy(m => m.HeistID).ToArray();

            HeistModel hm = new HeistModel();

            //Getting skills
            hm.HeistSkills = new List<HeistSkillModel>();
            for (int i = 0; i < _skillsList.Count(); i++)
            {
                HeistSkillModel mod = new HeistSkillModel
                {
                    HeistID = _skillsList[i].HeistID,
                    SkillID = _skillsList[i].SkillsID,
                    Name = _skillsList[i].Name,
                    Level = _skillsList[i].SkillLevel,
                    MembersNo = (Int16)_skillsList[i].MembersNo
                };

                hm.HeistSkills.Add(mod);
            }

            //getting members
            var _allMembers = GetMatchingMembers(model.HeistID);

            List<HeistMemberModel> _list = _allMembers.ToList();

            hm.HeistMembers = _allMembers as List<HeistMemberModel>;

            ViewBag.MatchingMembers = new SelectList(_list);

            tblHeistMembers member = new tblHeistMembers();
            member.HeistID = model.HeistID;
            member.MemberID = Convert.ToInt32(model.Name);
            member.ActiveInHeist = true;

            db.tblHeistMembers.Add(member);

            tblMember mem = new tblMember();
            mem = db.tblMember.SingleOrDefault(m => m.MemberID == member.MemberID);
            mem.ActiveInHeist = true;

            db.SaveChanges();

            return RedirectToAction("Details", "Heist", new { @id = model.HeistID });
        }

        public ActionResult DeleteMember(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tblMember member = db.tblMember.SingleOrDefault(m => m.MemberID == id);

            if (member == null)
            {
                return HttpNotFound();
            }

            return View(member);
        }

        [HttpPost, ActionName("DeleteMember")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMember(int id)
        {
            tblHeistMembers member = db.tblHeistMembers.SingleOrDefault(m => m.MemberID == id);

            int? heistID = member.HeistID;
            db.tblHeistMembers.Remove(member);

            tblMember mem = db.tblMember.SingleOrDefault(m => m.MemberID == id);
            mem.ActiveInHeist = false;

            db.SaveChanges();

            return RedirectToAction("Details", "Heist", new { @id = heistID });
        }

        public bool HeistExists(tblHeist model)
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

        public tblHeist GetHeistByID(int? id)
        {
            tblHeist heist = db.tblHeist.SingleOrDefault(m => m.HeistID == id);
            return heist;
        }

        public tblHeistSkills GetHeistSkillByID(int? id)
        {
            tblHeistSkills hs = db.tblHeistSkills.SingleOrDefault(m => m.SkillsID == id);
            return hs;
        }

        public List<HeistSkillModel> GetHeistSkills(int? heistID)
        {
            tblHeist heist = GetHeistByID(heistID);

            List<tblHeistSkills> heistSkills = heist.tblHeistSkills.OrderBy(m => m.HeistID).ToList();

            List<HeistSkillModel> hsm = new List<HeistSkillModel>();

            for (int i = 0; i < heistSkills.Count(); i++)
            {
                HeistSkillModel mod = new HeistSkillModel();

                mod.SkillID = heistSkills[i].SkillsID;
                mod.Name = heistSkills[i].Name;
                mod.Level = heistSkills[i].SkillLevel;
                mod.MembersNo = (Int16)heistSkills[i].MembersNo;

                hsm.Add(mod);
            }

            return hsm;
        }

        public List<HeistMemberModel> GetHeistMembers(int? heistID)
        {
            var members = db.tblHeistMembers.Where(m => m.HeistID == heistID).ToList();

            List<HeistMemberModel> hsm = new List<HeistMemberModel>();

            for (int i = 0; i < members.Count(); i++)
            {
                HeistMemberModel hmm = new HeistMemberModel();

                hmm.HeistID = members[i].HeistID;
                hmm.MemberID = members[i].MemberID;

                var mem = db.tblMember.SingleOrDefault(m => m.MemberID == hmm.MemberID);

                hmm.Name = mem.Name;


                hsm.Add(hmm);
            }

            return hsm;
        }

        public List<HeistMemberModel> GetMatchingMembers(int? heistID)
        {
            tblHeist heist = GetHeistByID(heistID);

            var _skillsList = heist.tblHeistSkills.OrderBy(m => m.HeistID).ToArray();

            HeistModel hm = new HeistModel();
            hm.HeistID = heist.HeistID;

            //Setting skills
            hm.HeistSkills = new List<HeistSkillModel>();
            for (int i = 0; i < _skillsList.Count(); i++)
            {
                HeistSkillModel mod = new HeistSkillModel
                {
                    HeistID = _skillsList[i].HeistID,
                    SkillID = _skillsList[i].SkillsID,
                    Name = _skillsList[i].Name,
                    Level = _skillsList[i].SkillLevel,
                    MembersNo = (Int16)_skillsList[i].MembersNo
                };

                hm.HeistSkills.Add(mod);
            }

            //Setting members
            List<HeistMemberModel> matchingMembers = new List<HeistMemberModel>();

            var _allMembers = db.tblMember.Where(m => m.ActiveInHeist != true).ToArray();

            hm.HeistMembers = new List<HeistMemberModel>();

            for (int i = 0; i < hm.HeistSkills.Count(); i++)//iterating skills determined for heist
            {
                for (int j = 0; j < _allMembers.Count(); j++) //iterating predetermined members
                {
                    var temp = _allMembers[j].MemberID;

                    List<tblMemberSkills> memberSkills = db.tblMemberSkills.Where(m => m.MemberID == temp).ToList(); //getting each member's skills

                    for (int m = 0; m < memberSkills.Count(); m++)
                    {
                        if (hm.HeistSkills[i].Name == memberSkills[m].Name && hm.HeistSkills[i].Level.Length <= memberSkills[m].SkillLevel.Length) //matching heist skills to member's skills
                        {
                            HeistMemberModel member = new HeistMemberModel();

                            member.HeistID = heist.HeistID;
                            member.MemberID = _allMembers[j].MemberID;
                            member.Name = _allMembers[j].Name;

                            bool contains = false;
                            for (int k = 0; k < matchingMembers.Count(); k++)
                            {
                                if (matchingMembers[k].Name == member.Name) contains = true;
                            }

                            if (contains != true)
                            {
                                matchingMembers.Add(member);
                            }

                        }
                    }
                }
            }

            return matchingMembers;
        }
    }
}