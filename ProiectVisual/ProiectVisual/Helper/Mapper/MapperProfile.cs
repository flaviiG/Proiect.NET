using AutoMapper;
using ProiectVisual.Models;
using ProiectVisual.Models.DTOs;

namespace ProiectVisual.Helper.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<Department, DepartmentDTO>().ReverseMap();

        }
    }
}
