using Microsoft.AspNetCore.Mvc;
using AspProject.Model;
using System.Diagnostics;
using AspProject.Entities;
using AspProject.ContextFolder;
using System.Net;

namespace AspProject.Controllers
{
    public class HomeController : Controller
    {
        PhoneBook phoneBook = new PhoneBook();
        public IActionResult Index()
        {
            
            return View(PhoneBook.context.Contacts.ToList());
        }

        public IActionResult Details()
        {
            int id = int.Parse(Request.Query["id"]);
            return View(PhoneBook.context.Contacts.ToList()[id]);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDataFromViewField(string lName, string fName, string pName,
                                                  int pNumber, string address, string description)
        {
            using (var db = PhoneBook.context)
            {
                db.Contacts.Add(
                    new Entities.Contact()
                    {
                        LastName = lName,
                        FirstName = fName,
                        PName = pName,
                        PhoneNumber = pNumber,
                        Adress = address,
                        Description = description
                    });
                db.SaveChanges();
            }
            return Redirect("~/");
        }

        //[HttpPut]
        public IActionResult EditDataFromViewField(int id, string lName, string fName, string pName,
                                                  int pNumber, string address, string description)
        {
            using (var db = new DataContext())
            {
                var contactSended = new Contact()
                {
                    Id = id,
                    LastName = lName,
                    FirstName = fName,
                    PName = pName,
                    PhoneNumber = pNumber,
                    Adress = address,
                    Description = description
                };

                var contactDB = db.Contacts.FirstOrDefault(c => c.Id.Equals(contactSended.Id));
                contactDB.LastName = contactSended.LastName;
                contactDB.FirstName = contactSended.FirstName;
                contactDB.PName = contactSended.PName;
                contactDB.PhoneNumber = contactSended.PhoneNumber;
                contactDB.Adress = contactSended.Adress;
                contactDB.Description = contactSended.Description;
                db.SaveChanges();
            }
            return Redirect("~/");
        }

        //[HttpDelete]
        public IActionResult DeleteDataFromViewField()
        {
            int id = int.Parse(Request.Query["id"]);
            using (var db = PhoneBook.context)
            {
                db.Contacts.Remove(db.Contacts.FirstOrDefault(c => c.Id.Equals(id)));
                db.SaveChanges();
            }
            return Redirect("~/");
        }
    }
}
