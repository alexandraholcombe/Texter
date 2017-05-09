using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Models;

namespace Texter.ViewModels
{
    public class SendMessageViewModel
    {
        private List<SelectListItem> _contacts;
        public List<Contact> DbContacts { get; set; }
        public List<SelectListItem> Contacts
        {
            get
            {
                if (_contacts == null)
                {
                    _contacts = new List<SelectListItem>();
                    foreach (var contact in DbContacts)
                    {

                        _contacts.Add(new SelectListItem { Text = contact.FirstName + " " + contact.LastName, Value = contact.PhoneNumber });
                    }
                }
                return _contacts;
            }
            set { }
        }
        public Message Message { get; set; }

    }
}
