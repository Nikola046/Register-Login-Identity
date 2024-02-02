using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webApp_Books.Models;

namespace webApp_Books.Data
{
    public class EFDBcontext:IdentityDbContext<ApplicationUser>
    {
        public EFDBcontext(DbContextOptions<EFDBcontext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set;}
    }
}
