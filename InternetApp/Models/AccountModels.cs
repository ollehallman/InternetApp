using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace InternetApp.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        [StringLength(150, ErrorMessage = "Your username can't be longer than 150 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First name")]
        [StringLength(150, ErrorMessage = "Your first name can't be longer than 150 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last name")]
        [StringLength(150, ErrorMessage = "Your last name  can't be longer than 150 characters.")]
        public string LastName { get; set; }
        
        [Display(Name = "Phone")]
        [StringLength(30, ErrorMessage = "Your phonenumber can't be longer than 30 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Your email can't be longer than 100 characters.")]
        [EmailAddress]
        public string Email { get; set; }
        public List<Project> Projects { get; set; }
    }

    public class UserDetailsModel
    {

        public UserProfile UserProfiles { get; set; }
        public List<Project> Projects { get; set; }
        /*
        public UserDetailsModel(IEnumerable<InternetApp.Models.Project> projects, IEnumerable<InternetApp.Models.UserProfile> userProfiles)
        {
            IEnumerable<InternetApp.Models.UserProfile> UserProfiles = userProfiles;
            IEnumerable<InternetApp.Models.Project> Projects = projects;
        }*/
    }

    public class AccountSearchModel
    {
        public List<UserProfile> UserProfiles { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage="Username is required")]
        [Display(Name = "Username")]
        [StringLength(150, ErrorMessage = "Your username can't be longer than 150 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First name")]
        [StringLength(150, ErrorMessage = "Your first name can't be longer than 150 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last name")]
        [StringLength(150, ErrorMessage = "Your last name can't be longer than 150 characters.")]
        public string LastName { get; set; }
        
        [Display(Name = "Phone")]
        [StringLength(30, ErrorMessage = "Your phonenumber can't be longer than 30 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Your email can't be longer than 100 characters.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
