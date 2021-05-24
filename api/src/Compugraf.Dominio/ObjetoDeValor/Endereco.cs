using System;
using System.Text.RegularExpressions;

namespace Compugraf.Dominio.ObjetoDeValor
{
    public class Endereco: ValueObject
    {
        public string Cep { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Logradouro { get; private set; }

        private Endereco() { }
        public Endereco(string cep, string estado, string cidade, string logradouro)
        {
            Cep = cep?.Replace("-", "");
            Estado = estado;
            Cidade = cidade;
            Logradouro = logradouro;

            if (Cep?.Length != 8) throw new ApplicationException("CEP inválido.");
            if (!Regex.IsMatch(Cep, "^[0-9]")) throw new ApplicationException("CEP inválido.");
            if(string.IsNullOrWhiteSpace(Estado)) throw new ApplicationException("Estado é obrigatório.");
            if (string.IsNullOrWhiteSpace(Cidade)) throw new ApplicationException("Cidade é obrigatória.");
            if (string.IsNullOrWhiteSpace(Logradouro)) throw new ApplicationException("Logradouro é obrigatório.");
        }
    }
}
