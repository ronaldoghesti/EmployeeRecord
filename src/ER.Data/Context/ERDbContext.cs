using ER.Domain.Enumerations;
using ER.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ER.Data.Context
{
    public class ERDbContext : DbContext
    {
        public ERDbContext(DbContextOptions<ERDbContext> options)
            : base(options)
        {
        }

        public DbSet<Record> Records { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RecordTypeEnumeration> RecordTypes { get; set; }
    }
}
