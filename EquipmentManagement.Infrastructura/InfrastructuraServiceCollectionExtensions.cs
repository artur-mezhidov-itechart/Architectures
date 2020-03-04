using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using EquipmentManagement.Infrastructura.Commands;
using EquipmentManagement.Infrastructura.Commands.Contracts;
using EquipmentManagement.Infrastructura.Events;
using EquipmentManagement.Infrastructura.Events.Contracts;
using EquipmentManagement.Infrastructura.Queries;
using EquipmentManagement.Infrastructura.Queries.Contracts;

namespace EquipmentManagement.Infrastructura
{
    public static class InfrastructuraServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructura(this IServiceCollection services)
        {
            return services
                .AddScoped<ICommandDispatcher, CommandDispatcher>()
                .AddScoped<IQueryDispatcher, QueryDispatcher>()
                .AddScoped<IEventDispatcher, EventDispatcher>();
        }

        public static IServiceCollection AddCommandsAndQueries(this IServiceCollection services, Assembly assembly)
        {
            return services
                .AddTransient(assembly, typeof(ICommandHandler<>))
                .AddTransient(assembly, typeof(IQueryHandler<,>))
                .AddTransient(assembly, typeof(IEventHandler<>));
        }

        public static IServiceCollection AddTransient(this IServiceCollection services, Assembly assembly, Type interfaceType)
        {
            IEnumerable<Type> types = GetImplemetationTypes(assembly, interfaceType);

            foreach (Type objectType in types)
            {
                services.AddTransient(objectType.GetInterface(interfaceType.FullName), objectType);
            }

            return services;
        }

        private static IEnumerable<Type> GetImplemetationTypes(Assembly assembly, Type interfaceType)
        {
            return assembly.ExportedTypes
                .Where(type => type.IsClass && !type.IsAbstract && type.GetInterfaces().Any(i => i.Name == interfaceType.Name));
        }
    }
}
