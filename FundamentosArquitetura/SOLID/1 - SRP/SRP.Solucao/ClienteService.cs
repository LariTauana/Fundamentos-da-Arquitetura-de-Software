namespace SOLID.SRP.Solucao
{
    public class ClienteService     
    {
        public string AdicionarCliente(Cliente cliente)
        {
            //válida
            if (!cliente.Validar())       
                return "Dados inválidos";

             //persiste
            var repo = new ClienteRepository();      
            repo.AdicionarCliente(cliente);

            //envia e-mail
            EmailServices.Enviar("empresa@empresa.com", cliente.Email.Endereco, "Bem Vindo", "Parabéns está Cadastrado");

            return "Cliente cadastrado com sucesso";

            //Ao validar, persistir e enviar e-mail, não está acumulando responsabilidades? NÂO, pois a proposta dessa classe
            //é ser um serviço para a classe cliente, como se fosse um workflow(fluxo)
        }
    }
}