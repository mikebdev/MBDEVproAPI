

namespace MBDEVproAPI.Repository.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {

        Task<IEnumerable<Customer>> GetAllAysnc(int BusinessID);

        Task<IEnumerable<Customer>> GetAllCustomersAsync(int BusinessID);

        IEnumerable<Customer> GetAllCustomers(int BusinessID);
    }
}
