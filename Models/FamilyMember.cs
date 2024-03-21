using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FamilyExpenseTracker.Models
{
    public class FamilyMember
    {
        public int FamilyMemberId {  get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name {  get; set; }
        [Required(ErrorMessage = "Cell is Required")]
        [RegularExpression("/^\\d{10}$/")]
        public string Cell {  get; set; }
        [Required(ErrorMessage = "Work is Required")]
        public string Work {  get; set; }
        [Required(ErrorMessage = "Income is Required")]
        [Range(10000,200000,ErrorMessage ="Income is Reqired.It must be between 10000-200000")]
        public int Income {  get; set; }
    }
}