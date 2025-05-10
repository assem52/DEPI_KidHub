using KidHub.Data.Data;
using KidHub.Data.Repositories.CourseRepo;
using KidHub.Domain.Services.CourseService;
using Microsoft.EntityFrameworkCore;
using KidHub.Domain.Services;
using KidHub.Domain.Profiles;
using KidHub.Domain.Services.UserService;
using Microsoft.AspNetCore.Identity;
using KidHub.Services.UserService;
using KidHub.Data.Entities;
using KidHub.Data.Repositories.LessonRepository;
using KidHub.Domain.Services.LessonService;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using KidHub.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure the DbContext with SQL Server connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AutoMapper for object-to-object mapping
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services for repositories and services
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<JwtService>();

// Add ASP.NET Core Identity for user management
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "KidHub API", Version = "v1" });

    // Add JWT authentication to Swagger UI
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by your JWT token."
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// JWT Authentication Configuration
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "YourApp", // Use your actual issuer here
            ValidAudience = "YourAppUsers", // Use your actual audience here
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("your_super_secret_key_here_!123")) // Store in appsettings or environment variables
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();  // For serving static files (e.g., JS, CSS, images)
app.UseRouting();  // Sets up endpoint routing
app.UseDefaultFiles(); // Use default files like index.html if any

// Authentication and Authorization middleware
app.UseAuthentication();  // Ensure authentication happens before authorization
app.UseAuthorization();   // Authorize based on user roles or claims

app.UseHttpsRedirection();  // Redirect HTTP requests to HTTPS

// Map controllers (API endpoints)
app.MapControllers();

app.Run();
