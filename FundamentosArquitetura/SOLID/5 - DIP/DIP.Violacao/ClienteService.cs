namespace SOLID.DIP.Violacao
{
    public class ClienteService  //Alto Nível
    {
        public string AdicionarCliente(Cliente cliente)
        {
            if (!cliente.Validar())
                return "Dados inválidos";

            var repo = new ClienteRepository();  //Violação principal. Isso é uma implementação, ou seja, se o clienteRepository mudar, o service muda e isso não é legal.
            repo.AdicionarCliente(cliente);

            EmailServices.Enviar("empresa@empresa.com", cliente.Email.Endereco, "Bem Vindo", "Parabéns está Cadastrado");

            return "Cliente cadastrado com sucesso";
        }
    }
}