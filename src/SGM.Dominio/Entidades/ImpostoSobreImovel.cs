using System;

namespace SGM.Dominio.Entidades
{
    public class ImpostoSobreImovel : Imposto
    {
        public const string MensagemImovelInvalido = "Imóvel inválido";
        public const string MensagemImovelNaoAvaliado = "Imóvel ainda não foi avaliado";

        public Imovel Imovel { get; }

        public override double BaseDeCalculo => Imovel.ValorVenal;
        public override double Aliquota { get; }

        protected ImpostoSobreImovel(string nome, string sigla, Pessoa contribuinte, int anoDeReferencia, Imovel imovel)
            : base(nome, sigla, contribuinte, anoDeReferencia)
        {
            ValidarParametros(imovel);

            Imovel = imovel;
        }

        private static void ValidarParametros(Imovel imovel)
        {
            if (imovel is null) throw new ArgumentException(MensagemImovelInvalido);

            if (!imovel.PossuiAvaliacao) throw new ArgumentException(MensagemImovelNaoAvaliado);
        }
    }
}