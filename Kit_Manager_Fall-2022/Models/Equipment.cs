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
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public int ItemCost { get; set; }
        public int KitId { get; set; }
        public int StatusCode { get; set; }
        public string StudentId { get; set; }
        public DateTime LastEdit { get; set; }
        public string InstructorName { get; set; }
        public string Course { get; set; }
        public string Active { get; set; }

        public virtual Status StatusCodeNavigation { get; set; }
        public virtual Student Student { get; set; }
    }
}
