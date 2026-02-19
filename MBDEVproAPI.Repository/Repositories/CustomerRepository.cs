
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









        public void Add(CustomerModel obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerModel> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetByID(int? id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id, CustomerModel obj)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
