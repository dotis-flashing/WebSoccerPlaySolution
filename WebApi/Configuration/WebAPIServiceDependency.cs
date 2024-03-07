using Infrastructure.Security;
using WebApi.Middleware;

namespace WebApi.Configuration
{
    public static class WebAPIServiceDependency
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services, IConfiguration configuration)
        {
            // ADD DB
            var appConfiguration = configuration.GetSection("ConnectString").Get<AppConfiguration>();
            services.AddInfrastructuresService(appConfiguration.DatabaseConnection, appConfiguration.AzureBlobStorage);
            services.AddSingleton(appConfiguration);


            // ADD SWAGGERJWT
            var jwt = configuration.GetSection("JWT").Get<JWToken>();
            services.AddSwaggerJWT(jwt.JWTSecretKey, jwt.Issuer, jwt.Audience);
            services.AddSingleton(jwt);


            // ALLOW HTTP
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                });
            });

            //Endpoint
            services.AddSingleton<GlobalExceptionMiddleware>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHealthChecks();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
