using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MITT_System_V1.Models
{
    public class UserManagement
    {
        ApplicationDbContext db;
        UserManager<ApplicationUser> userManager;

        public UserManagement(ApplicationDbContext db)
        {
            this.db = db;
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        public bool IsUserInRole(string userId,string roleName)
        {
            return userManager.IsInRole(userId, roleName);
        }

        public string GetUserRole(string userId)
        {
            return userManager.GetRoles(userId).First();
        }

        public bool AddUserToRole(string roleName,string userId)
        {
            var result = userManager.AddToRole(userId, roleName);
            return result.Succeeded;
        }
        public bool RemoveUserFromRole(string userId, string roleName)
        {
            var result = userManager.RemoveFromRole(userId, roleName);
            return result.Succeeded;
        }

        public ICollection<ApplicationUser> UsersInRoles(string roleName)
        {
            var result = new List<ApplicationUser>();
            var allUsers = db.Users;

            foreach(var user in allUsers)
            {
                if (IsUserInRole(user.Id, roleName))
                {
                    result.Add(user);
                }
            }

            return result;
        }

    }
}