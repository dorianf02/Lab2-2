using LibApp.Data;
using LibApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.Controllers
{
    public class CustomersController : Controller
    {
        public CustomersController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public ViewResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return Content("User not found");
            }

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Jan Kowalski" },
                new Customer { Id = 2, Name = "Monika Nowak" }
            };
        }

        private ApplicationDbContext _context;
    }
}
