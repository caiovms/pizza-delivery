using System.Reflection;

namespace pizza.delivery.Infrastructure.DependencyInjection
{
    public interface IModuleCollection : IModuleRegistry
    {
        IModuleCollection AddAllModules(Assembly assembly);
        IModuleCollection AddModule(IModuleRegistry module);
        IModuleCollection RemoveAllModules();
        IModuleCollection RemoveModule(IModuleRegistry module);
        IModuleCollection RemoveModule(string moduleName);
    }
}
