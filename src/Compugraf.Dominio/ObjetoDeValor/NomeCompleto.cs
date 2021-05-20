namespace Compugraf.Dominio.ObjetoDeValor
{
    public class NomeCompleto
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        private NomeCompleto() { }
        public NomeCompleto(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }


        public override string ToString()
        {
            return $"{Nome} {Sobrenome}";
        }
    }
}
