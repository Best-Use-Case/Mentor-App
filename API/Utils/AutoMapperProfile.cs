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
    CreateMap<Education, EduDto>();

  }
}
