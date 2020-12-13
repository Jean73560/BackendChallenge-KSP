using AutoMapper;
using JPSD.ChallengeKSP.Domain.Entity;
using JPSD.ChallengeKSP.Application.DTO;

namespace JPSD.ChallengeKSP.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile() 
        {
            CreateMap<Employees, EmployeesDTO>().ReverseMap();
            CreateMap<Beneficiaries, BeneficiariesDTO>().ReverseMap();

        }
    }
}
