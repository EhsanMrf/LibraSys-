using System.Reflection;
using Application;
using Framework.TransientService;

namespace API.Injections;

public static class ServiceCollectionExtensions
{
    public static void AddScopedServices(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.Scan(scan => scan
            .FromAssemblies(assemblies) 
            .AddClasses(classes => classes.AssignableTo<IScopedService>()) // ?????? ????????? ?? IScopedService ?? ?????????? ???????
            .AsImplementedInterfaces() 
            .WithScopedLifetime());
    }

}