using Microsoft.EntityFrameworkCore;
using Proje.EntityFramework.Models;

namespace Proje.EntityFramework.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<SubGroup> SubGroup { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<ReceiptView> Receipt_View { get; set; }      
    }
}
