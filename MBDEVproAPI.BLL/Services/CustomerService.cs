


using MBDEVproAPI.Repository.Interfaces;

namespace MBDEVproAPI.BLL.Services 
{
    public class CustomerService : ICustomerService
    {

        #region variables & constructors
        private readonly MBDEVproAPIDbContext _databaseContext;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(MBDEVproAPIDbContext databaseContext, ICustomerRepository customerRepository )
        {
            _databaseContext = databaseContext;
            _customerRepository = customerRepository;
        }
        #endregion


        #region Get all Customers
        /// <summary>
        /// GET ALL: Customers
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <returns></returns>
        public CustomerModel GetAllCustomers(int BusinessID)
        {
            var customers = _customerRepository.GetAll(BusinessID).ToList();
          
            if (customers == null)

            {
                Log.Error("Customers API: CustomerService(GetAllCustomers); (customers == null");
                return null; // return empty model?
            }
            else
            {
                //return customers;
                return null;
            }
        }
        #endregion







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
