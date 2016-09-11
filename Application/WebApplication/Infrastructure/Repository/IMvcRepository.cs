using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Infrastructure.Repository
{
    public interface IMvcRepository<TEntity> : IDisposable
    {
        int Create(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        bool Delete(int id);
    }
}