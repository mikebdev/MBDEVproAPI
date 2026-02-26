

namespace MBDEVproAPI.Repository.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {

        Task<IEnumerable<Customer>> GetAllCustomersVMAsync(int BusinessID);

        Task<IEnumerable<Customer>> GetAllCustomersAsync(int BusinessID);

        Task<Customer> GetCustomerAsync(int CustomerID);

        Task AddAsync(Customer customer);
    }
}
