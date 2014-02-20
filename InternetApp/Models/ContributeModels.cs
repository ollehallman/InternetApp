using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;


namespace InternetApp.Models
{
    public class ContributesContext : DbContext
    {
        private string p;

        public ContributesContext()
            : base("DefaultConnection")
        {
        }

        public ContributesContext(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public DbSet<Contribute> Contributes { get; set; }
    }

    [Table("Contribute")]
    public class Contribute
    {
        [Required(ErrorMessage = "Contribution is required")]
        [Display(Name = "Contribution")]
        [StringLength(4000, ErrorMessage = "Your contribution can't be longer than 4000 characters.")]
        public string Contribution { get; set; }

        [Key]
        public int ContributeNumber { get; set; }

        public int UserId { get; set; }
        
        public int ProjectId { get; set; }

        public DateTime DateInserted { get; set; }

        //foregin keys 
        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

    }








}