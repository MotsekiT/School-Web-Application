using GA1_Intergration.Models;
using GA1_Intergration.Repository.Account;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
/*
220000213 M Tshabalala
219014331 SL Hadebe
219007267 MP Tsoaela    
*/
namespace GA1_Intergration.Controllers
{
    public class AccountController : Controller
    {
        private AccountRepository _accountRepository;

        public AccountController()
        {
            _accountRepository = new AccountRepository();
        }
        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignUp(SignUp signUp)
        {
            try
            {
               await _accountRepository.SignUp(signUp);
                ModelState.AddModelError(string.Empty, "Kindly verify your email then login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(signUp);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                if(this.Request.IsAuthenticated)
                {
                    return this.RedirectToLocal(returnUrl);
                }
            }
            catch (Exception ex)
            {
                
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        
        public async Task<ActionResult> Login(Models.Login login, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                IOwinContext owinContext = Request.GetOwinContext();
                string returnValue = await _accountRepository.Login(login, returnUrl, owinContext);
            
                if(!String.IsNullOrEmpty(returnValue) && returnValue == "Admin" || returnValue == "User")
                {
                    System.Web.HttpContext.Current.Session.Add("Email", login.Email);
                    if(returnValue == "Admin")
                    {
                        System.Web.HttpContext.Current.Session.Add("AccessRight", "Admin");
                    }
                    if (returnValue == "User")
                    {
                        System.Web.HttpContext.Current.Session.Add("AccessRight", "User");
                    }

                    return RedirectToAction("Index", "Home");

                }

                else
                {
                    ModelState.AddModelError(string.Empty, returnValue);
                }
            
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login credentials");
            }
            return View(login);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                if(Url.IsLocalUrl(returnUrl))
                {
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            System.Web.HttpContext.Current.Session.RemoveAll();
            System.Web.HttpContext.Current.Session.Clear();
            return RedirectToAction("Index", "Home", "Home");
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword(string EmailID)
        {
            try
            {
                await _accountRepository.ResetPasswordLink(EmailID);
                ViewBag.Message = $"Reset password link sent to {EmailID}";
                ModelState.AddModelError(string.Empty, "Kindly verify your email to login.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }
    }
}