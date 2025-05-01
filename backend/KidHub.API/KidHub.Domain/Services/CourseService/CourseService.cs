using AutoMapper;
using KidHub.Data.Repositories.CourseRepo;
using KidHub.Domain.Dtos;
using KidHub.Data.Entities;

namespace KidHub.Domain.Services.CourseService;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
    {
        var courses = await _courseRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CourseDto>>(courses);
    }

    public async Task<CourseDto> GetCourseByIdAsync(Guid id)
    {
        var course = await _courseRepository.GetAsync(id);
        return _mapper.Map<CourseDto>(course);
    }

    public async Task<CourseDto> CreateCourseAsync(CreateCourseDto dto)
    {
        var course = _mapper.Map<Course>(dto);
        await _courseRepository.AddAsync(course);
        await _courseRepository.SaveAsync();

        return _mapper.Map<CourseDto>(course);
    }

    
}
