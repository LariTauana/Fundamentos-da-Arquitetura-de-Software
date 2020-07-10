namespace OOP
{
    public abstract class Eletrodomestico
    {
        private readonly string _nome;
        private readonly int _voltagem;
        protected Eletrodomestico(string nome, int voltagem)
        {
            _nome = nome;
            _voltagem = voltagem;
        }

        //Quando você tem um método abstrato, você não é obrigado a implementar o comportamento dele.
        //A classe que for implementa-lo, ela mesma vai definir o comportamento dele. Gerando assim a especialização.

        public abstract void Ligar();
        public abstract void Desligar();

        public virtual void Testar() //virtual para poder sobreescrever no polimorfismo.
        {
            // teste do equipamento
        }
    }
}