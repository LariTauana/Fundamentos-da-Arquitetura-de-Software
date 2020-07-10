using System;

namespace OOP
{
    #region Caso 1

    public class PessoaFisica : Pessoa   //Herança, aqui, nesse caso é justificável.
    {
        public string Cpf { get; set; }
    }

    public class PessoaFisica2   //Composição
    {
        public Pessoa Pessoa { get; set; }
        public string Cpf { get; set; }
    }

    public class TestesHerancaComposicao
    {
        public TestesHerancaComposicao()
        {
            var pessoaHeranca = new PessoaFisica
            {
                Nome = "Joao",
                DataNascimento = DateTime.Now,
                Cpf = "32165498765"
            };

            var pessoaComposicao = new PessoaFisica2
            {
                Pessoa = new Pessoa
                {
                    Nome = "Joao",
                    DataNascimento = DateTime.Now,
                },
                Cpf = "32165498765"
            };

            var nomeHeranca = pessoaHeranca.Nome;
            var nomeComposicao = pessoaComposicao.Pessoa.Nome;
        }
    }

    #endregion

    #region Caso 2

    public interface IRepositorio<T>     //Repos. genérico
    {
        void Adicionar(T obj);

        void Excluir(T obj);
    }

    public interface IRepositorioPessoa
    {
        void Adicionar(Pessoa obj);
    }

    public class Repositorio<T> : IRepositorio<T>  //Repos. genérico
    {
        public void Adicionar(T obj)
        {

        }

        public void Excluir(T obj)
        {

        }
    }

    public class RepositorioHerancaPessoa : Repositorio<Pessoa>, IRepositorioPessoa   //herdei,ac
    {

    }

    public class RepositorioComposicaoPessoa : IRepositorioPessoa //funciona da foram dele, porém temum agregado(82)
    {
        private readonly IRepositorio<Pessoa> _repositorioPessoa;

        public RepositorioComposicaoPessoa(IRepositorio<Pessoa> repositorioPessoa)  //não herdei, injetei
        {
            _repositorioPessoa = repositorioPessoa;
        }

        public void Adicionar(Pessoa obj)
        {
            _repositorioPessoa.Adicionar(obj);
        }
    }

    public class TestesHerancaComposicao2
    {
        public TestesHerancaComposicao2()
        {
            var repoH = new RepositorioHerancaPessoa();     //repositório que herda, eu apenas instancio
            repoH.Adicionar(new Pessoa());
            repoH.Excluir(new Pessoa());

            var repoC = new RepositorioComposicaoPessoa(new Repositorio<Pessoa>());    //repositorio composição, é necessário passar uma instancia do repos. pessoa 
            repoC.Adicionar(new Pessoa());
        }
    }

    #endregion
}