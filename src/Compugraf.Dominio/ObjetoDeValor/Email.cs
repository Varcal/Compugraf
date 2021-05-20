namespace Compugraf.Dominio.ObjetoDeValor
{
    public class Email
    {
        public string Endereco { get; private set; }

        private Email() { }
        public Email(string endereco)
        {
            Endereco = endereco;
        }
    }
}
