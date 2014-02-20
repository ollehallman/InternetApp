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

        public ContributesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Contribute> Contributes { get; set; }
    }

    [Table("Contribute")]
    public class Contribute
    {
        public string Contribution { get; set; }

        //[Key][Column(Order=1)]
        [Key]
        public int ContributeNumber { get; set; }

        //[Key][Column(Order = 2)] 
        public int UserId { get; set; }

        //[Key] [Column(Order = 3)]         
        public int ProjectId { get; set; }

        public DateTime DateInserted { get; set; }

    }

    public class ContributeModel
    {
        //public List<Contribute> ContributionsList { get; set; }
        //public List<ContributeUser> ContributeUsers { get; set; }
        public List<ContributeUser> cuList { get; set; }
        public Project Projects { get; set; }
        //public Contribute Contribute { get; set; }
        //public List<UserProfile> UserProfilesList { get; set; }
        public UserProfile UserProfile { get; set; }
    }

    public class ContributeUser
    {
        public string Contribution { get; set; }
        public int ContributionNumber { get; set;}
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateInserted { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
}
}
