using System.Data.Entity;

namespace ContractsApp.Models
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
         
    }
}