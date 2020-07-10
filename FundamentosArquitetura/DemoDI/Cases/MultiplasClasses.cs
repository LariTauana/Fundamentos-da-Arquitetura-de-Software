namespace DemoDI.Cases
{
    //Violação do ISP e do LSP, uma vez que a ambiguidade está tomando conta do entendimento e isso é um sinal que o design,
    //a própria modelagem, o entendimento sobre a escrita de código utilizada, não está refletindo corretamente no mundo real
    //ou foi feito de uma forma muito simplória ou de forma errada.
    public interface IService
    {
        string Retorno();
    }
    public class ServiceA : IService {
        public string Retorno()
        {
            return "A";
        }
    }
    public class ServiceB : IService {
        public string Retorno()
        {
            return "B";
        }
    }
    public class ServiceC : IService {
        public string Retorno()
        {
            return "C";
        }
    }
}