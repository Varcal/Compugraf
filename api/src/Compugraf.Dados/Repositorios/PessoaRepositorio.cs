using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compugraf.Dados.Contextos;
using Compugraf.Dominio.Entidade;
using Compugraf.Dominio.ObjetoDeValor;
using Compugraf.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Compugraf.Dados.Repositorios
{
    public class PessoaRepositorio: IPessoaRepositorio
    {
        private EfContext _db;

        public PessoaRepositorio(EfContext db)
        {
            _db = db;
        }

        public async Task<Pessoa> Inserir(Pessoa pessoa)
        {
            await _db.Pessoas.AddAsync(pessoa);

            return pessoa;
        }

        public void Alterar(Pessoa pessoa)
        {
            _db.Pessoas.Update(pessoa);
        }

        public void Excluir(Pessoa pessoa)
        {
            _db.Pessoas.Remove(pessoa);
        }

        public async Task<Pessoa> ObterPorId(int id)
        {
            return await _db.Pessoas.FindAsync(id);
        }

        public async Task<IEnumerable<Pessoa>> SelecionarTodos(int? skip, int? take)
        {
            if (skip != null && take != null)
                return await _db.Pessoas.Skip(skip.Value).Take(take.Value).ToListAsync();

            return await _db.Pessoas.ToListAsync();
        }

        public async Task<bool> CpfJaExiste(Cpf cpf)
        {
            return await _db.Pessoas.AnyAsync(x => x.Cpf.Numero == cpf.Numero); ;
        }
    }
}
