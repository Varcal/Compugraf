using System.Collections.Generic;
using System.Threading.Tasks;
using Compugraf.Dominio.Entidade;
using Compugraf.Dominio.ObjetoDeValor;

namespace Compugraf.Dominio.Repositorios
{
    public interface IPessoaRepositorio
    {
        Task<Pessoa> Inserir(Pessoa pessoa);
        void Alterar(Pessoa pessoa);
        void Excluir(Pessoa pessoa);
        Task<Pessoa> ObterPorId(int id);
        Task<IEnumerable<Pessoa>> SelecionarTodos(int? skip, int? take);
        Task<bool> CpfJaExiste(Cpf cpf);
    }
}
