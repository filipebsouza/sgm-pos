namespace SGM.Apresentacao.Dtos
{
    public class IptuHttpDto
    {
        public string DescricaoDoImovel { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool PossuiDebitos { get; set; }
    }
}