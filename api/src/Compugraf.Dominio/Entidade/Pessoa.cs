using System;
using Compugraf.Dominio.ObjetoDeValor;

namespace Compugraf.Dominio.Entidade
{
    public class Pessoa
    {
        public int Id { get; private set; }
        public NomeCompleto NomeCompleto { get; private set; }
        public Cpf Cpf { get; set; }
        public string Nacionalidade { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }
        public Endereco Endereco { get; private set; }

        private Pessoa() { }

        public Pessoa(NomeCompleto nomeCompleto, Cpf cpf, string nacionalidade, Email email, Telefone telefone, Endereco endereco)
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            Nacionalidade = nacionalidade;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;

            Validar();
        }

        public void Alterar(NomeCompleto nomeCompleto, Cpf cpf, string nacionalidade, Email email, Telefone telefone, Endereco endereco)
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            Nacionalidade = nacionalidade;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;

            Validar();
        }

        private void Validar()
        {
            if (NomeCompleto == null) throw new ApplicationException("Nome é obrigatório");
            if (Cpf == null) throw new ApplicationException("CPF é obrigatório");
            if (string.IsNullOrWhiteSpace(Nacionalidade)) throw new ApplicationException("Nacionalidade é obrigatória");
            if (Email == null) throw new ApplicationException("Email é obrigatório");
            if (Telefone == null) throw new ApplicationException("Telefone é obrigatório");
            if (Endereco == null) throw new ApplicationException("Endereço é obrigatório");
        }
    }
}
