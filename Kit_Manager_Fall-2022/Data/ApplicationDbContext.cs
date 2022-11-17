using Kit_Manager_Fall_2022.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kit_Manager_Fall_2022.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campus> Campus { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<KitBuilder> KitBuilder { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Student> Student { get; set; }
    }
}
