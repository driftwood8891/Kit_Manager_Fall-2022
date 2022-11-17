using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kit_Manager_Fall_2022.Models
{
    public partial class Equipment
    {
        [Key]
        public int ItemId { get; set; }
        [Display(Name = "Item Type")]
        [Required(ErrorMessage = "Type of item is required.")]
        public string ItemType { get; set; }
        [Display(Name = "Item Name")]
        [Required(ErrorMessage = "Item name is required.")]
        public string ItemName { get; set; }
        [Display(Name = "Item Cost")]
        [Required(ErrorMessage = "Item cost is required.")]
        public int ItemCost { get; set; }
        [Display(Name = "Kit ID")]
        [Required(ErrorMessage = "Kit ID is required.")]
        public int KitId { get; set; }
        [Display(Name = "Status Code")]
        [Required(ErrorMessage = "Enter a number between 1 and 9.")]
        [Range (1,9)]
        public int StatusCode { get; set; }
        [Display(Name = "Student ID")]
        [Required(ErrorMessage = "Student ID is required.")]
        public string StudentId { get; set; }
        [Display(Name = "Last Change or Edit")]
        [Required(ErrorMessage = "Date and Time is required.")]
        public DateTime LastEdit { get; set; }
        [Display(Name = "Instructor Name")]
        [Required(ErrorMessage = "Instructor name is required.")]
        public string InstructorName { get; set; }
        [Display(Name = "Course")]
        [Required(ErrorMessage = "Name of course is required.")]
        public string Course { get; set; }
        [Display(Name = "Is Item Active?")]
        [Required(ErrorMessage = "'Y' or 'N' required.")]
        public string Active { get; set; }

        public virtual Status StatusCodeNavigation { get; set; }
        public virtual Student Student { get; set; }
    }
}
