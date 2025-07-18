var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddInfrastructureJWT()
    .AddInfrastructureSwagger()
    .AddInfrastructureCORS(builder.Configuration);

builder.Services.
    AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors(builder.Configuration.GetSection("Cors:PolicyName").Value!);
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
