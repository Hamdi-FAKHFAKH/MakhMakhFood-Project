using Microsoft.EntityFrameworkCore;
using projet2.Data;
using projet2.Repository.IRepository;
using System.Linq.Expressions;

namespace projet2.Repository
{
    public class Repository <T> : IRepository <T> where T : class
    {
        private readonly ApplicationDbContext1 _db ;
        internal DbSet<T> dbSet; 
        public Repository(ApplicationDbContext1 db)
        {
            _db = db;
            dbSet = db.Set<T>();
           
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll( String? includeProp = null)

        {
            IQueryable<T> query = dbSet;
            if(includeProp != null)
            {
                foreach(var prop in includeProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)){
                    query = query.Include(prop);
                }
            }
            return query.ToList();
        }
        // marche bien 
        public T GetById(int id)
        {
            return dbSet.Find(id);
        }


        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, String? includeProp = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProp != null)
            {
                foreach (var prop in includeProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
