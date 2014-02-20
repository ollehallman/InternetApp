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
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name:")]
        [StringLength(255, ErrorMessage = "Your name can't be longer than 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Difficulty is required")]
        [Display(Name = "Difficulty:")]
        public int Difficulty { get; set; }

        [Required(ErrorMessage = "Details is required")]
        [Display(Name = "Details:")]
        [StringLength(8000, ErrorMessage = "The details text can't be longer than 8000 characters.")]
        public string Detail { get; set; }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price:")]
        public decimal Price { get; set; }
      
        public int UserId { get; set; }

        [Required(ErrorMessage = "Skill name is required")]
        [Display(Name = "Skill name:")]
        [StringLength(225, ErrorMessage = "Your skill name can't be longer than 225 characters.")]
        public string SkillName { get; set; }


        public UserProfile UserProfiles { get; set; }
    }
}