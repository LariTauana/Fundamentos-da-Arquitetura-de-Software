namespace SOLID.LSP.Solucao
{
    //Solução pra substituição de Liskov: não foi deixar de usar herança e sim aplicação do conceito de abstração 
    //utilizando ideias de OCP, onde fecho paralelogramo pra modificação e abro pra extensão.
    public abstract class Paralelogramo
    {
        protected Paralelogramo(int altura, int largura)
        {
            Altura = altura;
            Largura = largura;
        }

        public double Altura { get; private set; }
        public double Largura { get; private set ; }
        public double Area { get { return Altura * Largura; } } 
    }
}