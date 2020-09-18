using ER.Domain.Interfaces;
using ER.Domain.Interfaces.Repositories;
using ER.Domain.Interfaces.Services;
using ER.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER.Domain.Services
{
    public class RecordService : BaseService, IRecordService
    {
        private readonly IRecordRepository _recordRepository;

        public RecordService(INotifier notifier, IRecordRepository recordRepository) : base(notifier)
        {
            _recordRepository = recordRepository;
        }

        public async Task Create(Record record)
        {
            await _recordRepository.Insert(record);
        }

        public async Task Delete(Record record)
        {
            await _recordRepository.Delete(record);
        }

        public async Task<List<Record>> GetAll()
        {
            return await _recordRepository.GetAll();
        }

        public async Task<Record> GetById(Guid id)
        {
            return await _recordRepository.GetById(id);
        }

        public async Task Update(Record record)
        {
            await _recordRepository.Update(record);
        }
    }
}
