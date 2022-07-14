using Microsoft.EntityFrameworkCore;
using AspProject.Entities;

namespace AspProject.ContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;
                Initial Catalog=ContactsDB;
                Integrated Security=True;
                Pooling=False");
        }
    }
}
