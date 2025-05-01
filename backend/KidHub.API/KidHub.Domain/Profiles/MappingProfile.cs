using AutoMapper;
using KidHub.Data.Entities;
using KidHub.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Domain.Profiles
{
       
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {

                CreateMap<Course, CourseDto>();

            // Define the mapping between CreateCourseDto and Course
                CreateMap<CreateCourseDto, Course>();

            // Define the mapping between User and UserDto
                CreateMap<User, UserDto>();
                CreateMap<CreateUserDto, User>();

        }
    }
    }

