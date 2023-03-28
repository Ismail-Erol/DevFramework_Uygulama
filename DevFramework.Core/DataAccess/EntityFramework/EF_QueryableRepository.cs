using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EF_QueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private DbSet<T> _entites;
        public EF_QueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => Entities; 
        protected virtual DbSet<T> Entities 
        { 
            get 
            {  
                if (_entites == null)
                {
                    _entites = _context.Set<T>();
                }
                return _entites; 
            } 
        }
    }
}
