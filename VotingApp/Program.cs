using Microsoft.EntityFrameworkCore;
using VotingApp;
using VotingApp.Entities;
using VotingApp.Interfaces;
using VotingApp.Services;
using VotingApp.Repositories;
using AutoMapper;
using System.Reflection;
using VotingApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<VotingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<VotingSeeder>();
builder.Services.AddScoped<ICandidatesService, CandidatesService>();
builder.Services.AddScoped<IVotersService, VotersService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<ICandidatesRepository, CandidatesRepository>();
builder.Services.AddScoped<IVotersRepository, VotersRepository>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<VotingSeeder>();

seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();