namespace DesignPatterns.AbstractFactory
{
    // Abstract Factory
    public abstract class AutoSocorroFactory        //Fábrica de fábricas
    {
        public abstract Guincho CriarGuincho();
        public abstract Veiculo CriarVeiculo(string modelo, Porte porte);
    }
}