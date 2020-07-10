using System;

namespace OOP
{
    public class Pessoa
    {
        //Aqui o ESTADO está sendo representado pelas duas propriedades da classe. 
        //Pois estão no estado X
        //ex: nome é Ronaldo e data de nascimento XPTO, ou seja ela possui as informações, o estado definido
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public int CalcularIdade() //Comportamento é quando é gerado ou processado uma nova informação através da própria classe
                                   //ex.: nesse metodo, estou transformando uma data de nascimento numa idade, 
                                   //pegando informação no formato data e devolvendo em int. Também é possível que o método não 
                                   //devolva exatamente um valor, ele também pode alterar o estado daquela classe, daquela entidade. Ex.: Pessoa com nome João 
                                   //passa a ter o nome y.
        {
            var dataAtual = DateTime.Now;
            var idade = dataAtual.Year - DataNascimento.Year;

            if (dataAtual < DataNascimento.AddYears(idade)) idade--;

            return idade;
        }
    }
}