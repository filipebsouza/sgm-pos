namespace SGM.Dominio.Entidades
{
    public class Iptu : Imposto
    {
        public Iptu(string nome, string sigla, Pessoa contribuinte, int anoReferencia
        // , Imovel imovel
        ) : base(nome, sigla, contribuinte, anoReferencia)
        {
        }


    }
}