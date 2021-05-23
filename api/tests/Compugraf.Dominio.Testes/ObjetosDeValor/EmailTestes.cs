using Compugraf.Dominio.ObjetoDeValor;
using FluentAssertions;
using Xunit;

namespace Compugraf.Dominio.Testes.ObjetosDeValor
{
    public class EmailTestes
    {
        [Fact]
        [Trait("ObjetoDeValor ","Email")]
        public void Quando_criar_um_email_deve_estar_valido()
        {
            var endereco = "cleber.varcal@outlook.com";

            var email = new Email(endereco);

            email.Should().NotBeNull();
            email.Endereco.Should().NotBeNullOrWhiteSpace();
            email.Endereco.Should().Be(endereco);
        }
    }
}
