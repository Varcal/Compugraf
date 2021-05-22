using System;
using System.Threading.Tasks;

namespace Compugraf.Dominio.Repositorios
{
    public interface IUnitOfWork: IDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
        Task SaveChanges();
    }
}
