using Compugraf.Dominio.ObjetoDeValor;
using FluentAssertions;
using Xunit;

namespace Compugraf.Dominio.Testes.ObjetosDeValor
{
    public class CpfTestes
    {
        [Fact]
        [Trait("ObjetoDeValor ", "Cpf")]
        public void Quando_criar_CPF_deve_estar_valido()
        {
            var numero = "222.222.222-22";

            var cpf = new Cpf(numero);

            cpf.Should().NotBeNull();
            cpf.Numero.Should().NotBeNullOrWhiteSpace();
            cpf.Numero.Should().Be(numero.Replace(".","").Replace("-",""));
            cpf.Numero.Length.Should().Be(11);
        }
    }
}
