using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Texter.Models;


namespace Texter.Controllers
{
    public class ContactsController : Controller
    {
        private TexterContext db = new TexterContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Contacts.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            contact.ConvertPhoneNumber();
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
