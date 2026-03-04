

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBDEVproAPI.BLL.Interfaces
{
    public interface ICustomerService : IBaseService<CustomerModel>
    {


        #region 
        #endregion



        #region Get All Customers
        Task<CustomerViewModel> GetAllCustomersVMAsync(int BusinessID);

        Task<IEnumerable<CustomerModel>> GetAllCustomersAsync(int BusinessID);
        #endregion


        #region Get Customer
        Task<Customer> GetCustomerAsync(int CustomerID);
        #endregion


        #region Add Customer
        Task<SaveViewModel> CreateCustomerVMAsync(CustomerViewModel vm);

        Task<SaveViewModel> CreateCustomerAsync(CustomerModel model);
                
        SaveViewModel CreateCustomer(CustomerModel model);
        #endregion


        #region Edit Customer
        Task<SaveViewModel> EditCustomerVMAsync(CustomerViewModel vm);

        Task<SaveViewModel> EditCustomer(CustomerModel model);
        #endregion


        #region Delete Customer
        Task<SaveViewModel> DeleteCustomerVMAsync(int CustomerID);
        Task<CustomerModel> DeleteCustomer(int CustomerID);
        #endregion
    }
}
