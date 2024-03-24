using Core.Application.Interfaces.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DependencyInjection;

public static class ServiceRegister
{
    public static void AddApllicationServices(this IServiceCollection services) =>
         services.AddTransient<IProductCommandService, IProductCommandService>();
}
