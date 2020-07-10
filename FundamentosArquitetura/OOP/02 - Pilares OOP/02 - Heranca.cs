using System;

namespace OOP
{            //Funcionario é uma pessoa -> macete para verificar se a herança faz sentido.
    public class Funcionario : Pessoa  //Quando voce herda de uma classe, você está absrovendo o estado e os comportamentos 
                                       //daquela classe.
    {
        public DateTime DataAdmissao { get; set; }
        public string Registro { get; set; }
    }

    public class Processo
    {
        public void Execucao()
        {
            var funcionario = new Funcionario()
            {
                Nome = "João da Silva",
                DataNascimento = Convert.ToDateTime("1990/01/01"),
                DataAdmissao = DateTime.Now,
                Registro = "0123456",
            };

            funcionario.CalcularIdade();
        }
    }
}