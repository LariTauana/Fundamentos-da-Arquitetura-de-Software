namespace OOP
{
    public interface IRepositorio
    {
        void Adicionar();
    }

    public class Repositorio : IRepositorio
    {
        //public Repositorio(int a)
        //{
            
        //}

        public void Adicionar()
        {
            // Adiciona item
        }
    }

    public class RepositorioFake : IRepositorio  
    {
        public void Adicionar()
        {
            // Adiciona item
        }
    }

    //principio do acoplamento
    public class UsoImplementacao        //case
    {
        public void Processo()
        {
            var repositorio = new Repositorio();  //implementação
            repositorio.Adicionar();
        }
    }

    public class UsoAbstracao     //Abstração do uso da classe 
    {
        private readonly IRepositorio _repositorio;

        public UsoAbstracao(IRepositorio repositorio)   //Ao invés de criar instancia, eu injeto uma instancia desse objeto 
                                                        //no construtor da classe que eu estou utilizando
        {
            _repositorio = repositorio;
        }

        public void Processo()
        {
            _repositorio.Adicionar();
        }
    }

    public class TesteInterfaceImplementacao
    {
        public TesteInterfaceImplementacao()
        {
            var repoImp = new UsoImplementacao();
            repoImp.Processo();

            var repoAbs = new UsoAbstracao(new Repositorio());
            repoAbs.Processo();

            var repoAbsFake = new UsoAbstracao(new RepositorioFake());
            repoAbsFake.Processo();
        }
    }
}
