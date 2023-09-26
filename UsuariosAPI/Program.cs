using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Services;
using UsuariosAPI.Data;
using UsuariosAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("UsuarioConnection");
builder.Services.AddDbContext<UsuarioDBContext>
    (opts =>
    {
        opts.UseMySql(connString,
            ServerVersion.AutoDetect(connString));
    });

builder.Services.AddScoped<UsuarioService>();

builder.Services
    .AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<UsuarioDBContext>()
    .AddDefaultTokenProviders();

builder.Services
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<TokenService>();

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();
