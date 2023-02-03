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
    option.UseSqlServer(builder.Configuration.GetConnectionString("connectionStringCloud"));
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(o => o.AddPolicy("LowCorsPolicy", builder =>
{
    builder.WithOrigins("http://localhost:3000")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
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
builder.Services.AddScoped<IDichVuKhuTroRespository, DichVuKhuTroRepository>();
builder.Services.AddScoped<IDichVuPhongRespository, DichVuPhongRespository>();
builder.Services.AddScoped<IHoaDonRepository, HoaDonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("LowCorsPolicy");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
