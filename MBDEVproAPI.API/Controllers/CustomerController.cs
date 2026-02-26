

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


        #region Get All Customers | CustomerViewModel
        /// <summary>
        /// GET: Gets all customers for a business in a VM for web UI.  
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
        #endregion


        #region Get All Customers | CustomerModel
        /// <summary>
        /// GET: Gets all customers for a business.
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



        #region Get Customer | Customer
        /// <summary>
        /// GET: Gets a customer for a business.  
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



        #region Add Customer | CustomerViewModel   
        /// <summary>
        /// Create a new customer for a business from client web application using a CustomerViewModel.
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerVMAsync([FromBody] CustomerViewModel vm)
        {
            return Ok(_customerService.CreateCustomerVMAsync(vm));
        }
        #endregion



        #region Add Customer | Customer
        /// <summary>
        /// Create a new customer for a business.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerModel model)
        {
            return Ok(_customerService.CreateCustomerAsync(model));
            //return Ok("UNDER CONTRUCTION | CreateCustomerAsync([FromBody] Customer model)");
        }
        #endregion




        //// PUT - CREATE: api/Customer/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]

        //[HttpPost]
        //public async Task<IActionResult> PutCustomer(int id, Customer customer)
        //{
        //    if (id != customer.CustomerID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Customer
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        //{
        //    _context.Customers.Add(customer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCustomer", new { id = customer.CustomerID }, customer);
        //}


        //// DELETE: api/Customer/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomer(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Customers.Remove(customer);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CustomerExists(int id)
        //{
        //    return _context.Customers.Any(e => e.CustomerID == id);
        //}

    }

}





