using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using task2asp9.Models;

namespace task2asp9.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
    }
}
