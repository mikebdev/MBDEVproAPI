

namespace MBDEVproAPI.Repository.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {

        Task<IEnumerable<Customer>> GetAllCustomersAsync(int BusinessID);

        Task<Customer> GetCustomerAsync(int CustomerID);
    }
}
