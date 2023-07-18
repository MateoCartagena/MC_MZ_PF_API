using MC_MZ_PF_API.Data;
using MC_MZ_PF_API.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<McMzPfDataContext>(builder.Configuration.GetConnectionString("PfConnection"));

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

app.MapArteEndpoints();

app.MapCulturaEndpoints();

app.MapDeporteEndpoints();

app.MapTecnologiaEndpoints();

app.Run();
