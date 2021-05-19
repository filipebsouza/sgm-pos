using System.ComponentModel;

namespace SGM.Dominio.Entidades
{
    public enum PapelDoUsuario
    {
        [Description("gestor")]
        Gestor = 1,
        [Description("servidor")]
        Servidor = 2,
        [Description("contribuinte")]
        Contribuinte = 3
    }
}