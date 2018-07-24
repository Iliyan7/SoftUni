using App.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models.BindingModels
{
    public class BookBorrowModel
    {
        [Display(Name = "Name")]
        public int BorrowerId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DateGreatherThan("StartDate", ErrorMessage = "End Date must be after Start Date!")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
    }
}
