using System;

namespace SGM.Dominio.ObjetosDeValor
{
    public struct Cpf : IEquatable<Cpf>
    {
        public const string MensagemCPFTemMenosQue11Caracteres = "CPF inválido com menos de 11 caracteres";
        public const string MensagemCPFComDigitoVerificadorInvalido = "CPF inválido";

        public string Valor { get; }

        public Cpf(string valor)
        {
            Valor = valor;
            ValidarCPF();
        }

        private void ValidarCPF()
        {
            var cpf = Valor;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                throw new ArgumentException(MensagemCPFTemMenosQue11Caracteres);
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();

            if (!cpf.EndsWith(digito))
                throw new ArgumentException(MensagemCPFComDigitoVerificadorInvalido);
        }

        public bool Equals(Cpf other) => Valor == other.Valor;

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            return obj is Cpf cpf && Equals(cpf);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Valor?.GetHashCode()) ?? 0) * 397;
            }
        }

        public static bool operator ==(Cpf a, Cpf b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Cpf a, Cpf b)
        {
            return !(a == b);
        }
    }
}