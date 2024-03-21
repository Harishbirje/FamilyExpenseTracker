using FamilyExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyExpenseTracker.Controllers
{
    public class FamilyMembersController : Controller
    {
        // GET: FamilyMembers
        public ActionResult GetFamilyMembers()
        {
            FamilyMemberModelManager familyMemberModelManager = new FamilyMemberModelManager();
            List<FamilyMember> familyMembers = familyMemberModelManager.GetFamilyMembers();
            return View(familyMembers);
        }
        //is going to present user with Empty form
        [HttpGet]
        public ActionResult AddFamilyMember()
        {
            FamilyMember familyMember = new FamilyMember();
            return View(familyMember);
        }
        //to store data entered inthe form
        [HttpPost]
        public ActionResult AddFamilyMember(FamilyMember familyMember)
        {
            if (ModelState.IsValid)
            {
                FamilyMemberModelManager familyMemberModelManager = new FamilyMemberModelManager();
                bool isAdded = familyMemberModelManager.AddFamilyMember(familyMember);
                if (isAdded)
                {
                    return RedirectToAction("GetFamilyMembers");
                }
            }
            return View(familyMember);
        }
        // Is going To present user with filled data
        [HttpGet]
        public ActionResult EditFamilyMember(int Id)
        {
            FamilyMemberModelManager familyMemberModelManager = new FamilyMemberModelManager();
            List<FamilyMember> familyMembers = familyMemberModelManager.GetFamilyMembers();
            FamilyMember fm = new FamilyMember();
            foreach (var familyMember in familyMembers)
            {
                if (familyMember.FamilyMemberId == Id)
                {
                    fm = familyMember;
                    break;
                }
            }
            return View(fm);
        }
        //Is going to store Updated data
        [HttpPost]
        public ActionResult EditFamilyMember(FamilyMember familyMember)
        {
            FamilyMemberModelManager familyMemberModelManager = new FamilyMemberModelManager();
            bool isEdited = familyMemberModelManager.EditFamilyMember(familyMember);
            if (isEdited)
            {
                return RedirectToAction("GetFamilyMembers");
            }
            return View();
        }
        //Delete Family Member From Db
        [HttpGet]
        public ActionResult DeleteFamilyMember(int Id)
        {
            FamilyMemberModelManager familyMemberModelManager = new FamilyMemberModelManager();
            bool isDeleted = familyMemberModelManager.DeleteFamilyMember(Id);
            if (isDeleted)
            {
                return RedirectToAction("GetFamilyMembers");
            }
            return View();
        }

    }
}