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


        #region CustomerViewModel
        /// <summary>
        /// GET: Customers
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <returns></returns>
        public CustomerViewModel GetAllCustomers(int BusinessID)
        {
            try
            {
                if (BusinessID == 0)
                {
                    Log.Error("Customer API: CustomerService(GetAllCustomers); (BusinessID == 0)");
                    return null;
                }
                else
                {
                    CustomerViewModel model = new CustomerViewModel();
                    model.CustomerList = _customerRepository.GetAllCustomers(BusinessID).Select(O => Mapper.MapObject(O, new CustomerModel())).ToList();
                    //model.BusinessID = BusinessID;
                    if (model == null)
                    {
                        Log.Error("Customer API: CustomerService(GetAllCustomers); (model == null)");
                        return null;
                    }
                    else
                    {
                        return model;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Customer API: CustomerService(GetAllCustomers); (" + ex + ")" + " (" + ex.InnerException + ")");
                return null;
            }
        }

        /// <summary>
        /// GET: Customers async
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <returns></returns>
        public async Task<CustomerViewModel> GetAllCustomersAsync(int BusinessID)
        {
            try
            {
                if (BusinessID == 0)
                {
                    Log.Error("Customer API: CustomerService(GetAllCustomersAsync); (BusinessID == 0)");
                    return null;
                }
                else
                {
                    CustomerViewModel model = new CustomerViewModel();
                    var customers = await _customerRepository.GetAllCustomersAsync(BusinessID);

                    if (customers == null)
                    {
                        Log.Error("Customer API: CustomerService(GetAllCustomersAsync); (customers == null)");
                        return null;
                    }

                    model.CustomerList = customers.Select(o => Mapper.MapObject(o, new CustomerModel())).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Customer API: CustomerService(GetAllCustomersAsync); (" + ex + ")" + " (" + ex.InnerException + ")");
                return null;
            }
        }





        //public IncidentViewModel GetIncidentsByProjectID(int ProjectID)
        //{
        //    IncidentViewModel model = new IncidentViewModel();
        //    try
        //    {
        //        if (ProjectID == 0)
        //        {
        //            Log.Error("Incidents API: IncidentService(GetIncidentsByProjectID); (ProjectID == 0)");
        //            return model;
        //        }
        //        else
        //        {
        //            model = Mapper.MapObject(_incidentRepository.GetIncidentsByProjectID(ProjectID), new IncidentViewModel());

        //            if (model == null)
        //            {
        //                Log.Error("Incidents API: IncidentService(GetIncidentsByProjectID); (model == null)");
        //                return model;
        //            }
        //            else
        //            {
        //                // INCIDENTS
        //                model.IncidentList = (List<IncidentModel>)GetIncidents(ProjectID);
        //                return model;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("Incidents API: IncidentService(GetIncidentsByProjectID); (" + ex + ")" + " (" + ex.InnerException + ")");
        //        return model;
        //    }
        //    finally
        //    {

        //    }
        //}




        //BusinessID = 52466; // temp hard coded for testing; need to get from token or pass in as parameter
        //    var customers = _customerRepository.GetAll(BusinessID).ToList();

        //    if (customers == null)

        //    {
        //        Log.Error("Customers API: CustomerService(GetAllCustomers); (customers == null");
        //        return null; // return empty model?
        //    }
        //    else
        //    {
        //        return customers.ToList();
        //    }
        //}
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

















