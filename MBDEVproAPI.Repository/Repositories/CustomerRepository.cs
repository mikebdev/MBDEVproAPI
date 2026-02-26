
using MBDEVproAPI.Common.Models;
using MBDEVproAPI.Common.ViewModels;
using MBDEVproAPI.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBDEVproAPI.Repository.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {

        #region Private variables & constructors

        /// <summary>
        /// Context
        /// </summary>
        private readonly MBDEVproAPIDbContext _context;

        /// <summary>
        /// Default contructor
        /// </summary>
        /// <param name="context"></param>
        public CustomerRepository(MBDEVproAPIDbContext context)
        {
            _context = context;
        }
        #endregion








        #region Get All Customers | CustomerViewModel
        /// <summary>
        /// GET: Get All Customers Async
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAllCustomersVMAsync(int BusinessID)
        {
            var customers = await _context.Customers.Where(O => O.BusinessID == BusinessID).ToListAsync();
            return customers;
        }
        #endregion


        #region Get All Customers | CustomerModel
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(int BusinessID)
        {
            var customers = await _context.Customers.Where(O => O.BusinessID == BusinessID).ToListAsync();
            return customers;
        }
        #endregion


        #region Get All Customers | Customer
        public async Task<Customer> GetCustomerAsync(int CustomerID)
        {
            var customer = await _context.Customers.Where(O => O.CustomerID == CustomerID).FirstOrDefaultAsync();
            if (customer == null)
            {
                Log.Error("Customer API: CustomerRepository(GetCustomerAsync); (customer == null)");
                return new Customer();
            }
            else
            {
                return customer;
            }
        }
        #endregion



        #region Add Customer Async  
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync(); // Non-blocking save
        }
        #endregion






        #region other
        public IEnumerable<Customer> GetAll(int BusinessID)
        {
            var customers = _context.Customers.Where(O => O.BusinessID == BusinessID).ToList();

            return customers;
        }

        ///// <summary>
        ///// Get a single record by ID
        ///// </summary>
        ///// <param name="BusinessID"></param>
        ///// <param name="CustomerID"></param>
        ///// <returns></returns>
        public Customer GetByID(int BusinessID, int? id)
        {
            var customer = _context.Customers.Where(O => O.BusinessID == BusinessID && O.CustomerID == id).FirstOrDefault();

            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            else
            {
                return customer;
            }
        }


        public void Add(Customer obj)
        {
            _context.Customers.Add(obj);
        }

        public void Remove(int BusinessID, Customer obj)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

 


        #endregion



    }
}
