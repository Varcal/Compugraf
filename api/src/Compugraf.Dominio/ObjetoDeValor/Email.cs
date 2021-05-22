using System;

namespace Compugraf.Dominio.ObjetoDeValor
{
    public class Email: ValueObject
    {
        public string Endereco { get; private set; }

        private Email() { }
        public Email(string endereco)
        {
            Endereco = endereco;

            if (string.IsNullOrWhiteSpace(Endereco)) throw new ApplicationException("Email é obrigatório");
        }


        public override string ToString()
        {
            return Endereco;
        }
    }
}
