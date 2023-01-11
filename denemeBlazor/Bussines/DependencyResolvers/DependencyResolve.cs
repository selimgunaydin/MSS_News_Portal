﻿using Autofac.Extensions.DependencyInjection;
using Autofac;
using denemeBlazor.Bussines.DependencyResolvers.Autofac;
using FluentValidation.AspNetCore;
using denemeBlazor.Bussines.Mapper;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data.Context;
using FluentValidation;
using denemeBlazor.Bussines.Dtos;
using denemeBlazor.Bussines.ValidationRules;

namespace denemeBlazor.Bussines.DependencyResolvers
{
    public static class DependencyResolve
    {
        public static void DependencyInjection(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<NewsDbContext>(x =>
x.UseSqlServer(builder.Configuration.GetConnectionString("LocalNewsDbConnection")));

            //Autofac

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBussinesModule());
    });

            //Auto-Mapper

            builder.Services.AddAutoMapper(x=>
            x.AddProfile(new CategoryProfile())
            );

        }



    }
}
