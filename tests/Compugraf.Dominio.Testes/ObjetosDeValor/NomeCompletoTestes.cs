using Bogus;
using Compugraf.Dominio.ObjetoDeValor;
using FluentAssertions;
using Xunit;

namespace Compugraf.Dominio.Testes.ObjetosDeValor
{
    public class NomeCompletoTestes
    {
        private Faker _faker;

        public NomeCompletoTestes()
        {
            _faker = new Faker("pt_BR");
        }


        [Fact]
        [Trait("ObjetoDeValor ", "Nome")]
        public void Quando_criar_NomeCompleto_deve_estar_valido()
        {
            var nome = _faker.Person.FirstName;
            var sobrenome = _faker.Person.LastName;

            var nomeCompleto = new NomeCompleto(nome, sobrenome);

            nomeCompleto.Should().NotBeNull();
            nomeCompleto.Nome.Should().NotBeNullOrWhiteSpace();
            nomeCompleto.Sobrenome.Should().NotBeNullOrWhiteSpace();
        }
    }
}
