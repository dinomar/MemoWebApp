using MemoWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MemoWebApp.Startup))]
namespace MemoWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesAndUsers();
        }

        private void createRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists("Admin"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPWD = "Adminroot!1";

                IdentityResult chkUser = userManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    IdentityResult result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("User"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

                ApplicationUser user = new ApplicationUser();
                user.UserName = "billy";
                user.Email = "billy@gmail.com";
                string userPWD = "Billy!11";

                IdentityResult chkUser = userManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    IdentityResult result1 = userManager.AddToRole(user.Id, "User");
                }
            }
        }
    }
}
