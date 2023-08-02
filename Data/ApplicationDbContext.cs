using Microsoft.EntityFrameworkCore;
using WebAddressBookCF.Models;

namespace WebAddressBookCF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
