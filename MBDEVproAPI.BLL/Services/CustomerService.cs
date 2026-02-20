


using MBDEVproAPI.Repository.Interfaces;

namespace MBDEVproAPI.BLL.Services 
{
    public class CustomerService : ICustomerService
    {

        private readonly MBDEVproAPIDbContext _databaseContext;
        private readonly ICustomerService _customerService; 
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(MBDEVproAPIDbContext databaseContext, ICustomerService customerService, ICustomerRepository customerRepository )
        {
            _databaseContext = databaseContext;
            _customerService = customerService;
            _customerRepository = customerRepository;
        }


        #region Get all Customers
        /// <summary>
        /// GET ALL: Customers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll().ToList();
          
            if (customers == null)

            {
                Log.Error("Customers API: CustomerService(GetAllCustomers); (customers == null");
                return null;
            }
            else
            {
                return customers;
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
