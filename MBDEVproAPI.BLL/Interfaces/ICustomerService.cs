

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBDEVproAPI.BLL.Interfaces
{
    public interface ICustomerService : IBaseService<CustomerModel>
    {

        Task<CustomerViewModel> GetAllCustomersVMAsync(int BusinessID);

        Task<IEnumerable<CustomerModel>> GetAllCustomersAsync(int BusinessID);


        Task<Customer> GetCustomerAsync(int CustomerID);

        Task<SaveViewModel> CreateCustomerVMAsync(CustomerViewModel vm);

        Task<SaveViewModel> CreateCustomerAsync(CustomerModel model);


        SaveViewModel CreateCustomer(CustomerModel model);

        SaveViewModel EditCustomer(int id, CustomerModel model);

        SaveViewModel DeleteCustomer(int id);

    }
}
