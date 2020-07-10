using System;
using DemoDI.Cases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DemoDI.Controllers
{
    public class ServiceLocatorController : Controller
    {
        //Nesse caso, serviceLocator está, por conta própria obtendo a instância de um objeto de dentro de um container
                        //Interface do prórpio .Net, e é a interface que expõe os métodos de consulta e etc ao container nativo de Inj. de dep.
        private readonly IServiceProvider _serviceProvider;
        //IServiceProvider não é a interface de um padrão Service Locator, ela é a interface de serviço do meu container 
        //de inj de dep, o padrão ServiceLocator se dá quando eu faço o uso dessa interface para eu, por conta própria obter acesso 
        //aos serviços,os objetos resolvidos fazendo o uso da chamada "GetRequiredService", por exemplo.
        //E o padrão Service Locator não é recomendável, porque irá dificultar bastante os testes

        public ServiceLocatorController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Index()
        {
            // Required porque Retorna null se não estiver registrado
            _serviceProvider.GetRequiredService<IClienteServices>().AdicionarCliente(new Cliente());  
            //Aqui digo que quero receber uma instancia de uma classe que implementa essa interface
        }
    }
}

//Qual a vantagem de fazer o que esse código acima esta fazendo? Não muitas. 
//O IServiceProvider expõe todas as instancias dos objetos registrados no container
