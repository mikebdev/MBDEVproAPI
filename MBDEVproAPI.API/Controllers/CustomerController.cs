namespace MBDEVproAPI.API.Controllers 
{

    //[ApiController]
    //[Route("[controller]")]
    [ApiController, AllowAnonymous, Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase //: BaseController
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


        #region CustomerViewModel
        ///// <summary>
        ///// GET: Gets all customers for a business.  
        ///// https://localhost:7092/api/Customer/GetAllCustomers/52466
        ///// "CustomerControllerGetAllCustomers": "Customer/GetAllCustomers",
        ///// </summary>
        ///// <param name="BusinessID"></param>
        ///// <returns></returns>
        //[Route("GetAllCustomers")]
        //[HttpGet("{BusinessID}")]
        //public ActionResult<CustomerViewModel> GetAllCustomers(int BusinessID)
        //{
        //    BusinessID = 52466; // temp hard code for testing, can remove later.
        //    try
        //    {
        //        var customers = _customerService.GetAllCustomers(BusinessID);
        //        // can check null here and model is valid.
        //        return Ok(customers);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Customer API error: " + ex.Message + " | " + ex.InnerException);
        //    }
        //}

        /// <summary>
        /// GET: Gets all customers for a business.  
        /// https://localhost:7092/api/Customer/GetAllCustomersAsync/52466
        /// "CustomerControllerGetAllCustomersAsync": "Customer/GetAllCustomersAsync",
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <returns></returns>
        //[Route("GetAllCustomersAsync")]
        [HttpGet("{BusinessID}")]
            public async Task<ActionResult<CustomerViewModel>> GetAllCustomersAsync(int BusinessID)
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

        //// GET: api/Customer/5
        //[HttpGet("{CustomerID}")]
        //public async Task<ActionResult<Customer>> GetCustomerAsync(int CustomerID)
        //{
        //    var customer = await _context.Customers.FindAsync(CustomerID);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return customer;
        //}
        #endregion


        //// PUT: api/Customer/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
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





