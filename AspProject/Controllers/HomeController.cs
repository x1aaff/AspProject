using Microsoft.AspNetCore.Mvc;
using AspProject.Model;
using System.Diagnostics;

namespace AspProject.Controllers
{
    public class HomeController : Controller
    {
        PhoneBook phoneBook = new PhoneBook();
        public IActionResult Index()
        {
            
            return View(phoneBook);
        }

        public IActionResult Details()
        {
            int id = int.Parse(Request.Query["id"]);
            Debug.WriteLine(id);
            return View(phoneBook.GetContact(id));
        }
    }
}
