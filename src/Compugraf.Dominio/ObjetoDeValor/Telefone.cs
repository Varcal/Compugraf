using System;

namespace Compugraf.Dominio.ObjetoDeValor
{
    public class Telefone: ValueObject
    {
        public string Numero { get; private set; }

        private Telefone() { }
        public Telefone(string numero)
        {
            Numero = numero;
            if (string.IsNullOrWhiteSpace(Numero)) throw new ApplicationException("Telefone é obrigatório");

        }

        public override string ToString()
        {
            return Numero;
        }
    }
}
