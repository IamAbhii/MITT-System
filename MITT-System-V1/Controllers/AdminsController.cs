using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MITT_System_V1.Models;

namespace MITT_System_V1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminsController : Controller
    {
        // GET: Admins
        ApplicationDbContext db = new ApplicationDbContext();
        RoleManager<IdentityRole> rolesManager;
        UserManager<ApplicationUser> usersManager;
        UserManagement manager;
        public AdminsController()
        {
            rolesManager = new RoleManager<IdentityRole>
               (new RoleStore<IdentityRole>(db));
            usersManager = new UserManager<ApplicationUser>
            (new UserStore<ApplicationUser>(db));
            manager = new UserManagement(db);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}