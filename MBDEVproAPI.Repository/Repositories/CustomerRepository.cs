
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



        #region 
        #endregion



        #region Get All Customers
        /// <summary>
        /// GET: Get All Customers | CustomerViewModel | Gets all customers for a business in a VM for web UI. 
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <returns>customers</returns>
        public async Task<IEnumerable<Customer>> GetAllCustomersVMAsync(int BusinessID)
        {
            var customers = await _context.Customers.Where(O => O.BusinessID == BusinessID).ToListAsync();
            return customers;
        }

        /// GET: Get All Customers | CustomerModel | Gets all customers for a business.
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <returns>customer</returns>
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(int BusinessID)
        {
            var customers = await _context.Customers.Where(O => O.BusinessID == BusinessID).ToListAsync();
            return customers;
        }
        #endregion



        #region Get Customer
        /// <summary>
        /// GET: Get Customer | Customer | Gets a customer for a business.  
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
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



        #region Add Customer
        public void Add(Customer obj)
        {
            _context.Customers.Add(obj);
        }
        #endregion



        #region Edit Customer
        #endregion



        #region Delete Customer
        //Task<SaveViewModel> DeleteCustomerVM(int CustomerID);
        public void DeleteCustomerVM(Customer obj)
        {
            _context.Customers.Remove(obj);
        }

        public void Remove(Customer obj)
        {
            _context.Customers.Remove(obj);
        }
        #endregion


        #region Save Customer
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion



        #region Other
        public Customer GetByID(int BusinessID, int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll(int BusinessID)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
