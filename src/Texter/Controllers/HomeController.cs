using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texter.Models;
using Texter.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Texter.Controllers
{
    public class HomeController : Controller
    {
        private readonly static TexterContext db = new TexterContext();

        //public static List<SelectListItem> GetDropDown()
        //{
        //    List<SelectListItem> contacts = new List<SelectListItem>();
        //    var dbContacts = db.Contacts;
        //    foreach (var contact in dbContacts)
        //    {
        //        contacts.Add(new SelectListItem() { Text = contact.FirstName + " " + contact.LastName, Value = contact.PhoneNumber });
        //    }
        //    return contacts;
        //}

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult GetMessages()
        {
            var allMessages = Message.GetMessages();
            return View(allMessages);
        }

        public IActionResult SendMessage()
        {
            SendMessageViewModel model = new SendMessageViewModel();
            model.DbContacts = db.Contacts.ToList();
            //model.Message = new Message();
            //model.Message.To = "+12069543205";
            //model.Message.From = "+12065391391";
            return View(model);
        }

        [HttpPost]
        public IActionResult SendMessage(Message newMessage)
        {
            newMessage.Send();
            return RedirectToAction("Index");
        }
    }
}
