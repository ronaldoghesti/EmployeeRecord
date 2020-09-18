using ER.Data.Context;
using ER.Domain.Interfaces.Repositories;
using ER.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ERDbContext db) : base(db)
        {
        }

        public async Task<Employee> GetByName(string name)
        {
            return await DbSet.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<bool> Exists(string name)
        {
            return await DbSet.AnyAsync(e => e.Name == name);
        }
    }
}
