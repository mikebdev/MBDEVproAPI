
using MBDEVproAPI.DataModel;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MBDEVproAPI.BLL.Services 
{
    public class CustomerService : ICustomerService
    {

        private readonly MBDEVproAPIDbContext _databaseContext;

        public CustomerService(MBDEVproAPIDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        /// GET ALL: Customers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GET: Customer
        /// "CustomerControllerGetCustomer": "Customer/GetCustomer"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerModel GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// CREATE: Customer
        /// "CustomerControllerCreateCustomer": "Customer/CreateCustomer" 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SaveViewModel CreateCustomer(CustomerModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// EDIT: Customer
        /// "CustomerControllerEditCustomer": "Customer/EditCustomer"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SaveViewModel EditCustomer(int id, CustomerModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DELETE: Customer
        /// "CustomerControllerDeleteCustomer": "Customer/DeleteCustomer"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SaveViewModel DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

    }
}
