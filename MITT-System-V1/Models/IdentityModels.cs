using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;

namespace MITT_System_V1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool? IsOnVisa { get; set; }
        public DateTime DOB { get; set; }
        public Persontype? Type { get; set; }
        public virtual ICollection<ApplicationUserCourse> Curses { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationUserCourse
    { 
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime DateOfJoin { get; set; }
    }
    public enum Persontype
    {
        Admin,
        Teacher,
        Student,
    }
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Capacity { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<ApplicationUserCourse> ApplicationUsers { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}