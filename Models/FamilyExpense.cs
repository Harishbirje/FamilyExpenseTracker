using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyExpenseTracker.Models
{
    public class FamilyExpense
    {
        public int Id { get; set; }
        public int FamilyMemberId {  get; set; }
        public string Purpose {  get; set; }
        public int Amount {  get; set; }
        public DateTime Date {  get; set; }
    }
}