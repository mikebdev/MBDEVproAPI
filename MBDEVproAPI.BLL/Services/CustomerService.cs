namespace MBDEVproAPI.BLL.Services {


    public class CustomerService : ICustomerService
    {

        #region variables & constructors
        private readonly MBDEVproAPIDbContext _context;

        //private IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// Base Repository
        /// </summary>
        private readonly ICustomerRepository _customerRepository;

        ///// <summary>
        ///// memory cache
        ///// </summary>
        //private IMemoryCache _memoryCache;

        ///// <summary>
        ///// configuration
        ///// </summary>
        //public IConfiguration _configuration { get; }




        public CustomerService(MBDEVproAPIDbContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }
        #endregion


        #region Get All Customers | CustomerViewModel
        /// <summary>
        /// GET: Gets all customers for a business in a VM for web UI.  
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <returns></returns>
        public async Task<CustomerViewModel> GetAllCustomersVMAsync(int BusinessID)
        {
            try
            {
                if (BusinessID == 0)
                {
                    Log.Error("Customer API: CustomerService(GetAllCustomersAsync); (BusinessID == 0)");
                    return new CustomerViewModel();
                }
                else
                {
                    CustomerViewModel model = new CustomerViewModel();
                    var customers = await _customerRepository.GetAllCustomersVMAsync(BusinessID);
                    if (customers == null)
                    {
                        Log.Error("Customer API: CustomerService(GetAllCustomersAsync); (customers == null)");
                        return new CustomerViewModel();
                    }
                    model.CustomerList = customers.Select(o => Mapper.MapObject(o, new CustomerModel())).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Customer API: CustomerService(GetAllCustomersAsync); (" + ex + ")" + " (" + ex.InnerException + ")");
                return new CustomerViewModel();
            }
        }
        #endregion


        #region Get All Customers | CustomerModel
        public async Task<IEnumerable<CustomerModel>> GetAllCustomersAsync(int BusinessID)
        {
            try
            {
                if (BusinessID == 0)
                {
                    Log.Error("Customer API: CustomerService(GetAllCustomersAsync); (BusinessID == 0)");
                    return new List<CustomerModel>();
                }
                else
                {
                    // Await the repository task first, then project the results.
                    var customers = await _customerRepository.GetAllCustomersAsync(BusinessID);
                    if (customers == null)
                    {
                        Log.Error("Customer API: CustomerService(GetAllCustomersAsync); (entities == null)");
                        return new List<CustomerModel>();
                    }
                    var entities = customers.Select(o => Mapper.MapObject(o, new CustomerModel())).ToList();
                    return entities;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Customer API: CustomerService(GetAllCustomersAsync); (" + ex + ")" + " (" + ex.InnerException + ")");
                return new List<CustomerModel>();
            }
        }
        #endregion


        //public IEnumerable<ProjectModel> GetAll()
        //{
        //    try
        //    {
        //        var entities = _projectRepository.GetAll().Select(O => Mapper.MapObject(O, new ProjectModel())).ToList();
        //        if (entities == null)
        //        {
        //            throw new Exception("Licensing API: ProjectService(GetAll); (entities == null");
        //        }
        //        else
        //        {
        //            return entities;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Add("ErrorMessage", "Licensing API: ProjectService(GetAll)");
        //        throw;
        //    }
        //}





        #region Get Customer | Customer
        //GetCustomerAsync
        /// <summary>
        /// GET: Gets a customer for a business.  
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>

        public async Task<Customer> GetCustomerAsync(int CustomerID) // can jsut do Customer here instead of CustomerModel
        {
            try
            {
                if (CustomerID == 0)
                {
                    Log.Error("Customer API: CustomerService(GetCustomerAsync); (CustomerID == 0)");
                    return new Customer();
                }
                else
                {
                    var customer = await _customerRepository.GetCustomerAsync(CustomerID);
                    if (customer == null)
                    {
                        Log.Error("Customer API: CustomerService(GetCustomerAsync); (customer == null)");
                        return new Customer();
                    }
                    return customer;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Customer API: CustomerService(GetCustomerAsync); (" + ex + ")" + " (" + ex.InnerException + ")");
                return new Customer();
            }
        }
        #endregion






        #region Add Customer | CustomerViewModel   
        /// <summary>
        /// Create a new customer for a business from client web application using a CustomerViewModel.
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<SaveViewModel> CreateCustomerVMAsync(CustomerViewModel vm)
        {
            try
            {
                if (vm == null || vm.CustomerID != 0 || vm.BusinessID == 0)// we could check each condition here and log which is the issue.
                {
                    Log.Error("Customer API: CustomerService(CreateCustomerVMAsync); (vm == null || vm.CustomerID != 0 || vm.BusinessID == 0");
                    return new SaveViewModel { IsSaved = false, ErrorMessage = "Please provide details to Create the Customer." };
                }
                else
                {
                    var entity = new DataModel.Entities.Customer();
                    if (entity == null)
                    {
                        Log.Error("Customer API: CustomerService(CreateCustomerVMAsync); (entity == null)");
                        return new SaveViewModel { IsSaved = false, ErrorMessage = "Please provide details to Create the Customer." };
                    }
                    else
                    {
                        int? refID;
                        using (TransactionScope scope = new TransactionScope())
                        {
                            Mapper.MapObject(vm, entity);
                            _customerRepository.Add(entity);
                            _customerRepository.SaveChanges();
                            refID = entity.CustomerID;
                            scope.Complete();
                        }
                        return new SaveViewModel(refID);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Customer API: CustomerService(CreateCustomerVMAsync); (" + ex + ")" + " (" + ex.InnerException + ")");
                return new SaveViewModel(ex.Message);
            }
            finally
            {
            }
        }
        #endregion


        #region Add Customer | Customer
        /// <summary>
        /// CREATE: Customer
        /// "CustomerControllerCreateCustomerAsync": "Customer/CreateCustomerAsync" 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SaveViewModel> CreateCustomerAsync(CustomerModel model)
        {
            try
            {
                if (model == null || model.CustomerID != 0 || model.BusinessID == 0)// we could check each condition here and log which is the issue.
                {
                    Log.Error("Customer API: CustomerService(CreateCustomerAsync); (model == null || model.CustomerID != 0 || model.BusinessID == 0");
                    return new SaveViewModel { IsSaved = false, ErrorMessage = "Please provide details to Create the Customer." };
                }
                else
                {
                    var entity = new DataModel.Entities.Customer();
                    if (entity == null)
                    {
                        Log.Error("Customer API: CustomerService(CreateCustomerAsync); (entity == null)");
                        return new SaveViewModel { IsSaved = false, ErrorMessage = "Please provide details to Create the Customer." };
                    }
                    else
                    {
                        int? refID;
                        using (TransactionScope scope = new TransactionScope())
                        {
                            Mapper.MapObject(model, entity);
                            _customerRepository.Add(entity);
                            _customerRepository.SaveChanges();
                            refID = entity.CustomerID;
                            scope.Complete();
                        }
                        return new SaveViewModel(refID);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Customer API: CustomerService(CreateCustomerAsync); (" + ex + ")" + " (" + ex.InnerException + ")");
                return new SaveViewModel(ex.Message);
            }
            finally
            {

            }


        }
        #endregion



        ///// <summary>
        ///// GET: Customer
        ///// "CustomerControllerGetCustomer": "Customer/GetCustomer"
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public CustomerModel GetCustomer(int id)
        //{
        //    throw new NotImplementedException();
        //}

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

































