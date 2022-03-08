using ExperianTechAssesment.Business.Interfaces;
using ExperianTechAssesment.Business.Services;
using ExperianTechAssesment.Extensions;
using ExperianTechAssesment.Middlewares;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ExperianTechAssesment API v1",
        Version = "v1",
        Description = "API for getting credit card offers for clients",
        Contact = new OpenApiContact { Name = "Marin Dimitrov", Email = "marindimitrov9833@gmail.com" },
        License = new OpenApiLicense { Name = "For Experian application only" }

    });
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "ExperianTechAssesment API v2",
        Version = "v2",
        Description = "API for getting credit card offers for clients",
        Contact = new OpenApiContact { Name = "Marin Dimitrov", Email = "marindimitrov9833@gmail.com" },
        License = new OpenApiLicense { Name = "For Experian application only" }

    });

    c.DocInclusionPredicate((version, desc) =>
    {
        return version == desc.GroupName;
    });
});
builder.Services.AddSingleton<ICreditCardOfferGenerator, CreditCardOfferGenerator>();
builder.Services.RegisterMongoDbRepositories();
builder.Services.AddSingleton<LoggingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
    c.SwaggerEndpoint($"/swagger/v2/swagger.json", $"v2");
});

app.UseAuthorization();
app.UseRequestResponseLogging();
app.MapControllers();
app.Run();
