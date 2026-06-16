namespace MBDEVproAPI.API.Controllers
{
    public class CustomerController : BaseController
    {

        #region variables and constructors

        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
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
        //[Route("GetAllCustomers")]
        //[HttpGet("{BusinessID}")]
        [HttpGet]
        public async Task<ActionResult<CustomerViewModel>> GetAllCustomersVMAsync(int BusinessID)
        {
            BusinessID = 52466; // temp hard code for testing, can remove later.
            try
            {
                var customers = await _customerService.GetAllCustomersVMAsync(BusinessID);

                if (customers == null)
                {
                    return NotFound();
                }

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest("Customer API error: " + ex.Message + " | " + ex.InnerException);
            }
        }


        /// <summary>
        /// GET: Get All Customers | CustomerModel | Gets all customers for a business.
        /// TEST URL: https://localhost:7092/api/Customer/GetAllCustomers?BusinessID=52466
        /// "CustomerControllerGetAllCustomersAsync": "Customer/GetAllCustomersAsync",
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CustomerModel>> GetAllCustomersAsync(int BusinessID)
        {
            BusinessID = 52466; // temp hard code for testing, can remove later.
            try
            {
                var customers = await _customerService.GetAllCustomersAsync(BusinessID);
                if (customers == null)
                {
                    return NotFound();
                }
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest("Customer API error: " + ex.Message + " | " + ex.InnerException);
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
        //[Route("GetCustomer")]
        //[HttpGet("{CustomerID}")]
        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomerAsync(int CustomerID)
        {
            var customer = await _customerService.GetCustomerAsync(CustomerID);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
        #endregion




        #region Create Customer
        /// <summary>
        /// Add Customer | CustomerViewModel | Create a new customer for a business from client web application using a CustomerViewModel.
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerVMAsync([FromBody] CustomerViewModel vm)
        {
            var result = await _customerService.CreateCustomerVMAsync(vm);
            return Ok(result);
        }


        /// <summary>
        /// Add Customer | CustomerModel | Create a new customer for a business.
        /// TEST URL: https://localhost:7092/api/Customer/CreateCustomer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerModel model)
        {
            var result = await _customerService.CreateCustomerAsync(model); 
            return Ok(result);
            //return Ok("UNDER CONTRUCTION | CreateCustomerAsync([FromBody] Customer model)");
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
        [HttpPost]
        public async Task<IActionResult> EditCustomerVMAsync([FromBody] CustomerViewModel vm)
        {
            // if model is valid, then update, else return bad request with model state errors.
            var result = await _customerService.EditCustomerVMAsync(vm);
            return Ok(result);
            //return Ok("UNDER CONTRUCTION | EditCustomer(int id, [FromBody] Customer model)");
        }


        /// <summary>
        /// EDIT: Customer | CustomerModel | edit a customer for a business.
        /// TEST URL: https://localhost:7092/api/Customer/EditCustomer?id=5
        /// "CustomerControllerEditCustomer": "Customer/EditCustomer"
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
         public async Task<IActionResult> EditCustomer([FromBody] CustomerModel model)
        {
            // if model is valid, then update, else return bad request with model state errors.
            var result = await _customerService.EditCustomer(model);    
            return Ok(result);
        }

        // CustomerModel to just return a CustomerModel instead of a SaveViewModel with the RefID. We could do this for the VM as well.
        #endregion



        #region Delete Customer
        /// <summary>
        /// DELETE: Customer | SaveViewModel | delete a customer for a business and return a SaveViewModel with the RefID of the deleted customer.
        /// "CustomerControllerDeleteCustomerVMAsync": "Customer/DeleteCustomerVMAsync"
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SaveViewModel</returns>
        [HttpDelete("{CustomerID:int}")]
        public async Task<IActionResult> DeleteCustomerVMAsync(int CustomerID)// LOOK   AT ALL THESE IN CONTROLLER COMPAARED TO LICENSE API, WE JUST USE ACTION RESULT HERE AND RETURN THE MODEL THAT IS IN THE SERVICE.
        {
            var result = await _customerService.DeleteCustomerVMAsync(CustomerID);
            return Ok(result);
        }
        #endregion
    }
}





