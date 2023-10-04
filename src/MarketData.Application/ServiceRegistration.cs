using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MarketData.Application
{
    public static class ServiceRegistration
    {
        public static void AppliationRegistertion (this IServiceCollection service)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());
        } 
    }
}
