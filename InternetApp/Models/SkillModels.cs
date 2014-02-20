using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace InternetApp.Models
{
    public class SkillsContext : DbContext
    {
        public SkillsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Skill> Skills { get; set; }
    }

    [Table("Skill")]
    public class Skill
    {
        [Key]
        [Required(ErrorMessage = "Skill name is required")]
        [Display(Name = "Skill name:")]
        [StringLength(225, ErrorMessage = "Your skill name can't be longer than 225 characters.")]
        public string SkillName { get; set; }
    }
}