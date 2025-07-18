namespace NetSpeed.Evolution.Infrastructure.IoC;

public static class DependenceInjectionApi
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region DbContext

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<AppDbContext, AppDbContext>();
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        #endregion

        #region Repositories

        services.AddScoped<IJobTitleRepository, JobTitleRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IHardSkillRepository, HardSkillRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeHardSkillRepository, EmployeeHardSkillRepository>();
        services.AddScoped<ISwotRepository, SwotRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICycleRepository, CycleRepository>();
        services.AddScoped<IStrengthRepository, StrengthRepository>();
        services.AddScoped<IOpportunityRepository, OpportunityRepository>();
        services.AddScoped<IWeaknessRepository, WeaknessRepository>();
        services.AddScoped<IThreatRepository, ThreatRepository>();
        services.AddScoped<IActionPlain5W2HRepository, ActionPlain5W2HRepository>();
        services.AddScoped<IEmployeeTaskRepository, EmployeeTaskRepository>();
        services.AddScoped<IActionPlain5W2HFollowUpRepository, ActionPlain5W2HFollowUpRepository>();

        #endregion

        #region Services

        services.AddScoped<IJobTitleService, JobTitleService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IHardSkillService, HardSkillService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEmployeeHardSkillService, EmployeeHardSkillService>();
        services.AddScoped<ISwotService, SwotService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICycleService, CycleService>();
        services.AddScoped<IActionPlain5W2HService, ActionPlain5W2HService>();
        services.AddScoped<IEmployeeTaskService, EmployeeTaskService>();
        services.AddScoped<IActionPlain5W2HFollowUpService, ActionPlain5W2HFollowUpService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICypherService, CypherService>();

        #endregion

        services.AddAutoMapper(typeof(ProfileMapping));

        return services;
    }

    public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services)
    {
        var key = Encoding.ASCII.GetBytes("+WsLhdwMcCnW&cJW4a5hm^jFemE&?V?Y?z9eMdcN_X3DktLE7W9nS#Z2&vpakM6v");
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        return services;
    }

    public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        var linkedinProfile = "https://www.netspeed.com.br/";

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(
                "v1"
                , new OpenApiInfo
                {
                    Title = "NetSpeed.Evolution.Api",
                    Version = "v1",
                    Description = "Web Api da aplicação NetSpeed Evolution",
                    Contact = new OpenApiContact
                    {
                        Name = "Netspeed",
                        Email = "evolution@netspeed.com.br",
                        Url = new Uri(linkedinProfile)
                    },
                });

            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }

    public static IServiceCollection AddInfrastructureCORS(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy
            (
                name: configuration.GetSection("Cors:PolicyName").Value,
                policy => policy
                    .WithOrigins(configuration.GetSection("Frontend:Url").Value)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
            );
        });

        return services;
    }
}
