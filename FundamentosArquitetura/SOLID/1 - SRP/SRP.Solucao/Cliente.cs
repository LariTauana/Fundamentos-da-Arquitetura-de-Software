using System;

namespace SOLID.SRP.Solucao
{
    public class Cliente     //se a classe, ela mesmo se define, nada melhor do que ela mesmo se validar
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Cpf Cpf { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool Validar()
        {
            return Email.Validar() && Cpf.Validar();
        }
    }
}