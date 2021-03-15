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

        private readonly SelectList memberGender = new SelectList(new[] { "M", "F" });
        private readonly SelectList memberStatus = new SelectList(new[] { "AVAILABLE", "EXPIRED", "INCARCERATED", "RETIRED" });
                
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.MemberStatus = new SelectList(memberStatus);
            ViewBag.memberGender = new SelectList(memberGender);

            IEnumerable<tblMember> members = db.tblMember.ToList();


            return View(members);
        }

        public ActionResult Create()
        {
            ViewBag.MemberStatus = new SelectList(memberStatus);
            ViewBag.memberGender = new SelectList(memberGender);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblMember model)
        {
            tblMember member = new tblMember
            {
                Active = true,
                //ActiveInHeist = false,
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
            ViewBag.memberGender = new SelectList(memberGender);

            tblMember member = new tblMember();
            if (id != null)
            {
                member = GetMemberByID(id);
            }

            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblMember model)
        {
            ViewBag.MemberStatus = new SelectList(memberStatus);
            ViewBag.memberGender = new SelectList(memberGender);

            tblMember member = GetMemberByID(model.MemberID);

            member.Name = model?.Name ?? "";
            member.Email = model?.Email ?? "";
            member.Sex = model?.Sex ?? "";
            member.Status = model?.Status ?? "";
            member.Active = model.Active;
            //member.ActiveInHeist = model.ActiveInHeist;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            ViewBag.MemberStatus = new SelectList(memberStatus);
            ViewBag.memberGender = new SelectList(memberGender);

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

            MemberModel mem = new MemberModel();
            mem.Skills = new List<MemberSkill>();

            mem.MemberID = member.MemberID;
            mem.Name = member.Name;
            mem.Email = member.Email;
            mem.Sex = member.Sex;
            mem.Status = member.Status;
            mem.Active = member.Active;
            //mem.ActiveInHeist = member.ActiveInHeist;

            for (int i = 0; i < skillList.Count(); i++)
            {
                MemberSkill sk = new MemberSkill
                {
                    SkillID = skillList[i].SkillID,
                    Name = skillList[i].Name,
                    Level = skillList[i].SkillLevel
                };

                mem.Skills.Add(sk);
            }

            return View(mem);
        }

        private tblMember GetMemberByID(int? id)
        {
            tblMember member = db.tblMember.SingleOrDefault(m => m.MemberID == id);

            return member;
        }
    }
}