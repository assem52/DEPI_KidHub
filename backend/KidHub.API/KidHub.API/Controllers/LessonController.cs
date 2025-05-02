using KidHub.Domain.Dtos.LessonDtos;
using KidHub.Domain.Services.LessonService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KidHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lessons = await _lessonService.GetAllLessonsAsync();
            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(id);
            if (lesson == null)
                return NotFound();
            return Ok(lesson);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLessonDto dto)
        {
            if (dto == null)
                return BadRequest("⚠️ CreateLessonDto was null—your JSON didn’t bind.");

            Console.WriteLine($"[CreateLesson] DTO → Title: {dto.Title}, ContentType: {dto.ContentType}, URL: {dto.ContentUrl}, CourseId: {dto.CourseId}");

            var created = await _lessonService.CreateLessonAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created }, created);
        }
    }
}
