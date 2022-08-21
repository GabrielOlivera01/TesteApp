using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Pega a minha string de conex�o no arquivo appsettings.json e faz a conex�o com o banco.
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApiContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configura��o do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("All", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Configura��o do CORS
app.UseCors("All");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
