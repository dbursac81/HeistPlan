using AG04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AG04.Controllers
{
    public class SkillController : Controller
    {
        private Ag04Entities db = new Ag04Entities();

        private readonly SelectList memberSkills = new SelectList(new[] { "COMBAT", "STRENGTH", "STAMINA", "DRIVING", "LOCK PICKING", "CAR BOOSTING", "MONEY LAUNDERING"});

        // GET: Skill
        public ActionResult Index()
        {
            return View();
        }

        // GET: Skill/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Skill/Create
        public ActionResult Create(int id)
        {
            ViewBag.Skills = new SelectList(memberSkills);

            tblMemberSkills model = new tblMemberSkills();
            model.MemberID = id;
            ViewBag.MemberID = id;

            return View(model);
        }

        // POST: Skill/Create
        [HttpPost]
        public ActionResult Create(tblMemberSkills model)
        {
            ViewBag.Skills = new SelectList(memberSkills);

            CheckSkillExists(model);           

            try
            {
                tblMemberSkills skil = new tblMemberSkills
                {
                    MemberID = model.MemberID,                   
                    Name = model.Name,
                    SkillLevel = model.SkillLevel
                };

                db.tblMemberSkills.Add(skil);
                db.SaveChanges();

                return RedirectToAction("Details", "Member", new { @id = model.MemberID });
            }
            catch(Exception)
            {
                return View();
            }
        }

        public ActionResult CreateHeistSkills(int heistId)
        {
            ViewBag.Skills = new SelectList(memberSkills);

            tblHeistSkills skills = new tblHeistSkills();

            return View("CreateHeistSkills", skills);
        }
        
        // GET: Skill/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Skills = new SelectList(memberSkills);

            tblMemberSkills ms = GetSkillByID(id);

            return View(ms);
        }

        // POST: Skill/Edit/5
        [HttpPost]
        public ActionResult Edit(tblMemberSkills skills)
        {
            ViewBag.Skills = new SelectList(memberSkills);

            try
            {
                tblMemberSkills ms = GetSkillByID(skills.SkillID);
                ms.Name = skills.Name;
                ms.SkillLevel = skills.SkillLevel;

                db.SaveChanges();

                return RedirectToAction("Details", "Member", new { @id = skills.MemberID });
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Skill/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Skills = new SelectList(memberSkills);

            tblMemberSkills ms = GetSkillByID(id);

            return View(ms);
        }

        // POST: Skill/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                tblMemberSkills ms = GetSkillByID(id);
                db.tblMemberSkills.Remove(ms);
                db.SaveChanges();

                return RedirectToAction("Details", "Member", new { @id = ms.MemberID });
            }
            catch
            {
                return View();
            }
        }

        public void CheckSkillExists(tblMemberSkills model)
        {            
            int skillID;

            List<tblMemberSkills> skills = db.tblMemberSkills.Where(m => m.MemberID == model.MemberID).ToList();

            for (int i = 0; i < skills.Count(); i++)
            {
                if (skills[i].Name == model.Name)
                {
                    skillID = skills[i].SkillID;

                    tblMemberSkills oldSkil = db.tblMemberSkills.Find(skillID);
                    db.tblMemberSkills.Remove(oldSkil);

                    db.SaveChanges();
                }
            }            
        }

        private tblMemberSkills GetSkillByID(int? id)
        {
            tblMemberSkills skill = db.tblMemberSkills.SingleOrDefault(m => m.SkillID == id);

            return skill;
        }
    }
}
