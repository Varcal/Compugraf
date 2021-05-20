using Compugraf.Dominio.ObjetoDeValor;

namespace Compugraf.Dominio.Entidade
{
    public class Pessoa
    {
        public int Id { get; private set; }
        public NomeCompleto Nome { get; private set; }
        public Cpf Cpf { get; set; }
        public string Nacionalidade { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }
        public Endereco Endereco { get; private set; }

        private Pessoa() { }

        public Pessoa(NomeCompleto nomeCompleto, Cpf cpf, string nacionalidade, Email email, Telefone telefone, Endereco endereco)
        {
            Nome = nomeCompleto;
            Cpf = cpf;
            Nacionalidade = nacionalidade;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
