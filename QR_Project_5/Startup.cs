using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QR_Project_5.Models;
using System.Security.Claims;

[assembly: OwinStartupAttribute(typeof(QR_Project_5.Startup))]
namespace QR_Project_5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }



        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool    
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   
                string Email = "admin@gmail.com";
                string Password = "123456";
                var myUser = UserManager.FindByEmail(Email);
                if (myUser == null)
                {
                    myUser = new ApplicationUser { UserName = Email, Email = Email };
                    var result = UserManager.Create(myUser, Password);
                    if (result.Succeeded)
                    {
                        var result2 = UserManager.AddToRole(myUser.Id, "Admin");
                    }
                }
                else
                {
                    var result2 = UserManager.AddToRole(myUser.Id, "Admin");
                }
            }

            // creating Creating Manager role     
            if (!roleManager.RoleExists("Cliente"))
            {
                var role = new IdentityRole
                {
                    Name = "Cliente"
                };
                roleManager.Create(role);

            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("Empleado"))
            {
                var role = new IdentityRole
                {
                    Name = "Empleado"
                };
                roleManager.Create(role);

            }
        }


    }
}
