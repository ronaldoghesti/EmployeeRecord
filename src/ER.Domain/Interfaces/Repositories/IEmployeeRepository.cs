using ER.Domain.Models;
using System;
using System.Threading.Tasks;

namespace ER.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<bool> Exists(string name);
        Task<Employee> GetByName(string name);
    }
}
