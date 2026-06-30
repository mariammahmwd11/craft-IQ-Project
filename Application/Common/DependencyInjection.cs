using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // 1. تسجيل FluentValidation
            // السطر ده بيلف في المشروع كله ويسجل أي Validator إنت عملته أوتوماتيك
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // 2. تسجيل MediatR والـ Pipeline Behavior
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                // هنا بنربط المفتش بالـ MediatR عشان يشتغل قبل أي Handler
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            return services;
        }
    }
}
