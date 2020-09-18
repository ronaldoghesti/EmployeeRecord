using AutoMapper;
using ER.Application.ViewModels;
using ER.Domain.Models;

namespace ER.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Record, RecordViewModel>()
                .ForMember(v => v.EmployeeName, o => o.MapFrom(r => r.Employee.Name))
                .ForMember(v => v.CreatedAt, o => o.MapFrom(r => r.CreatedAt))
                .ForMember(v => v.TypeId, o => o.MapFrom(r => r.Type.Id))
                .ForMember(v => v.TypeDescription, o => o.MapFrom(r => r.Type.Name))
                .ForMember(v => v.Id, o => o.MapFrom(r => r.Id));
        }
    }
}
