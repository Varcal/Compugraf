using System;

namespace Compugraf.Dominio.ObjetoDeValor
{
    public class NomeCompleto: ValueObject
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        private NomeCompleto() { }
        public NomeCompleto(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;

            if (string.IsNullOrWhiteSpace(Nome)) throw new ApplicationException("Nome é obrigatorio");
            if (string.IsNullOrWhiteSpace(Sobrenome)) throw new ApplicationException("Sobrenome é obrigatorio");
        }


        public override string ToString()
        {
            return $"{Nome} {Sobrenome}";
        }
    }
}
