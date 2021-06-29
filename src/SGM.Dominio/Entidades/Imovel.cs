namespace SGM.Dominio.Entidades
{
    public abstract class Imovel
    {
        public string Logradouro { get; }
        public int Numero { get; }
        public string Bairro { get; }

        protected Imovel(string logradouro, int numero, string bairro)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
        }
    }
}