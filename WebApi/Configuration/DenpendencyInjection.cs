using Application.IRepository.Imp;
using Application.IRepository;
using Application;
using Azure.Storage.Blobs;
using Infrastructure.IUnitofwork;
using Infrastructure.Security.Token.Imp;
using Infrastructure.Security.Token;
using Infrastructure.Service.Imp;
using Infrastructure.Service;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Security.HashPassword;
using Infrastructure.Security.HashPassword.Imp;

namespace WebApi.Configuration
{
    public static class DenpendencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services,
            string databaseConnection, string azureBlobStorage)
        {
            // CONNECT DB
            services.AddDbContext<FootBall_PitchContext>(options => { options.UseSqlServer(databaseConnection); });

            // SIGN UP UNIT OF WORK FOR REPO
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // SIGN UP REPO
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IFeedBackRepository, FeedBackRepository>();
            services.AddTransient<ILandRepository, LandRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IPitchRepository, PitchRepository>();
            services.AddTransient<IPitchImageRepository, PitchImageRepository>();
            services.AddTransient<IPriceRepository, PriceRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();


            // SIGN UP SERVICE
            services.AddTransient<AccountService, AccountImplement>();
            services.AddTransient<AdminService, AdminImplement>();
            services.AddTransient<BookingService, BookingImplement>();
            services.AddTransient<CustomerService, CustomerImplement>();
            services.AddTransient<FeedbackService, FeedbackImplement>();
            services.AddTransient<LandService, LandImplement>();
            services.AddTransient<OwnerService, OwnerImplement>();
            services.AddTransient<PitchService, PitchImplement>();
            //services.AddTransient<PitchImageService, PitchImageImplement>();
            services.AddTransient<PriceService, PriceImplement>();
            services.AddTransient<ScheduleService, ScheduleImplement>();
            services.AddTransient<FileService, FileServiceImplement>();
            services.AddTransient<IMailService, MailService>();

            services.AddScoped<ITokensHandler, TokensHandler>(); 
            services
                .AddTransient<IPasswordHasher,
                    PasswordHasher>(); 
            services.AddScoped<AuthenService, AuthenImplement>();

            services.AddScoped(_ => new BlobServiceClient(azureBlobStorage));
            services.AddAutoMapper(typeof(ApplicationMapper).Assembly);
            return services;
        }
    }
}
