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
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly UserManager<Employee> userManager;
        private readonly SignInManager<Employee> signInManager;
        private readonly IEmailSender emailSender;

        public IConfiguration Configuration { get; }

        public SecurityController(
            UserManager<Employee> userManager,
            SignInManager<Employee> signInManager,
            IEmailSender emailSender,IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            Configuration = configuration;
            
        }

        //[AllowAnonymous]
        //public IActionResult Login(string returnUrl)
        //{
        //    //ViewBag.ReturnUrl = returnUrl;
        //    //return View();
        //    return Ok();
        //}


        [HttpPost("login")]
        // [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            
            if(user !=null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName)
                };
                foreach(var userrole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userrole));
                }
                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                        issuer: Configuration["JWT:ValidIssuer"],
                        audience: Configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(1),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                        );
                return Ok(new
                {
                    userid=user.Id,
                    username=model.UserName,
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return Unauthorized();
            //string a = HttpContext.Request.Query["ReturnUrl"];
            //if (ModelState.IsValid)
            //{
            //    var result = await signInManager.PasswordSignInAsync(model.UserName,
            //       model.Password, model.RememberMe, false);

            //    if (result.Succeeded)
            //    {
                    
            //        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            //        {
            //            return Redirect(returnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //    ModelState.AddModelError("", "Invalid login attempt");

            //}
            
            //return View(model);
        }

        [HttpGet("check")]
        // [Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult AccessDenied()
        {
            //return View();
            return Ok("Hello");
        }

        //public IActionResult GoBack()
        //{
        //    string a = HttpContext.Request.Query["ReturnUrl"];
        //    if (!string.IsNullOrEmpty(a) && Url.IsLocalUrl(a))
        //    {
        //        return Redirect(a);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        //public async Task<IActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}



        //[AllowAnonymous]
        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}

public class EmailTry{
    public string email { get; set; }
}
        [HttpPost("forgotpassword")]
        // [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] EmailTry email)
        {
        //    if (string.IsNullOrEmpty(email))
        //        return View();
        
           var user = await this.userManager.FindByEmailAsync(email.email);
           if (user == null)
           return Ok(new {message="Email is not found"});
            //    return RedirectToAction("ForgotPasswordEmailSent");

           var confrimationCode = await userManager.GeneratePasswordResetTokenAsync(user);

        //    var callbackurl = Url.Action(
        //        controller: "Security",
        //        action: "ResetPassword",
        //        values: new { userId = user.Id, code = confrimationCode },
        //        protocol: Request.Scheme);

        //    TempData["url"] = callbackurl;


        //    return RedirectToAction("ForgotPasswordEmailSent");
                return Ok(new 
                {
                    code=confrimationCode,
                    email=email, 
                    message="link is send."
                });
        }

        // [HttpGet("forgotpasswordlinksent")]
        // [AllowAnonymous]
        // public IActionResult ForgotPasswordEmailSent()
        // {
        // //    ViewBag.NewPassword = TempData["url"];
        //     string url = TempData["url"];
        // //    return View();
        //     reurn Ok(new{link=url});
        // }

        //[AllowAnonymous]
        //public IActionResult ResetPassword(string userId, string code)
        //{
        //    if (userId == null || code == null)
        //        throw new ApplicationException("Code must be supplied for password reset.");

        //    var model = new ResetPasswordViewModel { Code = code };
        //    return View(model);
        //}

        [HttpPost("resetpassword")]
        // [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel model)
        {
        //    if (!ModelState.IsValid)
        //        return View(model);

           var user = await this.userManager.FindByEmailAsync(model.Email);
           if (user == null)
            return Ok(new {message="Password reset is failed with some unknown error."});
            //    return RedirectToAction("ResetPasswordConfirm");

           var result = await this.userManager.ResetPasswordAsync(
                                       user, model.Code, model.Password);
           if (result.Succeeded)
           {
               user.Password = model.Password;
               user.ConfirmPassword = model.ConfirmPassword;
              var result2 = await userManager.UpdateAsync(user);
               if(result2.Succeeded){
                    return Ok(new {message="Password reset is success"});
                //    return RedirectToAction("ResetPasswordConfirm");
               }
               else{
                     return Ok(new {message="Password reset is failed with some unknown error."});
                    // return RedirectToAction("ResetPasswordConfirm");
               }
                 

           }

           foreach (var error in result.Errors)
               ModelState.AddModelError(string.Empty, error.Description);
            
            
            return Ok(new {message="Password reset is failed with some unknown error."});
        //    return View(model);
        }


        //[AllowAnonymous]
        //public IActionResult ResetPasswordConfirm()
        //{
        //    return View();
        //}
    }
}