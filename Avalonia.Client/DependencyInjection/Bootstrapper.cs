using Splat;

namespace Avalonia.Client.DependencyInjection;

public static class Bootstrapper
{
    public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver, string[] args)
    {
        ConfigurationBootstrapper.RegisterConfiguration(services, args);
        LoggingBootstrapper.RegisterLogging(services);
        ServicesBootstrapper.RegisterServices(services, resolver);
        ViewModelsBootstrapper.RegisterViewModels(services, resolver);
    }
}