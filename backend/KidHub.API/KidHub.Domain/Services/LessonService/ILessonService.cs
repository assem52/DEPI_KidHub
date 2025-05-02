using KidHub.Domain.Dtos.LessonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Domain.Services.LessonService
{
    public interface ILessonService
    {
        Task<IEnumerable<LessonDto>> GetAllLessonsAsync();
        Task<LessonDto?> GetLessonByIdAsync(Guid id);
        Task<LessonDto> CreateLessonAsync(CreateLessonDto dto);
    }
}
