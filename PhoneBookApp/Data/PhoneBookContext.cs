using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Models;

namespace PhoneBookApp.Data;

public class PhoneBookContext : DbContext
{
    public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
    { }

    public DbSet<PhoneBookItem> PhoneBookItems => Set<PhoneBookItem>();
}
