

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBDEVproAPI.BLL.Interfaces
{
    public interface ICustomerService : IBaseService<CustomerModel>
    {

        //CustomerViewModel GetAllCustomers(int BusinessID);

        Task<CustomerViewModel> GetAllCustomersAsync(int BusinessID);


        Task<Customer> GetCustomerAsync(int CustomerID);


        //CustomerModel GetCustomer(int id);

        SaveViewModel CreateCustomer(CustomerModel model);

        SaveViewModel EditCustomer(int id, CustomerModel model);

        SaveViewModel DeleteCustomer(int id);

    }
}
