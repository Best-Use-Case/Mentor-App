using API.Data;
using API.Interfaces;
using API.Repository;
using API.Repository.AccountRepository;
using API.Repository.UserRepository;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
  {
    services.AddControllers();
    services.Configure<CloudinarySetting>(config.GetSection("Cloudinary"));
    services.AddScoped<ImageSerivice>();
    services.AddScoped<IClientDataRepository, ClientDataRepository>();
    services.AddScoped<IAccountRepository, AccountRepository>();
    services.AddScoped<IUserRepo, UserRepo>();
    services.AddScoped<ITokenService, TokenService>();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddDbContext<DataContext>(options =>
           options.UseSqlite(config.GetConnectionString("DbConnection")));
    services.AddSwaggerGen();
    services.AddCors();

    return services;
  }

}
