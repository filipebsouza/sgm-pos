namespace SGM.Apresentacao.Dtos
{
    public class IptuHttpDto
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public bool PossuiDebitos { get; set; }
        public double SaldoDevedor { get; set; }
        public int AnoDeReferencia { get; set; }
    }
}