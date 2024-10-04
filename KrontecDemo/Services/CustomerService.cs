using Krontec.Data;
using KrontecDemo.Models;
using System.ComponentModel.DataAnnotations;

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
                _customerRepository.AddCustomer(new()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber
                });
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
                var customerDB = _customerRepository.GetCustomer(id);
                return new Customer
                {
                    CustomerId = customerDB.CustomerId,
                    FirstName = customerDB.FirstName,
                    LastName = customerDB.LastName,
                    Address = customerDB.Address,
                    Email = customerDB.Email,
                    PhoneNumber = customerDB.PhoneNumber
                };
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
                var customerDB = _customerRepository.GetAllCustomers();
                List<Customer> result = new List<Customer>();
                foreach (var customer in customerDB)
                {
                    result.Add(new()
                    {

                        CustomerId = customer.CustomerId,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Address = customer.Address,
                        Email = customer.Email,
                        PhoneNumber = customer.PhoneNumber
                    });
                }
                return result;
               
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
                _customerRepository.UpdateCustomer(new()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber
                });
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


