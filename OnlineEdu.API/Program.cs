using Microsoft.EntityFrameworkCore;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.Bussiness.Concrete;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg => cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzkwMDM1MjAwIiwiaWF0IjoiMTc1ODU0MDE3OSIsImFjY291bnRfaWQiOiIwMTk5NzEyOTNjOTk3Y2YwOGI1MjA1NjE4MjEyYTZjOCIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazVyams5amE1ajFjYjN2YmRreDdreGhwIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.lGDdxjYhva5Voq1N28DT6Owc7HL3Uzmmusnuh8blMMvne8pCcwh43MfYoVlvkCzcEn9crYVo7X5YG6Bd7TZqNi7oh2EqOhRDoErDaMebdyfj9DBrZRxPD75rJCAi6 - LE - eTyXBx2R8nhS4quw8gIlZW5qcFHlNY1dNp - 7dJT7fEMOfIpKwiSAm6 - CZkVZ0TeIobNbJ2fNRe_bkwU75e04EPv6z90Q_WQoli4DxWwHoZdXag0AedatcM8rmESXdSHlEqaiN__qqB0ebzXVBP1pg6OzgQP7lgySDEiIwElNcKmPvVc_JYBcO1ujiWx3aUNBQhsCPqKWxCJL0xAhVNILQ", Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
// Add services to the container.
builder.Services.AddDbContext<OnlineEduContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
