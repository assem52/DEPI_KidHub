namespace KidHub.Domain.Dtos
{
    public class CreateCourseDto
    {
            public string Title { get; set; }
            public string? Description { get; set; }
            public string? Category { get; set; }
            public string? ThumbnailUrl { get; set; }
            public decimal? Price { get; set; }
            public bool? IsPremiumOnly { get; set; }

    }
}
