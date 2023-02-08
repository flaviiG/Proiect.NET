using Microsoft.EntityFrameworkCore;
using ProiectVisual.Data;
using ProiectVisual.Repositories.MemberRepository;
using ProiectVisual.Services.MemberService;
using ProiectVisual.Services.MemberServices;
using Newtonsoft.Json.Serialization;
using ProiectVisual.Helper.Extensions;
using ProiectVisual.Helper.Seeders;
using ProiectVisual.Helper;
using ProiectVisual.Repositories.UserRepository;
using ProiectVisual.Helper.JwtToken;
using ProiectVisual.Helper.JwtUtils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddTransient<IJwtUtils, JwtUtils>();
builder.Services.AddSeeders();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<MemberSeeder>();
        service.seedInitialMembers();
    }
}