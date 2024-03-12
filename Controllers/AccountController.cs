using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration_Login.Models;
using System.Security.Claims;

namespace Registration_Login.Controllers
{
    public class AccountController : Controller
    {
        public RegistrationDbContext registrationDbContext { get; }
        public AccountController(RegistrationDbContext registrationDbContext) {
            this.registrationDbContext = registrationDbContext;
                }
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult Add_Data()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_Data(AddData adddata)
        {


            var employee = new TableModel()
            {

                UserName = adddata.UserName,
                Email = adddata.Email,
                PhoneNumber = adddata.PhoneNumber,
                Password = adddata.Password,
                ConfirmPassword = adddata.ConfirmPassword

            };
            registrationDbContext.tableModels.Add(employee);
            registrationDbContext.SaveChanges();

            return View("Add_Data");

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginSignupModel loginModel)
        {
            if (ModelState.IsValid)
            {
                 var data= registrationDbContext.tableModels.Where(e=> e.UserName== loginModel.UserName).SingleOrDefault();
                // var data = await registrationDbContext.tableModels.FindAsync(loginModel.Id);
                
                if (data != null)
                {
                    bool isValid=(data.UserName==loginModel.UserName && data.Password==loginModel.Password);
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, loginModel.UserName) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var principle= new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                        HttpContext.Session.SetString("UserName", loginModel.UserName);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["errorMassege"] = "Invalid Password";
                        return View("Add_Data");
                    }
                }
                else
                {
                    TempData["errorMassge"] = "User not found";
                    return View("Add_Data");
                }
            }
            else
            {
                return View("Add_Data");
            }

            
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Account");
        }

        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SignUp( LoginSignupModel loginSignupModel)
        {
            return View();
        }

    }
}
