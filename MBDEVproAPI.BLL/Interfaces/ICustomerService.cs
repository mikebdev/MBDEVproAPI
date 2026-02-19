

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBDEVproAPI.BLL.Interfaces
{
    public interface ICustomerService : IBaseService<CustomerModel>
    {

        IEnumerable<CustomerModel> GetAllCustomers();
        
        CustomerModel GetCustomer(int id);

        SaveViewModel CreateCustomer(CustomerModel model);

        SaveViewModel EditCustomer(int id, CustomerModel model);

        SaveViewModel DeleteCustomer(int id);

    }
}
