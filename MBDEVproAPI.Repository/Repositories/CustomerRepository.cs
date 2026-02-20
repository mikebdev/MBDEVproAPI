
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






        public IEnumerable<CustomerModel> GetAll()
        {
            return _context.Customers.Select(x => new CustomerModel
            {
                CustomerID = x.CustomerID,
                Company = x.Company,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Title = x.Title,
                BPhone = x.BPhone,
                HPhone = x.HPhone,
                MPhone = x.MPhone,
                Fax = x.Fax,
                Address = x.Address,
                City = x.City,
                State = x.State,
                ZIPCode = x.ZIPCode,
                Country = x.Country,
                WebPage = x.WebPage,
                Notes = x.Notes,
                Photo = x.Photo,
                Map = x.Map
            }).ToList();
        }


        public void Add(CustomerModel obj)
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
