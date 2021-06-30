using System;

namespace SGM.Dominio.Entidades
{
    public abstract class Imposto
    {
        public const string MensagemNomeInvalido = "Nome inválido";
        public const string MensagemSiglaInvalida = "Sigla inválida";
        public const string MensagemContribuinteInvalido = "Contribuinte inválido";
        public const string MensagemAnoDeReferenciaInvalido = "Ano de referência inválido";
        public const string MensagemNomeExtrapolaTamanho = "Nome deve ter no máximo 200 caracteres";
        public const string MensagemSiglaExtrapolaTamanho = "Sigla deve ter no máximo 8 caracteres";

        public string Nome { get; }
        public string Sigla { get; }
        public Pessoa Contribuinte { get; }
        public int AnoDeReferencia { get; }
        public double BaseDeCalculo { get; private set; }
        public double Aliquota { get; private set; }

        protected Imposto(string nome, string sigla, Pessoa contribuinte, int anoDeReferencia)
        {
            ValidarParametros(nome, sigla, contribuinte, anoDeReferencia);

            Nome = nome;
            Sigla = sigla.ToUpper();
            Contribuinte = contribuinte;
            AnoDeReferencia = anoDeReferencia;
        }

        private static void ValidarParametros(string nome, string sigla, Pessoa contribuinte, int anoReferencia)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException(MensagemNomeInvalido);

            if (string.IsNullOrWhiteSpace(sigla)) throw new ArgumentException(MensagemSiglaInvalida);

            if (contribuinte is null) throw new ArgumentException(MensagemContribuinteInvalido);

            if (anoReferencia <= 0) throw new ArgumentException(MensagemAnoDeReferenciaInvalido);

            if (nome.Length > 200) throw new ArgumentException(MensagemNomeExtrapolaTamanho);

            if (sigla.Length > 8) throw new ArgumentException(MensagemSiglaExtrapolaTamanho);
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