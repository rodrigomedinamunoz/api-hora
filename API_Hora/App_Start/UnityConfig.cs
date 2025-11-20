using System.Web.Http;
using Unity;
using Unity.Lifetime;
using API_Hora.Services;

namespace API_Hora
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IHoraService, HoraService>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver =
                new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}
