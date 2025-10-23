using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NetArchitecture.Core.ToDoItem;

namespace NetArchitecture.Core;

public static class CoreServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<ICreateToDoItemService, CreateToDoItemService>();

        services.AddValidatorsFromAssemblyContaining<ICoreMarker>(ServiceLifetime.Singleton);

        return services;
    }
}