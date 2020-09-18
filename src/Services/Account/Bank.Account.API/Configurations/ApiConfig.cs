using AutoMapper;
using Bank.Account.API.Extensions.Context;
using Bank.Account.API.Extensions.Migrations;
using Bank.Account.API.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bank.Account.Application.AutoMapper;
using Microsoft.AspNetCore.Builder;

namespace Bank.Account.API.Configurations
{
    public static class ApiConfig
    {
        public static void WebApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options => { options.Filters.Add<DomainNotificationFilter>(); });
            services.AddControllers(opt =>
            {
                opt.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
            }).AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.RegisterContexts(configuration);
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}