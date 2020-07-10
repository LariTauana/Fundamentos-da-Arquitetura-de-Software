namespace SOLID.OCP.Solucao_Extension_Methods
{
    //Extension Methods quando você cria um método, por exemplo, aqui dentro da classe "debitoConta corrente, 
    //mas ele se comporta como se fosse método da classe "DebitoConta"
    //O que é necessário para criar um Extension Method? Primeiro, a classe e o método precisam ser static, pois assim, na hora de compilar
    //o compilador vai entender que a classenão tem um estado,ela está sendo representada dessa forma, mas ela esta trabalhando dentro da "DebitoConta"
    public static class DebitoContaCorrente
    {
                                                  //quando tem o this como primeiro parametro, diz que essemétodo está sendo interpretado dentro da classe que vem em seguida(2º par)
        public static string DebitarContaCorrente(this DebitoConta debitoConta)   //faz extensão,sem herança
        {
            // Logica de negócio para debito em conta corrente.
            return debitoConta.FormatarTransacao();
        }
    }
}