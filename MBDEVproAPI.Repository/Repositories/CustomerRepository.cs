
using MBDEVproAPI.Common.Models;
using MBDEVproAPI.DataModel;
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








        #region CustomerViewModel



        #endregion




        #region CustomerModel

        #endregion



        #region Customer

        public void Add(Customer obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll(int BusinessID)
        {
            throw new NotImplementedException();
        }

        public Customer GetByID(int BusinessID, int? id)
        {
            throw new NotImplementedException();
        }

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
