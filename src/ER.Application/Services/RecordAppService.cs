using AutoMapper;
using ER.Application.ViewModels;
using ER.Domain.Interfaces.Services;
using ER.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER.Application.Services
{
    public class RecordAppService : IRecordAppService
    {
        private readonly IRecordService _recordService;
        private readonly IMapper _mapper;


        public RecordAppService(IRecordService recordService, IMapper mapper)
        {
            _recordService = recordService;
            _mapper = mapper;
        }

        public async Task Create(RecordViewModel recordVM)
        {
            var record = _mapper.Map<Record>(recordVM);
            await _recordService.Create(record);
        }

        public async Task Delete(Guid id)
        {
            var record = await _recordService.GetById(id);
            if (record != null)
            {
                await _recordService.Delete(record);
            }
        }

        public async Task<IEnumerable<RecordViewModel>> GetAll()
        {
            var records = await _recordService.GetAll();

            return _mapper.Map<IEnumerable<RecordViewModel>>(records);
        }

        public async Task<RecordViewModel> GetById(Guid id)
        {
            var record = await _recordService.GetById(id);

            return _mapper.Map<RecordViewModel>(record);
        }

        public async Task Update(RecordViewModel recordVM)
        {
            var record = _mapper.Map<Record>(recordVM);

            await _recordService.Update(record);
        }
    }
}
