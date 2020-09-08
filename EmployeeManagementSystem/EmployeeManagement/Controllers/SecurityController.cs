using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    public class SecurityController : Controller
    {
        private readonly UserManager<Employee> userManager;
        private readonly SignInManager<Employee> signInManager;
        private readonly IEmailSender emailSender;

        public SecurityController(
            UserManager<Employee> userManager,
            SignInManager<Employee> signInManager,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            //var model = new LoginViewModel { ReturnUrl = returnUrl };
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl)
        {
            //returnUrl = Request.QueryString.ToString();
            string a = HttpContext.Request.Query["ReturnUrl"];
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName,
                   model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    
                    Console.WriteLine("Hello: "+returnUrl+" ok"+a);
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid login attempt");

            }
            //if (!ModelState.IsValid)
            //    return View(model);

            //var user = await this.userManager.FindByNameAsync(model.Username);
            //if (user != null)
            //{
            //    if (!await this.userManager.IsEmailConfirmedAsync(user))
            //    {
            //        ModelState.AddModelError(string.Empty,
            //                  "Confirm your email please");
            //        return View(model);
            //    }
            //}

            //var result = await this.signInManager.PasswordSignInAsync(
            //    model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);

            //if (result.Succeeded)
            //    return RedirectToAction("Index", "Home");

            //ModelState.AddModelError(string.Empty, "Login Failed");


            return View(model);
        }

        
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new Employee { UserName = model.UserName,Email=model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            //if (!ModelState.IsValid)
            //    return View(model);

            //var user = new AppIdentityUser
            //{
            //    UserName = model.UserName,
            //    Email = model.Email,
            //    Age = model.Age
            //};

            //var result =  this.userManager.CreateAsync(user, model.Password);
            //if (result.IsCompletedSuccessfully)
            //{
            //    var confrimationCode =
            //          this.userManager.GenerateEmailConfirmationTokenAsync(user);

            //    var callbackurl = Url.Action(
            //        controller: "Security",
            //        action: "ConfirmEmail",
            //        values: new { userId = user.Id, code = confrimationCode },
            //        protocol: Request.Scheme);

            //     this.emailSender.SendEmailAsync(
            //        email: user.Email,
            //        subject: "Confirm Email",
            //        htmlMessage: callbackurl);

            //    return RedirectToAction("Index", "Home");
            //}

            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return RedirectToAction("Index", "Home");

            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");

            var result = await this.userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return View("ConfirmEmail");

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return View();

            var user = await this.userManager.FindByEmailAsync(email);
            if (user == null)
                return RedirectToAction("ForgotPasswordEmailSent");

            //if (!await this.userManager.IsEmailConfirmedAsync(user))
            //    return RedirectToAction("ForgotPasswordEmailSent");

            var confrimationCode = await userManager.GeneratePasswordResetTokenAsync(user);

            var callbackurl = Url.Action(
                controller: "Security",
                action: "ResetPassword",
                values: new { userId = user.Id, code = confrimationCode },
                protocol: Request.Scheme);

            //await this.emailSender.SendEmailAsync(
            //    email: user.Email,
            //    subject: "Reset Password",
            //    htmlMessage: callbackurl);     
            Console.WriteLine(callbackurl);
            TempData["url"] = callbackurl;
            //logger.Log(LogLevel.Warning, callbackurl);

            

            return RedirectToAction("ForgotPasswordEmailSent");
        }

        [AllowAnonymous]
        public IActionResult ForgotPasswordEmailSent()
        {
            ViewBag.NewPassword = TempData["url"];
            return View();
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string userId, string code)
        {
            if (userId == null || code == null)
                throw new ApplicationException("Code must be supplied for password reset.");

            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await this.userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return RedirectToAction("ResetPasswordConfirm");

            var result = await this.userManager.ResetPasswordAsync(
                                        user, model.Code, model.Password);
            if (result.Succeeded)
            {
                user.Password = model.Password;
                user.ConfirmPassword = model.ConfirmPassword;
               var result2 = await userManager.UpdateAsync(user);
                if(result2.Succeeded)
                return RedirectToAction("ResetPasswordConfirm");
                else
                    return RedirectToAction("ResetPasswordConfirm");

            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }


        [AllowAnonymous]
        public IActionResult ResetPasswordConfirm()
        {
            return View();
        }
    }
}