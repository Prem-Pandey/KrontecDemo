using KrontecDemo.Models;

namespace KrontecDemo.DataAccess
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        Customer GetCustomer(int customerId);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        List<Customer> GetAllCustomers();
    }
}
