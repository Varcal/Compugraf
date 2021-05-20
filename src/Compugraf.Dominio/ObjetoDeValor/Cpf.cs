using System;
using System.Text.RegularExpressions;

namespace Compugraf.Dominio.ObjetoDeValor
{
    public class Cpf
    {
        public string Numero { get; private set; }

        private Cpf() { }
        public Cpf(string numero)
        {
            Numero = numero
                .Replace(".", "")
                .Replace("-", "");
            
            if(!Regex.IsMatch(Numero, "^[0-9]")) throw new ApplicationException("Cpf inválido");
            if (Numero.Length > 11) throw new ApplicationException("Cpf inválido");
        }
    }
}
