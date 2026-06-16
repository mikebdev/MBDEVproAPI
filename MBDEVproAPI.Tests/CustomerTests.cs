using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MBDEVproAPI.Tests
{
    public class CustomerTests
    {

        #region Variables and Constructors

        private ICustomerService _customerService;

        #endregion

        public CustomerTests(ICustomerService customerService) {
        
            _customerService = customerService;

        }


        //using MBDEVproAPI.DataModel.Entities;
        private static readonly List<Customer> _customerListEntity = new() 
            { new Customer { CustomerID = 1, BusinessID = 52466, Company = "cheeseburger", FirstName = "Jeff", LastName = "Smith", Email = "Jeff@Smith.com", Address = "123 Test St" }
        };


        //using MBDEVproAPI.Common.Models;
        private static readonly List<CustomerModel> _customerListModel = new() 
            { new CustomerModel { CustomerID = 1, BusinessID = 52466, Company = "cheeseburger", FirstName = "Jeff", LastName = "Smith", Email = "Jeff@Smith.com", Address = "123 Test St" }
        };


        #region commented out code
        //public int CustomerID { get; set; }
        //public int BusinessID { get; set; }

        //public string? Company { get; set; }
        //public string FirstName { get; set; } = String.Empty;
        //public string LastName { get; set; } = String.Empty;

        //public string Email { get; set; } = String.Empty;

        //public string? Title { get; set; }
        //public string? BPhone { get; set; }
        //public string? HPhone { get; set; }
        //public string? MPhone { get; set; }
        //public string? Fax { get; set; }

        //public string Address { get; set; } = String.Empty;
        //public string City { get; set; } = String.Empty;
        //public string State { get; set; } = String.Empty;
        //public string ZIPCode { get; set; } = String.Empty;
        //public string Country { get; set; } = String.Empty;

        //public string? WebPage { get; set; }
        //public string? Notes { get; set; }
        //public string? Photo { get; set; }
        //public string? Map { get; set; }

        //public CustomerTests()
        //{
        //    var mock = new Mock<ICustomerService>();
        //    mock.Setup(s => s.GetCustomerAsync(It.IsAny<int>()))
        //        .ReturnsAsync((int id) => _customerListEntity.FirstOrDefault(c => c.CustomerID == id) ?? new Customer());
        //    mock.Setup(s => s.GetAllCustomersVMAsync(It.IsAny<int>()))
        //        .ReturnsAsync((int businessId) => new CustomerViewModel { CustomerList = _customerListEntity.Select(x => Mapper.MapObject(x, new CustomerModel())).ToList() });
        //    _customerService = mock.Object;
        //}


        //public class CustomerTests
        //{
        //    private ICustomerService _customerService;

        //    public CustomerTests()
        //    {
        //        _customerService = new TestCustomerService();
        //    }

        //    private static readonly List<Customer> _customerListEntity = new()
        //    {
        //        new Customer { CustomerID = 1, BusinessID = 52466, Company = "cheeseburger", FirstName = "Jeff", LastName = "Smith", Email = "Jeff@Smith.com", Address = "123 Test St" }
        //    };

        //    // Simple test-only implementation
        //    private class TestCustomerService : ICustomerService
        //    {
        //        public Task<Customer> GetCustomerAsync(int CustomerID)
        //        {
        //            var c = _customerListEntity.FirstOrDefault(x => x.CustomerID == CustomerID);
        //            return Task.FromResult(c ?? new Customer());
        //        }

        //        public Task<CustomerViewModel> GetAllCustomersVMAsync(int BusinessID)
        //        {
        //            var vm = new CustomerViewModel { CustomerList = _customerListEntity.Select(x => Mapper.MapObject(x, new CustomerModel())).ToList() };
        //            return Task.FromResult(vm);
        //        }

        //        // Implement other members of ICustomerService as no-op or throw NotImplementedException
        //        // ...
        //    }

        //    // tests follow...
        //}
        #endregion



        #region Tests

        [Fact]
        public async Task GetCustomerAsync()
        {
            var customer = await _customerService.GetCustomerAsync(3);
            Assert.NotNull(customer);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async Task GetCustomerAsyncID(int id)
        {
            var customer = await _customerService.GetCustomerAsync(id);
            Assert.NotNull(customer);
        }


        [Theory]
        [InlineData(52466)]
        public async Task GetAllCustomersVMAsyncTest(int id)
        {
            var customers = await _customerService.GetAllCustomersVMAsync(id);
            Assert.NotNull(customers);
        }

        #endregion


    }
}
