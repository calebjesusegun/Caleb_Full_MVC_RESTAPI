using AutoMapper;
using CalebMVCAPI.Dtos;
using CalebMVCAPI.Models;

namespace CalebMVCAPI.Profiles
{
   public class calebAPIProfile : Profile
   {
      public calebAPIProfile()
      {
         // Source => Target
         CreateMap<calebModels, calebAPIReadDto>();
         CreateMap<calebAPICreateDto, calebModels>();
         CreateMap<calebAPIUpdateDto, calebModels>();
         CreateMap<calebModels, calebAPIUpdateDto>();
      }
   }
}