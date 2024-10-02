//using Microsoft.AspNetCore.Mvc;
//using KrontecDemo.Models;
//using KrontecDemo.Services;

//namespace KrontecDemo.Controllers
//{
//    public class CustomerController : Controller
//    {
//        private readonly CustomerService _customerService;

//        public CustomerController(CustomerService customerService)
//        {
//            _customerService = customerService;
//        }

//        public IActionResult Index()
//        {
//            var customers = _customerService.GetAllCustomers();
//            return View(customers);
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(Customer customer)
//        {
//            if (ModelState.IsValid)
//            {
//                _customerService.AddCustomer(customer);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(customer);
//        }

//        [HttpGet]
//        public IActionResult Edit(int id)
//        {
//            var customer = _customerService.GetCustomer(id);
//            if (customer == null)
//                return NotFound();
//            return View(customer);
//        }

//        [HttpPost]
//        public IActionResult Edit(Customer customer)
//        {
//            if (ModelState.IsValid)
//            {
//                _customerService.UpdateCustomer(customer);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(customer);
//        }

//        [HttpGet]
//        public IActionResult Delete(int id)
//        {
//            var customer = _customerService.GetCustomer(id);
//            if (customer == null)
//                return NotFound();
//            return View(customer);
//        }

//        [HttpPost, ActionName("Delete")]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            _customerService.DeleteCustomer(id);
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using KrontecDemo.Models;
using KrontecDemo.Services;
using Microsoft.Extensions.Logging;

namespace KrontecDemo.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(CustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var customers = _customerService.GetAllCustomers();
                return View(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customers."); // Log the error
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving customers. Please try again later.");
                return View(new List<Customer>());
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.AddCustomer(customer);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while creating the customer.");
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the customer. Please try again later.");
                }
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var customer = _customerService.GetCustomer(id);
                if (customer == null)
                    return NotFound();
                return View(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the customer for editing.");
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving the customer. Please try again later.");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.UpdateCustomer(customer);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while updating the customer.");
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the customer. Please try again later.");
                }
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var customer = _customerService.GetCustomer(id);
                if (customer == null)
                    return NotFound();
                return View(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the customer for deletion.");
                ModelState.AddModelError(string.Empty, "An error occurred while retrieving the customer for deletion. Please try again later.");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _customerService.DeleteCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the customer.");
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the customer. Please try again later.");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
