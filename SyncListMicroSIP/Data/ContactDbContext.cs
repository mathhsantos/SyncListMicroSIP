using Microsoft.EntityFrameworkCore;
using SyncListMicroSIP.Data.Mappings;
using SyncListMicroSIP.Models;

namespace SyncListMicroSIP.Data
{
    public class ContactDbContext : DbContext
    {

        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());
        }
    }
}
