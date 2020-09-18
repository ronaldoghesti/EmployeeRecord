using ER.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ER.Application.Services
{
    public interface IRecordAppService
    {
        Task Create(RecordViewModel recordVM);

        Task Delete(Guid id);

        Task<IEnumerable<RecordViewModel>> GetAll();

        Task<RecordViewModel> GetById(Guid id);

        Task Update(RecordViewModel recordVM);
    }
}
