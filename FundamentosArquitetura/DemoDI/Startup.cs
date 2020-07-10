using System;
using DemoDI.Cases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoDI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Desde que registre tudo, não importa a ordem em que foi registrado.

            #region Lifecycle

            services.AddTransient<IOperacaoTransient, Operacao>();
            services.AddScoped<IOperacaoScoped, Operacao>();
            services.AddSingleton<IOperacaoSingleton, Operacao>();
            services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));
            services.AddTransient<OperacaoService>();

            #endregion

            #region VidaReal
                            
            //Quando receber uma Interface dessa, dá uma instancia desse
            services.AddScoped<IClienteRepository, ClienteRepository>();      //AddScope para registrar uma dependencia
            services.AddScoped<IClienteServices, ClienteServices>();

            #endregion

            #region Generics
            //type of, pq apesar de ser interface genérica,não foi passado nada no <>, sendo assim, por ser uma interface genérica,
            //ele vai entender que esse tipo <> vai ser resolvido durante a execução. Então ele entende, via reflection
            //que esse tipo vai ser especializado em tempo de execução.
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));  //scoped pq se trata de uma aplicação web

            #endregion

            #region MultiplasClasses

            services.AddTransient<ServiceA>();
            services.AddTransient<ServiceB>();
            services.AddTransient<ServiceC>(); 
            //Registro via chave -> cria delegate que recebe uma string e esse delegate, através do ServiceProvider
            //vai buscar através do valor dessa chave o serviço que estou procurando.
            services.AddTransient<Func<string, IService>>(serviceProvider => key =>
            {
               
                switch (key)
                {
                    case "A":
                        return serviceProvider.GetService<ServiceA>();
                    case "B":
                        return serviceProvider.GetService<ServiceB>();
                    case "C":
                        return serviceProvider.GetService<ServiceC>();
                    default:
                        return null;
                }
            });

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
