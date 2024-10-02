using KrontecDemo.Models;
using System.ComponentModel.DataAnnotations;
using KrontecDemo.DataAccess;

namespace KrontecDemo.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                ValidateCustomer(customer);
                _customerRepository.AddCustomer(customer);
            }
            catch (ValidationException validationEx)
            {
                Console.WriteLine($"Validation error: {validationEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the customer: {ex.Message}");
                throw new Exception("An unexpected error occurred while adding the customer. Please try again.");
            }
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                return _customerRepository.GetCustomer(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the customer: {ex.Message}");
                throw new Exception("An error occurred while retrieving the customer details. Please try again later.");
            }
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _customerRepository.GetAllCustomers();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving customers: {ex.Message}");
                throw new Exception("An error occurred while retrieving the customer list. Please try again later.");
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                ValidateCustomer(customer);
                _customerRepository.UpdateCustomer(customer);
            }
            catch (ValidationException validationEx)
            {
                Console.WriteLine($"Validation error: {validationEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the customer: {ex.Message}");
                throw new Exception("An unexpected error occurred while updating the customer. Please try again.");
            }
        }

        public void DeleteCustomer(int id)
        {
            try
            {
                _customerRepository.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the customer: {ex.Message}");
                throw new Exception("An unexpected error occurred while deleting the customer. Please try again.");
            }
        }

        private void ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FirstName))
                throw new ValidationException("First Name is required.");
            if (string.IsNullOrWhiteSpace(customer.LastName))
                throw new ValidationException("Last Name is required.");
            if (string.IsNullOrWhiteSpace(customer.Email))
                throw new ValidationException("Email is required.");
        }
    }
}


