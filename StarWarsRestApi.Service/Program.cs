using StarWarsRestApi.Service.Data;
using StarWarsRestApi.Service.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<DataModel>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.AddDateOnlyConverters();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Update the AppUriHelper.AppUri
if (Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME") != null)
{
    AppUriHelper.AppUri = new Uri($"https://{Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME")}");
    AppUriHelper.IsInitialized = true;
}

app.Run();
