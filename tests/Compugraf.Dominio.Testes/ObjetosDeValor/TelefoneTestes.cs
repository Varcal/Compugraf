using Compugraf.Dominio.ObjetoDeValor;
using FluentAssertions;
using Xunit;

namespace Compugraf.Dominio.Testes.ObjetosDeValor
{
    public class TelefoneTestes
    {
        [Fact]
        [Trait("ObjetoDeValor ", "Telefone")]
        public void Quando_criar_um_telefone_deve_estar_valido()
        {
            var numero = "1199999-2222";

            var telefone = new Telefone(numero);

            telefone.Should().NotBeNull();
            telefone.Numero.Should().NotBeNullOrWhiteSpace();
            telefone.Numero.Should().Be(numero);
        }
    }
}
