using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AG04.Models;

namespace AG04.Controllers
{
    public class MemberController : Controller
    {
        private Ag04Entities db = new Ag04Entities();

        private readonly SelectList memberSex = new SelectList(new[] { "M", "F" });
        private readonly SelectList memberStatus = new SelectList(new[] { "AVAILABLE", "EXPIRED", "INCARCERATED", "RETIRED" });
        
        // GET: Member
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.MemberStatus = new SelectList(memberStatus);
            ViewBag.MemberSex = new SelectList(memberSex);

            IEnumerable<tblMember> members = db.tblMember.ToList();


            return View(members);
        }

        public ActionResult Create()
        {
            ViewBag.MemberStatus = new SelectList(memberStatus);
            ViewBag.MemberSex = new SelectList(memberSex);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblMember model)
        {
            tblMember member = new tblMember
            {
                Active = true,
                ActiveInHeist = false,
                Name = model?.Name ?? "",
                Email = model?.Email ?? "",
                Sex = model.Sex,
                Status = model?.Status ?? ""
            };

            db.tblMember.Add(member);
            db.SaveChanges();

            return RedirectToAction("Index", "Member");
        }

        public ActionResult Delete(int? id)
        {
            tblMember member = GetMemberByID(id);

            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMember member = GetMemberByID(id);

            List<tblMemberSkills> lista = db.tblMemberSkills.Where(m => m.MemberID == id).ToList();

            for (int i = 0; i < lista.Count(); i++)
            {
                db.tblMemberSkills.Remove(lista[i]);
                db.SaveChanges();
            }

            db.tblMember.Remove(member);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int? id)
        {
            ViewBag.MemberStatus = new SelectList(memberStatus);
            ViewBag.MemberSex = new SelectList(memberSex);

            tblMember member = new tblMember();
            if (id != null)
            {
                member = GetMemberByID(id);
            }

            return View(member);
        }

        [HttpPost]
        public ActionResult Edit(tblMember model)
        {
            ViewBag.MemberStatus = new SelectList(memberStatus);
            ViewBag.MemberSex = new SelectList(memberSex);

            tblMember member = GetMemberByID(model.MemberID);

            member.Name = model?.Name ?? "";
            member.Email = model?.Email ?? "";
            member.Sex = model?.Sex ?? "";
            member.Status = model?.Status ?? "";
            member.Active = model.Active;
            member.ActiveInHeist = model.ActiveInHeist;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            ViewBag.MemberStatus = new SelectList(memberStatus);
            ViewBag.MemberSex = new SelectList(memberSex);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tblMember member = GetMemberByID(id);

            ViewBag.MemberID = member.MemberID;
                        
            if(member == null)
            {
                return HttpNotFound();
            }

            var skillList = member.tblMemberSkills.OrderBy(m => m.Name).ToArray();

            SkillModel skil = new SkillModel();
            skil.Skills = new List<Skill>();

            skil.MemberID = member.MemberID;
            skil.Name = member.Name;
            skil.Email = member.Email;
            skil.Sex = member.Sex;
            skil.Status = member.Status;
            skil.Active = member.Active;
            skil.ActiveInHeist = member.ActiveInHeist;

            for (int i = 0; i < skillList.Count(); i++)
            {           
                Skill sk = new Skill
                {
                    SkillID = skillList[i].SkillID,
                    Name = skillList[i].Name,
                    Level = skillList[i].SkillLevel
                };

                skil.Skills.Add(sk);
            }

            return View(skil);
        }

        private tblMember GetMemberByID(int? id)
        {
            tblMember member = db.tblMember.SingleOrDefault(m => m.MemberID == id);

            return member;
        }

    }
}