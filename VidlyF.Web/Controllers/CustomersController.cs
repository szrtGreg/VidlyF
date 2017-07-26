using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VidlyF.Web.Models;

namespace VidlyF.Web.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }


        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
              new Customer { Id = 1, Name = "Client1" },
              new Customer { Id = 2, Name = "Client2" }
            };
        }
    }
}