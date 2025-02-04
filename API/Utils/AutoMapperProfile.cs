using API.Dtos.CreateUser;
using API.Dtos.UserProfile;
using API.Models;
using API.Repository;
using AutoMapper;

namespace API.Utils;

public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    CreateMap<FieldOfInterest, FieldOfInterestDto>();
    CreateMap<Interest, InterestDto>();
    CreateMap<Education, EduDto>().ForMember(a => a.DegreeName, b =>
            b.MapFrom(c => c.Degree.DegreeName));
    CreateMap<EducationUpdateDto, Education>();
    CreateMap<WorkExperience, WorkHistoryDto>().ForMember(d => d.IndustryName,
          o => o.MapFrom(s => s.Indudtry.IndustryName));

  }
}
