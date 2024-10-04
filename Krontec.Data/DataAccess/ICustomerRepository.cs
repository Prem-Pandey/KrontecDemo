using Krontec.Data.Entity;

namespace Krontec.Data
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
