
using HospitalAPI.Application.Interfaces;
using HospitalAPI.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});
//builder.Services.AddMediatR(cfg =>
    //cfg.RegisterServicesFromAssembly(typeof(HospitalAPI.Application.AssemblyReference).Assembly));
builder.Services.AddMediatR(typeof(HospitalAPI.Application.AssemblyReference).Assembly);


builder.Services.AddDbContext<HospitalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalDb")));
builder.Services.AddScoped<IHospitalDbContext>(provider =>
    provider.GetRequiredService<HospitalDbContext>());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAngularApp");
app.MapControllers();
app.Run();


