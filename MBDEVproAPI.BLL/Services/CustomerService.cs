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



        #region 
        #endregion



        #region Get All Customers
        /// <summary>
        /// GET: Get All Customers | CustomerViewModel | Gets all customers for a business in a VM for web UI. 
        /// TEST URL: https://localhost:7092/api/Customer/GetAllCustomers/52466 | https://localhost:7092/api/Customer/GetAllCustomers?BusinessID=52466
        /// "CustomerControllerGetAllCustomersVMAsync": "Customer/GetAllCustomersVMAsync",
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

        /// <summary>
        /// GET: Get All Customers | CustomerModel | Gets all customers for a business.
        /// TEST URL: https://localhost:7092/api/Customer/GetAllCustomers?BusinessID=52466
        /// "CustomerControllerGetAllCustomersAsync": "Customer/GetAllCustomersAsync",
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <returns></returns>
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


        #region Get Customer
        /// <summary>
        /// GET: Get Customer | Customer | Gets a customer for a business.  
        /// TEST URL: https://localhost:7092/api/Customer/GetCustomer/3 | https://localhost:7092/api/Customer/GetCustomer?CustomerID=3  
        /// "CustomerControllerGetCustomer": "Customer/GetCustomer",
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



        #region Add Customer
        /// <summary>
        /// Add Customer | CustomerViewModel | Create a new customer for a business from client web application using a CustomerViewModel.
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

        /// <summary>
        /// Add Customer | CustomerModel | Create a new customer for a business.
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
                    var entity =  new DataModel.Entities.Customer();
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
        #endregion



        #region Edit Customer
        /// <summary>
        /// EDIT: Edit a Customer | CustomerViewModel | edit a customer for a business in a VM for web UI. 
        /// TEST URL:  | 
        /// "CustomerControllerEditCustomerVMAsync": "Customer/EditCustomerVMAsync",
        /// </summary>
        /// <param name="vm"></param>
        /// <returns>SaveViewModel</returns>
        public async Task<SaveViewModel> EditCustomerVMAsync(CustomerViewModel vm)
        {
            try
            {
                if (vm == null || vm.CustomerID == 0 || vm.BusinessID == 0)
                {
                    Log.Error("Customer API: CustomerService(EditCustomerVMAsync); (vm == null || vm.CustomerID == 0 || vm.BusinessID == 0)");
                    return new SaveViewModel { IsSaved = false, ErrorMessage = "Please provide details to Edit the Customer." };
                }
                else
                {
                    var entity = await _customerRepository.GetCustomerAsync(vm.CustomerID);
                    if (entity == null)
                    {
                        Log.Error("Customer API: CustomerService(EditCustomerVMAsync); (entity == null)");
                        return new SaveViewModel { IsSaved = false, ErrorMessage = "Please provide details to Edit the Customer. (entity == null)" };
                    }
                    else
                    {
                        int? refID;
                        using (TransactionScope scope = new TransactionScope())
                        {
                            Mapper.MapObject(vm, entity);
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
                Log.Error("Customer API: CustomerService(EditCustomerVMAsync); (" + ex + ")" + " (" + ex.InnerException + ")");
                return new SaveViewModel(ex.Message);
            }
            finally
            {
            }
        }

        /// <summary>
        /// EDIT: Customer | CustomerModel | edit a customer for a business.
        /// "CustomerControllerEditCustomer": "Customer/EditCustomer"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SaveViewModel> EditCustomer(CustomerModel model)
        {
            try
            {
                if (model == null || model.CustomerID == 0 || model.BusinessID == 0)
                {
                    Log.Error("Customer API: CustomerService(EditCustomer) CustomerModel; (model == null || model.CustomerID == 0 || model.BusinessID == 0)");
                    return new SaveViewModel { IsSaved = false, ErrorMessage = "Please provide details to Edit the Customer. Null Values" };
                }
                else
                {
                    var entity = await _customerRepository.GetCustomerAsync(model.CustomerID);
                    if (entity == null)
                    {
                        Log.Error("Customer API: CustomerService(EditCustomer) CustomerModel; (entity == null)");
                        return new SaveViewModel { IsSaved = false, ErrorMessage = "Please provide details to Edit the Customer." };
                    }
                    else
                    {
                        int? refID;
                        refID = entity.CustomerID;
                        using (TransactionScope scope = new TransactionScope())
                        {
                            Mapper.MapObject(model, entity);
                            _customerRepository.SaveChanges();
                            //refID = entity.CustomerID;
                            scope.Complete();
                        }
                        return new SaveViewModel(refID);
                    }
                }
            }
            catch (Exception ex) 
            {
                Log.Error("Customer API: CustomerService(EditCustomer) CustomerModel; (" + ex + ")" + " (" + ex.InnerException + ")");
                return new SaveViewModel(ex.Message);
            }
            finally
            {
            }
        }

        // CustomerModel to just return a CustomerModel instead of a SaveViewModel with the RefID. We could do this for the VM as well.
        #endregion



        #region Delete Customer
        /// <summary>
        /// DELETE: Customer | SaveViewModel | delete a customer for a business and return a SaveViewModel with the RefID of the deleted customer.
        /// "CustomerControllerDeleteCustomerVM": "Customer/DeleteCustomerVM"
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SaveViewModel</returns>
        public async Task<SaveViewModel> DeleteCustomerVMAsync(int CustomerID)
        {
            try
            {
                int? refID = null;
                if (CustomerID == 0)
                {
                    Log.Error("Customer API: CustomerService(DeleteCustomerVMAsync); (CustomerID == 0)");
                    return new SaveViewModel("Please provide details to delete the Customer.");
                }
                else
                {
                    var entity = await _customerRepository.GetCustomerAsync(CustomerID);

                    if (entity == null)
                    {
                        Log.Error("Customer API: CustomerService(DeleteCustomerVMAsync); (entity == null)");
                        return new SaveViewModel("Please provide details to delete the Customer.");
                    }
                    else
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            _customerRepository.Remove(entity);
                            _customerRepository.SaveChanges();
                            scope.Complete();
                            refID = entity.CustomerID;
                        }
                        return new SaveViewModel(refID);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Customer API: CustomerService(DeleteCustomerVMAsync); (" + ex + ")" + " (" + ex.InnerException + ")");
                return new SaveViewModel("Customer API: CustomerService(DeleteCustomerVMAsync); (" + ex + ")" + " (" + ex.InnerException + ") Message: " + ex.Message);
            }
            finally
            {
            }
        }

        /// <summary>
        /// DELETE: Customer | CustomerModel | delete a customer for a business.
        /// "CustomerControllerDeleteCustomer": "Customer/DeleteCustomer"
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SaveViewModel</returns>
        public async Task<CustomerModel> DeleteCustomer(int CustomerID)
        {   // More to do here
            if (CustomerID == 0)
            {
                Log.Error("Customer API: CustomerService(DeleteCustomer); (CustomerID == 0)");
                return new CustomerModel();
            }
            else {  
                var entity = await _customerRepository.GetCustomerAsync(CustomerID);
                if (entity == null)
                {
                    Log.Error("Customer API: CustomerService(DeleteCustomer); (entity == null)");
                    return new CustomerModel();
                }
                else
                {
                    int? refID = null;
                    using (TransactionScope scope = new TransactionScope())
                    {
                        _customerRepository.Remove(entity);
                        _customerRepository.SaveChanges();
                        scope.Complete();
                        refID = entity.CustomerID;
                    }
                    return Mapper.MapObject(entity, new CustomerModel());
                }
            }
        }
        #endregion









        #region Other
        #endregion
    }

}

































