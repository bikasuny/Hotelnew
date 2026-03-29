using Hotel.Application.Services;
using Hotel.Core.DataContext;
using Hotel.Core.Entities;
using Hotel.Core.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<GenericRepository<User>>();

builder.Services.AddScoped<CityService>();
builder.Services.AddScoped<GenericRepository<City>>();

builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<GenericRepository<Room>>();

builder.Services.AddScoped<BookedRoomService>();
builder.Services.AddScoped<GenericRepository<BookedRoom>>();

builder.Services.AddScoped<HotelService>();
builder.Services.AddScoped<GenericRepository<CityHotel>>();

//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CSI_AuthprozationHelperV1");
//});

//builder.Services.AddSwaggerGen(c=>
//{
//    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "", Version = "v1" });
    
//    )
//})
builder.Services.AddDbContext<HotelDbContext>(i =>
{
    i.UseSqlServer(builder.Configuration.GetConnectionString("HotelDbContext"));
});

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();



