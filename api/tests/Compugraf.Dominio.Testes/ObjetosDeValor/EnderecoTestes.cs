using System;
using Bogus;
using Compugraf.Dominio.ObjetoDeValor;
using FluentAssertions;
using Xunit;

namespace Compugraf.Dominio.Testes.ObjetosDeValor
{
    public class EnderecoTestes
    {
        private readonly Faker _faker;
        public EnderecoTestes()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact]
        [Trait("ObjetoDeValor", "Endereco")]
        public void Quando_criar_um_endereco_deve_estar_valido()
        {
            var cep = _faker.Address.ZipCode("00000-000");
            var estado = _faker.Address.State();
            var cidade = _faker.Address.City();
            var logradouro = _faker.Address.StreetAddress();


            var endereco = new Endereco(cep, estado, cidade, logradouro);


            endereco.Should().NotBeNull();
            endereco.Cep.Should().NotBeNullOrWhiteSpace();
            endereco.Estado.Should().NotBeNullOrWhiteSpace();
            endereco.Cidade.Should().NotBeNullOrWhiteSpace();
            endereco.Logradouro.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        [Trait("ObjetoDeValor", "Endereco")]
        public void Quando_criar_um_endereco_CEP_deve_estar_valido()
        {
            var cep = _faker.Address.ZipCode("00000-000");
            var estado = _faker.Address.State();
            var cidade = _faker.Address.City();
            var logradouro = _faker.Address.StreetAddress();


            var endereco = new Endereco(cep, estado, cidade, logradouro);


            endereco.Cep.Length.Should().Be(8);
        }

        [Theory]
        [InlineData("000000-0000")]
        [InlineData("0000")]
        [InlineData(null)]
        [InlineData("")]
        [Trait("ObjetoDeValor", "Endereco")]
        public void Quando_criar_um_endereco_CEP_deve_conter_8_caracteres(string cep)
        {
            var estado = _faker.Address.State();
            var cidade = _faker.Address.City();
            var logradouro = _faker.Address.StreetAddress();


            Action act = () => new Endereco(cep, estado, cidade, logradouro);

            act.Should().Throw<ApplicationException>()
                .WithMessage("CEP inválido.");
        }

        [Theory]
        [InlineData("00000.000")]
        [InlineData("EEEE")]
        [Trait("ObjetoDeValor", "Endereco")]
        public void Quando_criar_um_endereco_CEP_deve_conter_apenas_numeros(string cep)
        {
            var estado = _faker.Address.State();
            var cidade = _faker.Address.City();
            var logradouro = _faker.Address.StreetAddress();

            Action act = () => new Endereco(cep, estado, cidade, logradouro);

            act.Should().Throw<ApplicationException>()
                .WithMessage("CEP inválido.");
        }


        [Fact]
        [Trait("ObjetoDeValor", "Endereco")]
        public void Quando_criar_um_endereco_estado_deve_ser_obrigatorio()
        {
            var cep = _faker.Address.ZipCode("00000-000");
            var estado = string.Empty;
            var cidade = _faker.Address.City();
            var logradouro = _faker.Address.StreetAddress();


            Action act = () => new Endereco(cep, estado, cidade, logradouro);

            act.Should().Throw<ApplicationException>()
                .WithMessage("Estado é obrigatório.");
        }

        [Fact]
        [Trait("ObjetoDeValor", "Endereco")]
        public void Quando_criar_um_endereco_cidade_deve_ser_obrigatorio()
        {
            var cep = _faker.Address.ZipCode("00000-000");
            var estado = _faker.Address.State();
            var cidade = string.Empty;
            var logradouro = _faker.Address.StreetAddress();


            Action act = () => new Endereco(cep, estado, cidade, logradouro);

            act.Should().Throw<ApplicationException>()
                .WithMessage("Cidade é obrigatória.");
        }

        [Fact]
        [Trait("ObjetoDeValor", "Endereco")]
        public void Quando_criar_um_endereco_logradouro_deve_ser_obrigatorio()
        {
            var cep = _faker.Address.ZipCode("00000-000");
            var estado = _faker.Address.State();
            var cidade = _faker.Address.City();
            var logradouro = string.Empty;


            Action act = () => new Endereco(cep, estado, cidade, logradouro);

            act.Should().Throw<ApplicationException>()
                .WithMessage("Logradouro é obrigatório.");
        }
    }
}
