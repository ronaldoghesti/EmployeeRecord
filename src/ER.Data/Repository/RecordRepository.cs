using ER.Data.Context;
using ER.Domain.Enumerations;
using ER.Domain.Interfaces.Repositories;
using ER.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER.Data.Repository
{
    public class RecordRepository : Repository<Record>, IRecordRepository
    {
        public RecordRepository(ERDbContext db) : base(db)
        {
        }

        public async override Task<Record> GetById(Guid id)
        {
            return await DbSet
                .Include(r => r.Employee)
                .Include(r => r.Type)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async override Task<List<Record>> GetAll()
        {
            return await DbSet
                .Include(r => r.Employee)
                .Include(r => r.Type)
                .ToListAsync();
        }

        public override async Task Insert(Record record)
        {
            var employee = await Db.Employees.FirstOrDefaultAsync(e => e.Name == record.Employee.Name);
            if (employee != null)
            {
                record.Employee = employee;
            }

            var recordType = await Db.RecordTypes.FirstOrDefaultAsync(r => r.Id == record.Type.Id);
            if (recordType != null)
            {
                record.Type = recordType;
            }

            await DbSet.AddAsync(record);
            await SaveChanges();
        }

        public async override Task Update(Record record)
        {
            var employee = await Db.Employees.FirstOrDefaultAsync(e => e.Name == record.Employee.Name);
            if (employee == null)
            {
                employee = new Employee(record.Employee.Name);
                Db.Employees.Add(employee);
            }
            record.Employee = employee;

            var recordType = await Db.RecordTypes.FirstOrDefaultAsync(r => r.Id == record.Type.Id);
            if (recordType == null)
            {
                recordType = Enumeration.GetById<RecordTypeEnumeration>(record.Type.Id);
                Db.RecordTypes.Add(recordType);
            }
            record.Type = recordType;

            DbSet.Update(record);
            await SaveChanges();
        }
    }
}