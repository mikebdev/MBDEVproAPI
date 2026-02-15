

namespace MBDEVproAPI.DataModel
{
    public partial class MBDEVproAPIDbContext : DbContext
    {

        public MBDEVproAPIDbContext()
        {


        }

        public MBDEVproAPIDbContext(DbContextOptions<MBDEVproAPIDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

    }
}
