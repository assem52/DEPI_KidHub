using KidHub.Domain.Dtos.LessonDtos;

namespace KidHub.Domain.Dtos.CourseDtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? ThumbnailUrl { get; set; }
        public decimal? Price { get; set; }
        public bool? IsPremiumOnly { get; set; }
        public ICollection<LessonDto> Lessons { get; set; }

    }




}
