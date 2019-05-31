using MemoWebAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoWebAppDAL.Repos
{
    public class AspNetUsersRepo : BaseRepo<AspNetUsers>, IRepo<AspNetUsers>, IRepoStringIndex<AspNetUsers>, IDisposable
    {
        public int Add(AspNetUsers entity)
        {
            Context.Users.Add(entity);
            return SaveChanges();
        }

        public Task<int> AddAsync(AspNetUsers entity)
        {
            Context.Users.Add(entity);
            return SaveChangesAsync();
        }

        public int AddRange(IList<AspNetUsers> entities)
        {
            Context.Users.AddRange(entities);
            return SaveChanges();
        }
        public Task<int> AddRangeAsync(IList<AspNetUsers> entities)
        {
            Context.Users.AddRange(entities);
            return SaveChangesAsync();
        }
        public int Save(AspNetUsers entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public Task<int> SaveAsync(AspNetUsers entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public int Delete(string id)
        {
            Context.Entry(new AspNetUsers()
            {
                Id = id
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(string id)
        {
            Context.Entry(new AspNetUsers()
            {
                Id = id
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        public int Delete(AspNetUsers entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(AspNetUsers entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        public AspNetUsers GetOne(string id)
            => Context.Users.Find(id);

        public Task<AspNetUsers> GetOneAsync(string id)
            => Context.Users.FindAsync(id);

        public List<AspNetUsers> GetAll()
            => Context.Users.ToList();

        public Task<List<AspNetUsers>> GetAllAsync()
            => Context.Users.ToListAsync();

        public List<AspNetUsers> ExecuteQuery(string sql)
            => Context.Users.SqlQuery(sql).ToList();

        public Task<List<AspNetUsers>> ExecuteQueryAsync(string sql)
            => Context.Users.SqlQuery(sql).ToListAsync();
        public List<AspNetUsers> ExecuteQuery(
            string sql, object[] sqlParametersObjects)
            => Context.Users.SqlQuery(sql, sqlParametersObjects).ToList();
        public Task<List<AspNetUsers>> ExecuteQueryAsync(
            string sql, object[] sqlParametersObjects)
            => Context.Users.SqlQuery(sql).ToListAsync();
    }
}
