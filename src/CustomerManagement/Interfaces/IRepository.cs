using System.Collections.Generic;

namespace CustomerManagement.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity Read(int entityId);
        void Update(TEntity entity);
        void Delete(int entityId);
        List<TEntity> GetAll();
        void DeleteAll();
    }
}
