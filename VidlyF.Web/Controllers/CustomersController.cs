using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyF.Web.Models;
using VidlyF.Web.ViewModels;

namespace VidlyF.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }


        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);


            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // GET: Customers Form
        public ActionResult Create()
        {
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Heading = "Add Customer"
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(CustomerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.MembershipTypes = _context.MembershipTypes.ToList();
                return View("CustomerForm", viewModel);
            }

            var customer = new Customer
            {

                MembershipTypeId = viewModel.MembershipTypeId,
                Name = viewModel.Name,
                DateTime = viewModel.DateTime,
                IsSubscribedToNewsletter = viewModel.IsSubscribedToNewsletter
                
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers Form
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);
            var viewModel = new CustomerFormViewModel
            {
                Id = customer.Id,
                Heading = "Edit Customer",
                MembershipTypes = _context.MembershipTypes.ToList(),
                Name = customer.Name,
                MembershipTypeId = customer.MembershipTypeId,
                DateTime = customer.DateTime,
            };

            return View("CustomerForm", viewModel);
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