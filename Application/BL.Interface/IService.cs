using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entity;

namespace BL.Interface
{
    public interface IService<TEntity> where TEntity : IEntity
    {
        int Add(TEntity entity);
        bool Delete(int id);
        void Update(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

    }
}
