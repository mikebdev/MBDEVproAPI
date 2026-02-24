
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








        #region async methods
        public async Task<IEnumerable<Customer>> GetAllAysnc(int BusinessID)
        {
            var customers = await _context.Customers.Where(O => O.BusinessID == BusinessID).ToListAsync();

            return customers;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(int BusinessID)
        {
            var customers = await _context.Customers.Where(O => O.BusinessID == BusinessID).ToListAsync();
            return customers;
        }
        #endregion




        #region regular methods

        #endregion



        #region Customer
        public IEnumerable<Customer> GetAll(int BusinessID)
        {
            var customers = _context.Customers.Where(O => O.BusinessID == BusinessID).ToList(); 

            return customers;
        }

        public IEnumerable<Customer> GetAllCustomers(int BusinessID)
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
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ProjectID"></param>
        ///// <param name="CitationTypeID"></param>
        ///// <returns></returns>
        //public CitationType GetByID(int ProjectID, int? CitationTypeID)
        //{
        //    return _context.CitationType
        //        .Where(O => O.ProjectID == ProjectID && O.CitationTypeID == CitationTypeID).FirstOrDefault();
        //}



        public void Remove(int BusinessID, Customer obj)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }


        #endregion



    }
}
