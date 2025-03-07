using Microsoft.OpenApi.Models;
using System.Reflection;

namespace NetSpeed.Evolution.Infrastructure.IoC;

public static class DependenceInjectionApi
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<AppDbContext, AppDbContext>();
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        services.AddScoped<IJobTitleRepository, JobTitleRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        services.AddScoped<IJobTitleService, JobTitleService>();
        services.AddScoped<IDepartmentService, DepartmentService>();

        services.AddAutoMapper(typeof(ProfileMapping));

        return services;
    }

    public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        var linkedinProfile = "https://www.linkedin.com/in/misael-da-costa-homem-8b07a158/";

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => {
            options.SwaggerDoc(
                "v1"
                , new OpenApiInfo
                {
                    Title = "HouseRentals.Api",
                    Version = "v1",
                    Description = "Web Api to control house rentals.",
                    Contact = new OpenApiContact
                    {
                        Name = "Misael C. Homem",
                        Email = "misael.homem@gmail.com",
                        Url = new Uri(linkedinProfile)
                    },
                });

            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}
