using hosman_api.Data;
using hosman_api.Interface;
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

//Register Repositories
builder.Services.AddScoped<IDanhSachNguoiTroRepository, DanhSachNguoiTroRepository>();
builder.Services.AddScoped<IBinhLuanRepository, BinhLuanRepository>();
builder.Services.AddScoped<IDangKyXemPhongRepository, DangKyXemPhongRepository>();
builder.Services.AddScoped<IDichVuRepository, DichVuRepository>();
builder.Services.AddScoped<IDmManHinhRepository, DmManHinhRepository>();
builder.Services.AddScoped<IDongHoNuocRepository, DongHoNuocRespository>();
builder.Services.AddScoped<IDongHoDienRepository, DongHoDienRepository>();
builder.Services.AddScoped<IKhuTroRepository, KhuTroRepository>();
builder.Services.AddScoped<ILoaiPhongRepository, LoaiPhongRepository>();
builder.Services.AddScoped<INguoiDungRepository, NguoiDungRepository>();
builder.Services.AddScoped<IPhieuChiRepository, PhieuChiRepository>();
builder.Services.AddScoped<IPhieuCocGiuPhongRepository, PhieuCocGiuPhongRepository>();
builder.Services.AddScoped<IPhongRepository, PhongRepository>();
builder.Services.AddScoped<IPhongRepository, PhongRepository>();
builder.Services.AddScoped<IPhuLucRepository, PhuLucRepository>();
builder.Services.AddScoped<ITienIchRepository, TienIchRepository>();
builder.Services.AddScoped<IYeuCauSuaChuaRepository, YeuCauSuaChuaRepository>();
builder.Services.AddScoped<IHopDongRepository, HopDongThueRepository>();

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
