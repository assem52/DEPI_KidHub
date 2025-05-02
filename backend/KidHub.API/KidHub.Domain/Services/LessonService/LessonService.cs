using AutoMapper;
using KidHub.Data.Entities;
using KidHub.Data.Repositories.LessonRepository;
using KidHub.Domain.Dtos.LessonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidHub.Domain.Services.LessonService
{
     public class LessonService : ILessonService
    {

        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;
        public async Task<IEnumerable<LessonDto>> GetAllLessonsAsync()
        {
            var lessons = await _lessonRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LessonDto>>(lessons);
        }

        public async Task<LessonDto?> GetLessonByIdAsync(Guid id)
        {
            var lesson = await _lessonRepository.GetAsync(id);
            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task<LessonDto> CreateLessonAsync(CreateLessonDto dto)
        {

            var lesson = _mapper.Map<Lesson>(dto);
            await _lessonRepository.AddAsync(lesson);
            await _lessonRepository.SaveAsync();
            return _mapper.Map<LessonDto>(lesson);
        }
    }
}
