using API_Model;
using Microsoft.EntityFrameworkCore;

namespace API_Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options) {}
    
    public DbSet<Contact> Contact { get; set; }
}