using Krontec.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Krontec.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database update error: {dbEx.Message}");
                throw new Exception("There was an error while saving the customer. Please try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new Exception("An unexpected error occurred. Please try again later.");
            }
        }

        public Customer GetCustomer(int customerId)
        {
            try
            {
                return _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the customer: {ex.Message}");
                throw new Exception("An error occurred while retrieving the customer details. Please try again later.");
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                Console.WriteLine($"Concurrency error: {dbEx.Message}");
                throw new Exception("The customer data has changed since it was loaded. Please reload and try again.");
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database update error: {dbEx.Message}");
                throw new Exception("There was an error while updating the customer. Please try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new Exception("An unexpected error occurred. Please try again later.");
            }
        }

        public void DeleteCustomer(int customerId)
        {
            try
            {
                var customer = _context.Customers.Find(customerId);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Customer not found.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database update error: {dbEx.Message}");
                throw new Exception("There was an error while deleting the customer. Please try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new Exception("An unexpected error occurred. Please try again later.");
            }
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving customers: {ex.Message}");
                throw new Exception("An error occurred while retrieving the customer list. Please try again later.");
            }
        }
    }
}

