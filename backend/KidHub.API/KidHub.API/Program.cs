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
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.Options;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Cloudinary cloudinary = new Cloudinary("cloudinary://<api_key:<api_secret>@<cloudname>");

// Configure CloudinarySettings from appsettings.json
builder.Services.Configure<ICloudinary>(builder.Configuration.GetSection("MyService"));

// Add your controllers and other services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(typeof(MappingProfile)); // Registers the mapping profile



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<ILessonService, LessonService>();


// ASP.NET Core Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();







DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
Cloudinary cloudinar = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
cloudinary.Api.Secure = true;


// Upload an image and log the response to the console


var uploadParams = new ImageUploadParams()
{
    File = new FileDescription(@"https://cloudinary-devs.github.io/cld-docs-assets/assets/images/cld-sample.jpg"),
    UseFilename = true,
    UniqueFilename = false,
    Overwrite = true
};
var uploadResult = cloudinary.Upload(uploadParams);
Console.WriteLine(uploadResult.JsonObj);

// Get details of the image


var getResourceParams = new GetResourceParams("cld-sample")
{
    QualityAnalysis = true
};
var getResourceResult = cloudinary.GetResource(getResourceParams);
var resultJson = getResourceResult.JsonObj;

// Log quality analysis score to the console
Console.WriteLine(resultJson["quality_analysis"]);


// Transform the uploaded asset and generate a URL and image tag


var myTransformation = cloudinary.Api.UrlImgUp.Transform(new Transformation()
    .Width(300).Crop("scale").Chain()
    .Effect("cartoonify"));

var myUrl = myTransformation.BuildUrl("cld-sample");
var myImageTag = myTransformation.BuildImageTag("cld-sample");


Console.WriteLine(myUrl);

Console.WriteLine(myImageTag);

var uploadParam = new ImageUploadParams()
{
    File = new FileDescription(@"c:\my_image.jpg")
};
var uploadResul = cloudinary.Upload(uploadParams);


var uploadPara = new VideoUploadParams()
{
    File = new FileDescription(@"dog.mp4"),
    PublicId = "dog_closeup",
    EagerTransforms = new List<Transformation>()
  {
    new EagerTransformation().Width(300).Height(300).Crop("pad").AudioCodec("none"),
    new EagerTransformation().Width(160).Height(100).Crop("crop").Gravity("south").AudioCodec("none")
  },
    EagerAsync = true,
    EagerNotificationUrl = "https://mysite.example.com/my_notification_endpoint"
};
var uploadResu = cloudinary.Upload(uploadParams);

var uploadParamT = new VideoUploadParams()
{
    File = new FileDescription(@"my_large_video.mp4")
};
var uploadResulT = cloudinary.UploadLarge(uploadParams, 6000000);


var uploadParaMS = new VideoUploadParams()
{
    File = new FileDescription(@"my_very_large_video.mp4")
};
var uploadResuLT = await cloudinary.UploadLargeAsync<VideoUploadResult>(uploadParams, 5000000, 5);

Cloudinary cloudin = new Cloudinary(new Account("dkjbdq8wl","583761284229432","SdvJrrayhlGTiLcGzS6DDGPE52g"));


// Now you can call SignParameters on your Cloudinary instance

IDictionary<string, object> parameters = new Dictionary<string, object>()

{

{ "public_id", "my_image" },

{ "width", 300 },

{ "height", 200 },

{ "crop", "fill" }

};






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


