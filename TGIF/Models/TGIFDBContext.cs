using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace TGIF.Models
{
    public class TGIFDBContext : DbContext
    {
       public TGIFDBContext()
                : base("TGIFDBConnection")
       {
       }

       public DbSet<UserProfile> UserProfiles { get; set; }
       public DbSet<Event> Events { get; set; }
       public DbSet<UserEvent> UserEvents { get; set; }
       public DbSet<Volunteer> Volunteers { get; set; }
       public DbSet<FAQ> FAQs { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           //modelBuilder.Entity<UserProfile>()
           // .HasOptional(f => f.Volunteer)
           // .WithRequired();
       }

       public static void InitializeDB()
       {
           if (!WebSecurity.Initialized)
           {
               WebSecurity.InitializeDatabaseConnection(
                  "TGIFDBConnection",
                  "UserProfile",
                  "UserId",
                  "UserName", autoCreateTables: true);
           }

           //context.UserProfiles.
           if (!Roles.RoleExists("Administrator"))
               Roles.CreateRole("Administrator");

           if (!WebSecurity.UserExists("admin"))
               WebSecurity.CreateUserAndAccount(
                   "admin",
                   "admin#1",
                   new {SecurityCode= "admin",
                   ParentName= "admin",
                   StudentName= "admin",
                   SchoolName= "admin",
                   HomePhone= "000000000",
                   HomeAddress= "admin"
                   },
                   false

                   );

           if (!WebSecurity.UserExists("test1@hotmail.com"))
               WebSecurity.CreateUserAndAccount(
                   "test1@hotmail.com",
                   "123456",
                   new
                   {
                       SecurityCode = "0123546789",
                       ParentName = "Test1 Parent",
                       StudentName = "Test1 Student",
                       SchoolName = "Test1 School",
                       HomePhone = "000000000",
                       HomeAddress = "Test1 Address"
                   },
                   false

                   );

           if (!Roles.GetRolesForUser("admin").Contains("Administrator"))
               Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });
       }

       
    }
}