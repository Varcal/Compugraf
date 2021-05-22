using Compugraf.Dominio.Entidade;

namespace Compugraf.Api.Models
{
    public class PessoaDetalhesModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Nacionalidade { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }

        public PessoaDetalhesModel() { }

        public PessoaDetalhesModel(Pessoa pessoa)
        {
            Id = pessoa.Id;
            Nome = pessoa.NomeCompleto.Nome;
            Sobrenome = pessoa.NomeCompleto.Sobrenome;
            Cpf = pessoa.Cpf.ToString();
            Nacionalidade = pessoa.Nacionalidade;
            Email = pessoa.Email.ToString();
            Telefone = pessoa.Telefone.ToString();
            Cep = pessoa.Endereco.Cep;
            Cidade = pessoa.Endereco.Cidade;
            Estado = pessoa.Endereco.Estado;
            Logradouro = pessoa.Endereco.Logradouro;
        }
    }
}
