using MVCMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MVCMail.SingletonPattern;

namespace MVCMail.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Guid? id)
        {
            if (id != null)
            {
                if (db.Samples.Any(x => x.activationCode == id
                ))
                {
                    db.Samples.Where(x => x.activationCode == id).Single().IsActive = true;

                    TempData["succes"] = "Congratulations your account has been activated";
                    return View();
                }
            }

            if (Session["member"] != null)
            {
                if ((Session["member"] as Sample).IsActive != true)
                {
                    ViewBag.IsnotActive = "Is not Active";
                }
            }
            return View();
        }

        MyContext db = DBTool.DBInstance;

        [HttpPost]

        public ActionResult Index(Sample item)
        {

            if (!ModelState.IsValid)
            {

                return View();
            }
            db.Samples.Add(item);
            db.SaveChanges();


            Session["member"] = item;

            #region MailSendingCode

            MailAddress senderMail = new MailAddress("Sender Mail"); //Sender

            MailAddress receiverMail = new MailAddress(item.Email); //Receiver
             
            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderMail.Address, "Sender Mail Passwords")
                //the second argument on the top line is not intentionally written. Here you type the password of senderEmail. In its current state, the program will not run. Fill in your password
            };

            using (var mesaj = new MailMessage(senderMail, receiverMail)
            {

                Subject = "Hello World",
                Body = item.Name + " Complete Your Registration Verify Email Address http://localhost:*****/Home/Index/" + item.activationCode
                /////http://localhost:*****/Home/Index/ ------You have to enter your localhost 
            })
            {
                smtp.Send(mesaj);//Mail sent
                TempData["Sent"] = "Mail Sent";
            }

            #endregion

            return View();
        }


    }
}