global using StoreWebAPI.Data;
global using Microsoft.EntityFrameworkCore;
using StoreWebAPI.Data.DAL;
using StoreWebAPI.Helpers;
using StoreWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Configuration EntityFrameWork DataContext
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ShoppConnection")).EnableSensitiveDataLogging());

//Menambahkan Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Inject class DAL
builder.Services.AddScoped<IProduct, ProductDAL>();
builder.Services.AddScoped<IAddress, AddressDAL>();

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
//app.UseAuthorization();

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
