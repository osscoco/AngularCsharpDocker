using ManagePassProtectIIA.API.Interfaces;
using ManagePassProtectIIA.API.Services;
using ManagePassProtectIIA.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
}); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injection Services
//builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection"))
//);
var serverVersion = new MySqlServerVersion(new Version(8, 3, 0)); // Remplacez par la version de votre serveur MySQL

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        serverVersion
    )
);

builder.Services.AddScoped<ITypeService, TypeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();

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
