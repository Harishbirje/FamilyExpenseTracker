using FamilyExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyExpenseTracker.Controllers
{
    public class FamilyExpenseController : Controller
    {
        FamilyExpenseModelManager familyExpenseModelManager = new FamilyExpenseModelManager();
        // GET: FamilyExpense
        public ActionResult GetFamilyExpenses()
        { 
            List<FamilyExpenseViewModel> familyExpenses = familyExpenseModelManager.GetFamilyExpenses();
            return View(familyExpenses);
        }
        //Get:Present user with Empty form
        [HttpGet]
        public ActionResult AddFamilyExpense()
        {
            FamilyExpenseViewModel familyExpenseViewModel = new FamilyExpenseViewModel();
            List<string> names = familyExpenseModelManager.GetFamilyMemberNames();
            familyExpenseViewModel.FamilyMembers =new SelectList(names);
            return View(familyExpenseViewModel);
        }
        [HttpPost]
        public ActionResult AddFamilyExpense(FamilyExpenseViewModel familyExpenseViewModel)
        {
            bool isAdded = familyExpenseModelManager.AddFamilyExpense(familyExpenseViewModel);
            if (isAdded) 
            {
                return RedirectToAction("GetFamilyExpenses");
            }
            return View(familyExpenseViewModel);
        }
        [HttpGet]
        public ActionResult EditFamilyExpense(int id)
        {
            //Based on passed expense id get expense data
            List<FamilyExpenseViewModel> familyExpenseViewModels = familyExpenseModelManager.GetFamilyExpenses();
            FamilyExpenseViewModel familyExpenseViewModelResult = new FamilyExpenseViewModel();
            foreach(var familyExpenseViewModel in familyExpenseViewModels)
            {
                if(familyExpenseViewModel.Id == id)
                {
                    familyExpenseViewModelResult = familyExpenseViewModel;
                }
            }
            //Option to DropdownList
            List<string> names = familyExpenseModelManager.GetFamilyMemberNames();
            familyExpenseViewModelResult.FamilyMembers = new SelectList(names);

            return View(familyExpenseViewModelResult);
        }
        //Save Edited Expense Data
        [HttpPost]
        public ActionResult EditFamilyExpense(FamilyExpenseViewModel familyExpenseViewModel)
        {
            bool isEdited = familyExpenseModelManager.EditFamilyExpense(familyExpenseViewModel);
            if(isEdited) 
            {
                return RedirectToAction("GetFamilyExpenses");
            }
            return View(familyExpenseModelManager);
        }
        [HttpPost]
        public ActionResult DeleteFamilyExpense(int id)
        {
            bool isDeleted = familyExpenseModelManager.DeleteFamilyExpense(id);
            if(isDeleted)
            {
                return RedirectToAction("GetFamilyExpenses");
            }
            return View();
        }
    }
}