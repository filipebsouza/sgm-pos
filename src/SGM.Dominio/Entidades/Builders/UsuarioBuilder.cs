namespace SGM.Dominio.Entidades.Builders
{
    public class UsuarioBuilder
    {
        private string _nome;
        private string _email;
        private string _senha;
        private PapelDoUsuario[] _papeis;
        private Pessoa _pessoa;

        public static UsuarioBuilder Novo() => new();

        public UsuarioBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public UsuarioBuilder ComEmail(string email)
        {
            _email = email;
            return this;
        }

        public UsuarioBuilder ComSenha(string senha)
        {
            _senha = senha;
            return this;
        }

        public UsuarioBuilder ComPapeis(params PapelDoUsuario[] papeis)
        {
            _papeis = papeis;
            return this;
        }

        public UsuarioBuilder ComPessoa(Pessoa pessoa)
        {
            _pessoa = pessoa;
            return this;
        }

        public Usuario Construir()
        {
            if (_pessoa is null) return new(_nome, _email, _senha, _papeis);

            return new(_nome, _email, _senha, _pessoa, _papeis);
        }
    }
}