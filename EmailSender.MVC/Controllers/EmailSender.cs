using EmailSender.DAL;
using EmailSender.MVC.Models;
using EmailSender.MVC.Services;
using EmailSender.MVC.Services.Mailing_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Mail;

namespace EmailSender.MVC.Controllers
{
    public class EmailSender : Controller
    {
        private readonly IGenericRepository<EmailMessage> _emailMessageRepository;
        private readonly IMailingServices _mailingServices;

        public EmailSender(IGenericRepository<EmailMessage> emailMessage, IMailingServices mailingServices)
        {
            _emailMessageRepository = emailMessage;
            _mailingServices = mailingServices;
        }

        [HttpGet]
        // GET: EmailSender/Create
        public async Task<IActionResult> Create()
        {
            // Retrieve all email messages and convert them into a list of SelectListItem
            var emailMessages = await _emailMessageRepository.GetAll();
            var subjectListItems = emailMessages.Select(m => new SelectListItem { Value = m.Subject, Text = m.Subject }).ToList();

            // Set the ViewBag.Subjects to the list of SelectListItem and return the view
            ViewBag.Subjects = subjectListItems;
            return View();
        }

        [HttpPost]
        // POST: EmailSender/Create
        public async Task<IActionResult> Create(SubjectCreateModel subjectCreateModel)
        {
            // Check if the model state is valid
            if (ModelState.IsValid == false)
            {
                // If the model state is invalid, add model state errors to the ViewBag and set Success to false
                var errors = ModelState.SelectMany(i => i.Value!.Errors.Select(x => x.ErrorMessage));
                foreach (string err in errors)
                    ModelState.AddModelError("", err);
                ViewBag.Success = false;
                return View();
            }
            else
            {
                // If the model state is valid, create a new EmailMessage instance and add it to the email message repository
                ViewBag.Success = true;
                var subject = new EmailMessage { Subject = subjectCreateModel.Subject, Message = subjectCreateModel.Message };
                await _emailMessageRepository.Add(subject);
            }
            // Redirect to the GET version of the Create method
            return RedirectToAction("Create");
        }

        [HttpGet]
        // GET: EmailSender/SendingEmails
        public IActionResult SendingEmails(string subject)
        {
            // Set the ViewBag.Subject to the subject parameter and return the view
            ViewBag.Subject = subject;
            return View();
        }

        [HttpPost]
        // POST: EmailSender/SendingEmails
        public async Task<IActionResult> SendingEmails(SendingEmailsCreatModel sendingEmails, string subject)
        {
            // Split the recipients by commas
            var recipients = sendingEmails.Recipients.Split(',');

            // Get the email message by subject
            var email = await _emailMessageRepository.FindOne(e => e.Subject == subject);

            // Send the email to each recipient
            foreach (var recipient in recipients)
            {
                await _mailingServices.SendEmailAsync(new List<string> { recipient }, email.Subject, email.Message);
            }

            // Redirect to the SuccessfullySent view
            return RedirectToAction("SuccessfullySent");
        }

        [HttpGet]
        // GET: EmailSender/SuccessfullySent
        public IActionResult SuccessfullySent()
        {
            // Return the view
            return View();
        }

    }
}




