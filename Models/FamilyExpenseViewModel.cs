using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyExpenseTracker.Models
{
    public class FamilyExpenseViewModel
    {
        public int Id { get; set; }
        public string FamilyMemberName { get; set; }
        public string Purpose { get; set; }
        public int Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public SelectList FamilyMembers { get; set; }
    }
}