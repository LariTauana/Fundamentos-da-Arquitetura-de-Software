namespace OOP
{
    // Definição de Classe: estrutura do código que mapeia objeto do mundo real
    //A classe antes de ser instanciada, é uma representação de dados que representa alguma coisa no mundo real,
    //a partir domomento que você da um 'new', cria uma instancia, ela vai ser alocada na memória do computador 
    //e vai ter um ponteiro dizendo que ali tem um objeto do tipo X.
    //e além de especificar propriedades, ela também vai possuir valores. 
    public class Casa
    {
        public int TamanhoM2 { get; set; }
        public int Andares { get; set; }
        public decimal Valor { get; set; }
        public int NumeroVagas { get; set; }
    }

    public class Objeto
    {
        public Objeto()
        {
            // Definição de Objeto: Quando você tem a classe sendo instanciada(ou seja, ela passa a ser representada na memória como um objeto) 
            //e alocada na memória.
  
            var casa = new Casa
            {
                TamanhoM2 = 100,
                Andares = 2,
                Valor = 100000,
                NumeroVagas = 3
            };
        }
    }
}