//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using System.Threading.Tasks;
//using System.Net;
//using InfinityProject.Models;
//using InfinityProject;

//namespace InfinityProject.Controllers
//{
//    public class RoleController : Controller
//    {
//        private ApplicationDbContext _db = new ApplicationDbContext();
//        private ApplicationUserManager _userManager;
//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            set
//            {
//                _userManager = value;
//            }
//        }



//        [Authorize(Roles = "Admin")]
//        public ActionResult Index()
//        {
//            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));
//            return View(RoleManager.Roles);
//        }
//        [Authorize(Roles = "Admin")]
//        public ActionResult AssignRoles()
//        {
//            ViewBag.feed = null;
//            var RoleManagerz = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));
//            ViewBag.Employee = new SelectList(_db.Users.ToList(), "Email", "Email");
//            ViewBag.Role = new SelectList(RoleManagerz.Roles, "Name", "Name");
//            return View();
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult AssignRoles(RoleViewModel model)
//        {
//            var RoleManagerz = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));
//            ViewBag.Employee = new SelectList(_db.Users.ToList(), "Email", "Email");
//            ViewBag.Role = new SelectList(RoleManagerz.Roles, "Name", "Name");
//            //try
//            //{

//            bool task = false;
//            task = AssignToRole(_db, model.Employee, model.Role);
//            if (task == true)
//            {
//                ViewBag.feed = model.Employee + " is assigned to the role successfully, This user must use its current password";
//            }
//            else
//            {
//                ViewBag.feed = "Something went wrong, User is not assigned to the role check that the user is not in another Role";
//            }
//            //}
//            //catch (Exception c)
//            //{

//            //    ViewBag.feed += c.Message;
//            //}
//            ViewBag.Employee = new SelectList(_db.Users.ToList(), "Email", "Email");
//            ViewBag.Role = new SelectList(RoleManagerz.Roles, "Name", "Name");
//            return View();
//        }

//        public bool AssignToRole(ApplicationDbContext context, string email, string role)
//        {
//            IdentityResult ir;
//            var rm = new RoleManager<IdentityRole>
//            (new RoleStore<IdentityRole>(context));
//            var um = new UserManager<ApplicationUser>
//           (new UserStore<ApplicationUser>(context));

//            var _user = context.Users.ToList().Find(x => x.Email == email);

//            ApplicationUser newuser = new ApplicationUser();

//            //if (_user == null)
//            //{
//            //    newuser.UserName = email;
//            //    newuser.PhoneNumber = null;
//            //    newuser.Email = email;

//            //    ir = um.Create(newuser, _user.PasswordHash);
//            //    if (ir.Succeeded == false)
//            //        return ir.Succeeded;

//            //    ir = um.AddToRole(newuser.Id, role);
//            //    return ir.Succeeded;
//            //}
//            ir = um.AddToRole(_user.Id, role);
//            return ir.Succeeded;
//        }

//        //public async Task SendConfirmEmail(ApplicationUser user, string email, string name, string role, string pass)
//        //{
//        //    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
//        //    var callbackUrl = Url.Action("ConfirmEmail", "Account",
//        //       new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);


//        //    var myMessage = new SendGridMessage();

//        //    myMessage.From = new MailAddress("debuggers@outlook.com", "WHSIC");

//        //    myMessage.AddTo(email);

//        //    string subject = "Role";

//        //    string html = "<table style=\"border: none; font-family: verdana, tahoma, sans-serif;\">" +
//        //                  "<tr> " +
//        //                      "<td> <h3>Hello " + name + ", </h3> <p>You are given a Role at Welcome Holy Spirit International Church to be the " + role + " your username is your email address and this is your password <strong style=\"color: blue;\">" + pass + "</strong> remember to change it once you login at WHSIC website. In order for you to login confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a> </p>" +
//        //                      "<p>Regards,<br/>  Welcome holy Spirit International Church - Communications Team</p> </td> </tr> </table>";

//        //    myMessage.Subject = subject;
//        //    myMessage.Html = html;


//        //    var transportWeb = new Web("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");
//        //    // Send the email.
//        //    await transportWeb.DeliverAsync(myMessage);
//        //}


//        [Authorize(Roles = "Admin")]
//        public ActionResult Create()
//        {
//            return View();
//        }
//        [Authorize(Roles = "Admin")]
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create(NewRole roleViewModel)
//        {
//            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));


//            IdentityResult result = null;

//            if (!RoleManager.RoleExists(roleViewModel.Role))
//            {
//                result = await RoleManager.CreateAsync(new IdentityRole(roleViewModel.Role));
//            }
//            else
//            {
//                ModelState.AddModelError("", "Role already exists.");
//            }

//            try
//            {
//                if (result.Succeeded)
//                    return RedirectToAction("Index");
//            }
//            catch (Exception)
//            {
//                ModelState.AddModelError("", "Role not Saved.");
//            }
//            return View(roleViewModel);
//        }
//        [Authorize(Roles = "Admin")]
//        public async Task<ActionResult> Details(string id)
//        {
//            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            var role = await RoleManager.FindByIdAsync(id);
//            // Get the list of Users in this Role
//            var users = new List<ApplicationUser>();

//            // Get the list of Users in this Role
//            foreach (var user in UserManager.Users.ToList())
//            {
//                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
//                {
//                    users.Add(user);
//                }
//            }

//            ViewBag.Users = users;
//            ViewBag.UserCount = users.Count();
//            return View(role);
//        }

//        //public string GeneratePassword()
//        //{
//        //    string pass = "";
//        //    for (int i = 0; i < 100; i++)
//        //    {
//        //        pass = rp.Generate(8, 10);
//        //    }
//        //    return pass;
//        //}
//        [Authorize(Roles = "Admin")]
//        public ActionResult DeleteRolesAsync()
//        {
//            ViewBag.feed = null;
//            ViewBag.Employee = new SelectList(_db.Users.ToList(), "Email", "Email");
//            return View();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteRolesAsync(RemoveFromRole model)
//        {
//            ViewBag.Employee = new SelectList(_db.Users.ToList(), "Email", "Email");
//            string feed = "something went wrong, User is not Removed in Role. check that the user is role bofore attempt to Remove";
//            var RoleManagerz = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));

//            try
//            {
//                var user = _db.Users.ToList().Find(x => x.UserName == model.user);

//                if (user.Id != null)
//                {
//                    foreach (var roleName in RoleManagerz.Roles)
//                    {
//                        IdentityResult deletionResult = await UserManager.RemoveFromRoleAsync(user.Id, roleName.Name);
//                        feed = "User is Removed from the Role";
//                    }
//                    ViewBag.feed = feed;
//                }
//                else
//                {
//                    ViewBag.feed = "The user you are trying to Remove from Role was not assigned in the Role";
//                }
//            }
//            catch (Exception c)
//            {

//                ViewBag.feed = "The user you are trying to Remove from Role was not assigned in the Role";
//            }

//            ViewBag.Employee = new SelectList(_db.Users.ToList(), "Email", "Email");
//            return View(model);
//        }
//    }
//}
