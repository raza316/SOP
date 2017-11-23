using SOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SOP.Controllers
{
    public class AccountController : Controller
    {
        SOPDbContext sop = new SOPDbContext();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User users)
        {
            if (ModelState.IsValid)
            {
                string username = users.UserName.ToString();
                string password = users.Password.ToString();

                   

                bool userValid = sop.Users.Any(user => user.UserName == username && user.Password == password);

                // User found in the database
                if (userValid)
                {

                    FormsAuthentication.SetAuthCookie(username, false);
                    Session["UserID"] = users.UserID.ToString();
                    Session["UserName"] = users.UserName.ToString();          
                    return RedirectToAction("Index", "Home");
                    }
               
                else
                {
                    TempData["ErrorMSG"] = "Access Denied! Wrong Credential";
                }

            }
            return View(users);
        }
        public ActionResult LogOut()
        {


            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();

            

            return RedirectToAction("Login","Account");
        }



        //[HttpPost]
        //public ActionResult ForgotPassword(User users)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string email = users.Email.ToString();
        //        string answer = users.Answer.ToString();


        //        bool validUser = sop.Users.Any(a => a.Email == email && a.Answer == answer);

        //        if (validUser)
        //        {
        //            return View("Login");
        //        }
        //        else
        //        {
        //            TempData["Error"] = "Wrong pass";
        //        }
        //    }
        //    return View();
        //}


        //public ActionResult ChangePassword(User users)
        //{

        //    //string answer = users.Answer.ToString();
        //    if (ModelState.IsValid)
        //    {

        //      //  var validAnswer = sop.Users.Where(a => a.Answer == answer);
        //        if (validAnswer != null)
        //        {
        //            var password = sop.Users.Select(m => m.Password);

        //            sop.Entry(password).State = System.Data.Entity.EntityState.Modified;
        //            sop.SaveChanges();
        //        }
        //    }
        //    return View(users);
        //}

        //[AllowAnonymous]
        //public ActionResult LostPassword()
        //{
        //    return View();
        //}

        //// POST: Account/LostPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult LostPassword(_LostPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user;

        //        var foundUserName = (from u in sop.Users
        //                             where u.Email == model.Email
        //                             select u.UserName).FirstOrDefault();
        //        //if (foundUserName != null)
        //        //{
        //        //user = model.GetUser.UserName(foundUserName.ToString());                   }
        //        //else
        //        //{
        //        //    user = null;
        //        //}
        //        if (foundUserName != null)
        //        {
        //            // Generae password token that will be used in the email link to authenticate user
        //            var token = WebSecurity.GeneratePasswordResetToken(user.UserName);
        //            // Generate the html link sent via email
        //            string resetLink = "<a href='"
        //               + Url.Action("ResetPassword", "Account", new { rt = token }, "http")
        //               + "'>Reset Password Link</a>";

        //            // Email stuff
        //            string subject = "Reset your password for asdf.com";
        //            string body = "You link: " + resetLink;
        //            string from = "donotreply@asdf.com";

        //            MailMessage message = new MailMessage(from, model.Email);
        //            message.Subject = subject;
        //            message.Body = body;
        //            SmtpClient client = new SmtpClient();

        //            // Attempt to send the email
        //            try
        //            {
        //                client.Send(message);
        //            }
        //            catch (Exception e)
        //            {
        //                ModelState.AddModelError("", "Issue sending email: " + e.Message);
        //            }
        //        }
        //        else // Email not found
        //        {
        //            /* Note: You may not want to provide the following information
        //            * since it gives an intruder information as to whether a
        //            * certain email address is registered with this website or not.
        //            * If you're really concerned about privacy, you may want to
        //            * forward to the same "Success" page regardless whether an
        //            * user was found or not. This is only for illustration purposes.
        //            */
        //            ModelState.AddModelError("", "No user found by that email.");
        //        }
        //    }

        //    return View(model);
        //}

        /* You may want to send the user to a "Success" page upon the successful
        * sending of the reset email link. Right now, if we are 100% successful
        * nothing happens on the page. :P
        */





    }
}

    
