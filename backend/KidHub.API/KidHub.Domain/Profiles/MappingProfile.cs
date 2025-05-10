using AutoMapper;
using KidHub.Data.Entities;
using KidHub.Domain.Dtos.CourseDtos;
using KidHub.Domain.Dtos.IdentityDtos;
using KidHub.Domain.Dtos.LessonDtos;

namespace KidHub.Domain.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Define the mapping between Course and CourseDto
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Lessons)); // Mapping lessons

            // Define the mapping between CreateCourseDto and Course
            CreateMap<CreateCourseDto, Course>();

            // Define the mapping between User and UserDto
            CreateMap<User, UserDto>();
            CreateMap<RegisterDto, User>();

            // Define the mapping between Lesson and LessonDto
            CreateMap<Lesson, LessonDto>().ReverseMap();


            CreateMap<CreateLessonDto, Lesson>(); // Mapping from CreateLessonDto to Lesson

        }
    }
}
