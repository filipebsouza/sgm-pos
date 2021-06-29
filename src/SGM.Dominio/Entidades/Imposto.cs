namespace SGM.Dominio.Entidades
{
    public abstract class Imposto
    {
        public string Nome { get; }
        public string Sigla { get; }
        public Pessoa Contribuinte { get; }
        public int AnoReferencia { get; }
        public double BaseDeCalculo { get; private set; }
        public double Aliquota { get; private set; }

        protected Imposto(string nome, string sigla, Pessoa contribuinte, int anoReferencia)
        {
            Nome = nome;
            Sigla = sigla;
            Contribuinte = contribuinte;
            AnoReferencia = anoReferencia;
        }

        public void AtribuirBaseDeCalculo(double baseDeCalculo)
        {
            BaseDeCalculo = baseDeCalculo;
        }

        public void AtribuirAliquota(double aliquota)
        {
            Aliquota = aliquota;
        }

        public double Calcular()
        {
            return BaseDeCalculo * Aliquota;
        }
    }
}