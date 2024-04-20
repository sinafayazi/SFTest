using System.Text.Json.Serialization;
using StoreService.Api.Extensions.DependencyInjection;
using StoreService.Persistence;
using Microsoft.OpenApi.Models;
using StoreService.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguredDatabase(builder.Configuration);

builder.Services.AddServices();
builder.Services.AddConfiguredMediatR();

builder.Services.AddConfiguredHealthChecks();
builder.Services.AddSingleton<MemoryCacheInjection>();
builder.Services.AddMemoryCache();

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });


});

var app = builder.Build();

app.RunMigrations();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
