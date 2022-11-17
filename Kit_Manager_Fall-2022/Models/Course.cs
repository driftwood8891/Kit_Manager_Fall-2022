using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kit_Manager_Fall_2022.Models
{
    public partial class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int InstructorId { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
