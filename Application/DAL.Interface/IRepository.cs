using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        int Add(TEntity entity);    
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        bool Delete(int id);
    }
}
