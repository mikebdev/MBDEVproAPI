

using MBDEVproAPI.DataModel.Entities;
using System.Collections;

namespace MBDEVproAPI.API.Controllers 
{
    public class CustomerController : BaseController
    {

        #region variables and constructors
        /*private readonly MBDEVproAPIDbContext _context*/
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion



        #region Get All Customers
        //[HttpGet]
        //public IEnumerable<CustomerModel> GetAllGetAllCustomers()
        //{
        //    if (id == 0)
        //    {
        //        Log.Error("Customer API: GetAllGetAllCustomers; ()");
        //    }
        //    return (IEnumerable<CustomerModel>)Ok(_customerService.GetAllCustomers);
        //}
        #endregion

        // GET: api/GetAllGetAllCustomers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Customer>>> GetAllGetAllCustomers()
        //{
        //    var customers = await _customerService.GetAllCustomers();

        //    if (customers == null)
        //    {
        //        return NotFound();
        //    }

        //    return customers;
        //}


        //EXAMPLE
        #region Get All Customers
        [HttpGet("{id}")]
        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            return (IEnumerable<CustomerModel>)Ok(_customerService.GetAllCustomers());
        }
        #endregion







        //// GET: api/Customer/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CustomerModel>> GetCustomer(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return customer;
        //}



        //// GET: api/Customer
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        //{
        //    return await _context.Customers.ToListAsync();
        //}

        //// GET: api/Customer/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomer(int id)
        //{
        //    var customer = await _context.Customers.FindAsync(id);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return customer;
        //}

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
