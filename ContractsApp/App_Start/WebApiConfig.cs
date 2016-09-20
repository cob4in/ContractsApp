using Autofac;
using Autofac.Integration.WebApi;
using ContractsApp.Controllers.API;
using ContractsApp.Models;
using FluentValidation.WebApi;
using System.Reflection;
using System.Web.Http;

namespace ContractsApp.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ContractRepository>().As<IContractRepository>();
            builder.RegisterType<MinSalaryEntryRepository>().As<IMinSalaryEntryRepository>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            FluentValidationModelValidatorProvider.Configure(config);
            //

            //config.Services.Add(typeof(System.Web.Http.Validation.ModelValidatorProvider),
            //   new WebApiFluentValidationModelValidatorProvider()
            //   {
            //       AddImplicitRequiredValidator = false //we need this otherwise it invalidates all not passed fields(through json). btw do it if you need
            //   });
            //FluentValidation.ValidatorOptions.CascadeMode = FluentValidation.CascadeMode.Continue; //if you need!
        }
    }
}