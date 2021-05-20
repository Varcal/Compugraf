using Bogus;
using Bogus.Extensions.Brazil;
using Compugraf.Dominio.Entidade;
using Compugraf.Dominio.ObjetoDeValor;
using FluentAssertions;
using Xunit;

namespace Compugraf.Dominio.Testes.Entidades
{
    public class PessoaTestes
    {
        private readonly Faker _faker;
        public PessoaTestes()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact]
        [Trait("Entidades", "Pessoa")]
        public void Quando_criar_pessoa_deve_estar_valida()
        {
            var nome = new NomeCompleto(_faker.Person.FirstName, _faker.Person.LastName);
            var cpf = new Cpf(_faker.Person.Cpf());
            var endereco = new Endereco(_faker.Address.ZipCode("00000000"), _faker.Address.State(), _faker.Address.City(), _faker.Address.StreetAddress());
            var nacionalidade = _faker.Address.Country();
            var email = new Email(_faker.Person.Email);
            var telefone = new Telefone(_faker.Person.Phone);

            var pessoa = new Pessoa(nome, cpf, nacionalidade, email, telefone, endereco);

            pessoa.Should().NotBeNull();
            pessoa.Nome.Should().NotBeNull();
            pessoa.Cpf.Should().NotBeNull();
            pessoa.Nacionalidade.Should().NotBeNullOrWhiteSpace();
            pessoa.Email.Should().NotBeNull();
            pessoa.Telefone.Should().NotBeNull();
        }
    }
}
