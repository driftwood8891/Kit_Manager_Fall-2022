using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kit_Manager_Fall_2022.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            Course = new HashSet<Course>();
        }

        [Key]
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
