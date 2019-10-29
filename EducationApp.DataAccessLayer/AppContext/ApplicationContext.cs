using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.AppContext
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, Role, long>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorInPrintingEdition> AuthorInPrintingEditions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PrintingEdition> PrintingEditions { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
    }
}