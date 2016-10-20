using Microsoft.Practices.Unity;
using MacroControleFinanceiro.Business.Services;
using MacroControleFinanceiro.Domain.Contracts.Repositories;
using MacroControleFinanceiro.Domain.Contracts.Services;
using MacroControleFinanceiro.Domain.Models;
using MacroControleFinanceiro.Infra.Data;
using MacroControleFinanceiro.Infra.Repositories;

namespace MacroControleFinanceiro.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());

            container.RegisterType<User, User>(new HierarchicalLifetimeManager());
        }
    }
}
