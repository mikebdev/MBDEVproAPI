

namespace MBDEVproAPI.Repository.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {

        #region 
        #endregion



        #region Get All Customers
        Task<IEnumerable<Customer>> GetAllCustomersVMAsync(int BusinessID);

        Task<IEnumerable<Customer>> GetAllCustomersAsync(int BusinessID);
        #endregion



        #region Get Customer
        Task<Customer> GetCustomerAsync(int CustomerID);
        #endregion



        #region Add Customer
        #endregion



        #region Edit Customer
        #endregion



        #region Delete Customer
        public void DeleteCustomerVM(Customer obj);

        #endregion

    }
}
