using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Meetup.Application.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
