using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Persistence.Context;
public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
            
    }
}
