using System.Data.Entity;
using Angular2Mvc.Models;

namespace Angular2Mvc.DataAccess
{
    public class DbAccessContext : DbContext
    {
        public DbAccessContext()
            : base("name=DbAccessContext") {
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}