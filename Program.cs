using DevProjeto.API.Persistence;
using DevProjeto.API.Persistence.repository;
using Microsoft.EntityFrameworkCore;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<devProjContext>();
var connectionString = builder.Configuration.GetConnectionString("DevProjCs");
builder.Services.AddDbContext<devProjContext>(O => O.UseInMemoryDatabase("Delivery"));

builder.Services.AddScoped<IPackegeRepository, PackegeRepository>();

var sendGridApiKey = builder.Configuration.GetSection("SendGridApiKey").Value;


builder.Services.AddSendGrid(o => o.ApiKey = sendGridApiKey);
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
