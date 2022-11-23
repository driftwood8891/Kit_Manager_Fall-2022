using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kit_Manager_Fall_2022.Models
{
    public partial class Student
    {
        public Student()
        {
            Equipment = new HashSet<Equipment>();
        }

        [Key]
        [Display(Name = "Student ID")]
        [Required(ErrorMessage = "Student ID is required.")]
        public string StudentId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LName { get; set; }
        [Display(Name = "College Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string CollegeEmail { get; set; }
        [Display(Name = "Personal Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string PersonalEmail { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required.")]
        [Phone]
        public string Phone { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Display(Name = "Campus")]
        [Required(ErrorMessage = "Name of Campus is required.")]
        public string Campus { get; set; }
        [Display(Name = "Is Student Active?")]
        [Required(ErrorMessage = "'Y' or 'N' is required.")]
        public string Active { get; set; }
        [Display(Name = "Does the Student have a kit?")]
        [Required(ErrorMessage = "'Y' or 'N' is required.")]
        public string HasItem { get; set; }
        [Display(Name = "Last Change or Edit")]
        [Required(ErrorMessage = "Date and time is required.")]
        public DateTime LastEdit { get; set; }
        [Display(Name = "Emergency Contact")]
        [Required(ErrorMessage = "Name, Phone #, and Address is required.")]
        public string EmergencyContact { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
