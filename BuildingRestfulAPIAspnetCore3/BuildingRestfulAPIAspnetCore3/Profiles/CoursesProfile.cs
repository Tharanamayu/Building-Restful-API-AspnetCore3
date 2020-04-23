using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingRestfulAPIAspnetCore3.Profiles
{
    public class CoursesProfile : Profile
    {   
        public CoursesProfile()
        {
            CreateMap<CourseLibrary.API.Entities.Course,Models.CourseDto>();
        }
    }
}
