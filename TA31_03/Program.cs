using Microsoft.EntityFrameworkCore;
using TA31_03.Modelo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//BBDD de Cientificos, Proyectos y AsignadoA
builder.Services.AddControllers();
builder.Services.AddDbContext<CientContext>(opt =>
    opt.UseInMemoryDatabase("CientificosList"));
builder.Services.AddDbContext<ProyContext>(opt =>
    opt.UseInMemoryDatabase("ProyContextList"));
builder.Services.AddDbContext<AsignContext>(opt =>
    opt.UseInMemoryDatabase("AsignadoAList"));

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
