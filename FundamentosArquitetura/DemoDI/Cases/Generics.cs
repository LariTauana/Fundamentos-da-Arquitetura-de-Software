
namespace DemoDI.Cases
{
    public interface IGenericRepository<T> where T : class //Tipo T é uma classe, então não importa se é um cliente, produto, pedido...
    {
        void Adicionar(T obj);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public void Adicionar(T obj)
        {
            // Faz algo
        }
    }
}