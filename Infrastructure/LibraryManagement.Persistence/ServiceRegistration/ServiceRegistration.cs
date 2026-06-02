using LibraryManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using LibraryManagement.Application.DTOs.Book;
using FluentValidation.AspNetCore;
using LibraryManagement.Application.Abstractions.Services;
using LibraryManagement.Persistence.Implementations.Services;
using LibraryManagement.Application.Abstractions.Repositories;
using LibraryManagement.Persistence.Implementations.Repositories;

namespace LibraryManagement.Persistence.ServiceRegistration;
public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>((sp, opt) =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
        });

        

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<GetBookDto>();


        services.AddScoped<IBookService,BookService>();
        services.AddScoped<IBookRepository,BookRepository>();

        return services;
    }
}
