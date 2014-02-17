using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace InternetApp.Models
{
    public class ProjectsContext : DbContext
    {
        public ProjectsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Project> Projects { get; set; }
    }

    [Table("Project")]
    public class Project
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public string Detail { get; set; }
        [Key]
        public int ProjectId { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set;}
        public string Skill { get; set; }
        public UserProfile UserProfiles { get; set; }
    }
}