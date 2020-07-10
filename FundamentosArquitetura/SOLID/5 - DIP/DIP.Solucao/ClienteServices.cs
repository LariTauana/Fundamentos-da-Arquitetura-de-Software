using SOLID.DIP.Solucao.Interfaces;

namespace SOLID.DIP.Solucao
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmailServices _emailServices;

        //Exemplo de Injeção de dependencia, é uma forma de aplicar o DIP onde no construtor da classe, é recebido instância 
        //de objetos que vão ser utilizados ao longo do código que será escrito
        public ClienteServices(
            IEmailServices emailServices, //instancia de um objeto que implemente essas interfaces
            IClienteRepository clienteRepository)  //Injetei classe dentro do ctor e ela está trabalhando dessa classe e não 
                                                   //a classe sendo responsável por criar e fazer todo o trabalho, isso é uma inversão de controle atraves da Injeção de Dependencia.
        {
            _emailServices = emailServices;
            _clienteRepository = clienteRepository;   
        }

        public string AdicionarCliente(Cliente cliente)  
        {
            if (!cliente.Validar())
                return "Dados inválidos";

            _clienteRepository.AdicionarCliente(cliente);

            _emailServices.Enviar("empresa@empresa.com", cliente.Email.Endereco, "Bem Vindo", "Parabéns está Cadastrado");

            return "Cliente cadastrado com sucesso";
        }
    }

    public class TesteDip
    {
        public TesteDip()
        {
            var cliService = new ClienteServices(new EmailServices(), new ClienteRepository2());
        }
    }
}