using Artsofte.Dtos;
using Artsofte.Models;
using AutoMapper;
using System.Linq;

namespace Artsofte.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EmployeeDataFromDb, EmployeeEditDto>();
         
        }
    }
}
