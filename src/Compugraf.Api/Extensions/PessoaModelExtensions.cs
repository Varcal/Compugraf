using Compugraf.Api.Models;
using Compugraf.Dominio.Entidade;
using Compugraf.Dominio.ObjetoDeValor;

namespace Compugraf.Api.Extensions
{
    public static class PessoaModelExtensions
    {
        public static Pessoa ParaPessoa(this PessoaModel model)
        {
            var nomeCompleto = new NomeCompleto(model.Nome, model.Sobrenome);
            var cpf = new Cpf(model.Cpf);
            var email = new Email(model.Email);
            var telefone = new Telefone(model.Telefone);
            var endereco = new Endereco(model.Cep, model.Estado, model.Cidade, model.Logradouro);

            return new Pessoa(nomeCompleto, cpf, model.Nacionalidade, email, telefone, endereco);
        }
    }
}
