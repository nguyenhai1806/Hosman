using hosman_api.Data;
using hosman_api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Hosman123Context>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("connectionStringHai"));
});
builder.Services.AddAutoMapper(typeof(Program));

//Dang ky Respositories
builder.Services.AddScoped<IDanhSachNguoiTroRepository, DanhSachNguoiTroRespository>();

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
