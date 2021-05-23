using System.Threading.Tasks;
using Compugraf.Dados.Contextos;
using Compugraf.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore.Storage;

namespace Compugraf.Dados.Repositorios
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly EfContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(EfContext db)
        {
            _db = db;
        }


        public void Dispose()
        {
            _db?.Dispose();
            _transaction?.Dispose();
        }

        public async Task BeginTransaction()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
