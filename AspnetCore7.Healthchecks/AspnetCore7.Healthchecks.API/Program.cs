using AspnetCore7.Healthchecks.Extensions.DependencyInjection;
using AspnetCore7.Healthchecks.Extensions.Healths;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddAppHealthChecks()
                .AddMapHealthChecksUi(configuration)
                .AddOptionsPattern(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHealthChecksMiddleware(configuration);

app.MapControllers();

app.Run();
