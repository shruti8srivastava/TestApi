using Microsoft.EntityFrameworkCore;
using TestApi.Model;

namespace TestApi.DataBase;

public class ApplicationDbContext : DbContext
{
public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Add DbSet properties for your tables
        public required DbSet<EmployeeModel> Employees { get; set; }
}
