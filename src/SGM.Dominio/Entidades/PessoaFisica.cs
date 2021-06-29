using SGM.Dominio.ObjetosDeValor;

namespace SGM.Dominio.Entidades
{
    public class PessoaFisica : Pessoa
    {
        public Cpf Cpf { get; }

        public PessoaFisica(string nome, Cpf cpf) : base(nome)
        {
            Cpf = cpf;
        }
    }
}