﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductsProject.Core.Bahaviors;
using System.Reflection;

namespace ProductsProject.Core
{
    public static class CoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // Configration for Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Configration for AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Configration for Fluent validation 
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
