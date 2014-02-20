using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace InternetApp.Models
{
    public class SkillLevelsContext : DbContext
    {
        public SkillLevelsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<SkillLevel> SkillLevels { get; set; }
    }

    [Table("SkillLevel")]
    public class SkillLevel
    {
        [Key]
        [Required(ErrorMessage = "Skill name is required")]
        [Display(Name = "Skill name:")]
        [StringLength(225, ErrorMessage = "Your skill name can't be longer than 225 characters.")]
        public string SkillName { get; set; }
        public int UserId { get; set; }
        public int Level { get; set; }
        public SkillLevel SkillLevels { get; set; }
    }
}