namespace Compugraf.Dominio.ObjetoDeValor
{
    public class Telefone
    {
        public string Numero { get; private set; }

        private Telefone() { }
        public Telefone(string numero)
        {
            Numero = numero;
        }
    }
}
