using System;
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
            pessoa.NomeCompleto.Should().NotBeNull();
            pessoa.Cpf.Should().NotBeNull();
            pessoa.Nacionalidade.Should().NotBeNullOrWhiteSpace();
            pessoa.Email.Should().NotBeNull();
            pessoa.Telefone.Should().NotBeNull();
        }


        [Fact]
        [Trait("Entidades", "Pessoa")]
        public void Quando_criar_pessoa_nome_deve_ser_obrigatorio()
        {
            var cpf = new Cpf(_faker.Person.Cpf());
            var endereco = new Endereco(_faker.Address.ZipCode("00000000"), _faker.Address.State(), _faker.Address.City(), _faker.Address.StreetAddress());
            var nacionalidade = _faker.Address.Country();
            var email = new Email(_faker.Person.Email);
            var telefone = new Telefone(_faker.Person.Phone);


            Action act = () => new Pessoa(null, cpf, nacionalidade, email, telefone, endereco);

            act.Should().Throw<ApplicationException>()
                .WithMessage("Nome é obrigatório");
        }


        [Fact]
        [Trait("Entidades", "Pessoa")]
        public void Quando_criar_pessoa_CPF_deve_ser_obrigatorio()
        {
            var nome = new NomeCompleto(_faker.Person.FirstName, _faker.Person.LastName);
            var endereco = new Endereco(_faker.Address.ZipCode("00000000"), _faker.Address.State(), _faker.Address.City(), _faker.Address.StreetAddress());
            var nacionalidade = _faker.Address.Country();
            var email = new Email(_faker.Person.Email);
            var telefone = new Telefone(_faker.Person.Phone);


            Action act = () => new Pessoa(nome, null, nacionalidade, email, telefone, endereco);

            act.Should().Throw<ApplicationException>()
                .WithMessage("CPF é obrigatório");
        }

        [Fact]
        [Trait("Entidades", "Pessoa")]
        public void Quando_criar_pessoa_endereco_deve_ser_obrigatorio()
        {
            var nome = new NomeCompleto(_faker.Person.FirstName, _faker.Person.LastName);
            var cpf = new Cpf(_faker.Person.Cpf());
            var nacionalidade = _faker.Address.Country();
            var email = new Email(_faker.Person.Email);
            var telefone = new Telefone(_faker.Person.Phone);


            Action act = () => new Pessoa(nome, cpf, nacionalidade, email, telefone, null);


            act.Should().Throw<ApplicationException>()
                .WithMessage("Endereço é obrigatório");
        }

        [Theory]
        [Trait("Entidades", "Pessoa")]
        [InlineData("")]
        [InlineData(null)]
        public void Quando_criar_pessoa_nacionalidade_deve_ser_obrigatorio(string nacionalidade)
        {
            var nome = new NomeCompleto(_faker.Person.FirstName, _faker.Person.LastName);
            var cpf = new Cpf(_faker.Person.Cpf());
            var endereco = new Endereco(_faker.Address.ZipCode("00000000"), _faker.Address.State(), _faker.Address.City(), _faker.Address.StreetAddress());
            var email = new Email(_faker.Person.Email);
            var telefone = new Telefone(_faker.Person.Phone);


            Action act = () => new Pessoa(nome, cpf, nacionalidade, email, telefone, endereco);

            act.Should().Throw<ApplicationException>()
                .WithMessage("Nacionalidade é obrigatória");
        }

        [Fact]
        [Trait("Entidades", "Pessoa")]
        public void Quando_criar_pessoa_email_deve_ser_obrigatorio()
        {
            var nome = new NomeCompleto(_faker.Person.FirstName, _faker.Person.LastName);
            var cpf = new Cpf(_faker.Person.Cpf());
            var endereco = new Endereco(_faker.Address.ZipCode("00000000"), _faker.Address.State(), _faker.Address.City(), _faker.Address.StreetAddress());
            var nacionalidade = _faker.Address.Country();
            var telefone = new Telefone(_faker.Person.Phone);


            Action act = () => new Pessoa(nome, cpf, nacionalidade, null, telefone, endereco);

            act.Should().Throw<ApplicationException>()
                .WithMessage("Email é obrigatório");
        }


        [Fact]
        [Trait("Entidades", "Pessoa")]
        public void Quando_criar_pessoa_telefone_deve_ser_obrigatorio()
        {
            var nome = new NomeCompleto(_faker.Person.FirstName, _faker.Person.LastName);
            var cpf = new Cpf(_faker.Person.Cpf());
            var endereco = new Endereco(_faker.Address.ZipCode("00000000"), _faker.Address.State(), _faker.Address.City(), _faker.Address.StreetAddress());
            var nacionalidade = _faker.Address.Country();
            var email = new Email(_faker.Person.Email);
            var telefone = new Telefone(_faker.Person.Phone);


            Action act = () => new Pessoa(nome, cpf, nacionalidade, email, null, endereco);

            act.Should().Throw<ApplicationException>()
                .WithMessage("Telefone é obrigatório");
        }
    }
}
