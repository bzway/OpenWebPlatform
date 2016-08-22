using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    [Table("Activity")]
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DU { get; set; }
        public DateTime? ES { get; set; }
        public DateTime? EF { get; set; }
        public DateTime? LS { get; set; }
        public DateTime? LF { get; set; }
        public int? Slack { get; set; }
        public int? ParentId { get; set; }
        
        [ForeignKey("ParentId")]
        public virtual Activity Parent { get; set; }
        public virtual ICollection<Activity> SubActivities { get; set; }
        
        [ForeignKey("ForwardActivityId")]
        public ICollection<ActivityDependence> BackwardActivity { get; set; }
        [ForeignKey("BackwardActivityId")]
        public ICollection<ActivityDependence> ForwardActivity { get; set; }
    }
    [Table("ActivityDependence")]
    public class ActivityDependence
    {
        [Key]
        public int Id { get; set; }

        public int? ForwardActivityId { get; set; }

        public int? BackwardActivityId { get; set; }
        public DependenceType DependenceType { get; set; }
        [ForeignKey("BackwardActivityId")]
        public virtual Activity ForwardActivity { get; set; }
        [ForeignKey("ForwardActivityId")]
        public virtual Activity BackwardActivity { get; set; }
    }
    public enum DependenceType
    {
        Finish2Start = 0,
        Finish2Finish,
        Start2Start,
        Start2Finish,
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityDependence> ActivityDependences { get; set; }
    }
}