using AutoMapper;
using ER.Application.ViewModels;
using ER.Domain.Enumerations;
using ER.Domain.Models;
using System;

namespace ER.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RecordViewModel, Record>()
                .ConstructUsing(r =>
                    new Record(
                        new Employee(r.EmployeeName),
                        Enumeration.GetById<RecordTypeEnumeration>(r.TypeId),
                        (DateTime)r.CreatedAt
                        )
                ).ForMember(r => r.Id, o => o.MapFrom(r => r.Id));
        }
    }
}
