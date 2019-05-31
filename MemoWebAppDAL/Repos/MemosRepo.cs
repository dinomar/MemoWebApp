using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoWebAppDAL.Models;

namespace MemoWebAppDAL.Repos
{
    public class MemosRepo : BaseRepo<Memo>, IRepo<Memo>, IRepoIntIndex<Memo>, IDisposable
    {
        public int Add(Memo entity)
        {
            Context.Memos.Add(entity);
            return SaveChanges();
        }

        public Task<int> AddAsync(Memo entity)
        {
            Context.Memos.Add(entity);
            return SaveChangesAsync();
        }

        public int AddRange(IList<Memo> entities)
        {
            Context.Memos.AddRange(entities);
            return SaveChanges();
        }
        public Task<int> AddRangeAsync(IList<Memo> entities)
        {
            Context.Memos.AddRange(entities);
            return SaveChangesAsync();
        }
        public int Save(Memo entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public Task<int> SaveAsync(Memo entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public int Delete(int id)
        {
            Context.Entry(new Memo()
            {
                Id = id
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Memo()
            {
                Id = id
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        public int Delete(Memo entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(Memo entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        public Memo GetOne(int? id)
            => Context.Memos.Find(id);

        public Task<Memo> GetOneAsync(int? id)
            => Context.Memos.FindAsync(id);

        public List<Memo> GetAll()
            => Context.Memos.ToList();

        public Task<List<Memo>> GetAllAsync()
            => Context.Memos.ToListAsync();

        // Get All By User Id and Not Deleted.
        public List<Memo> GetAllByUserId(string userId)
        {
            return Context.Memos.Where(m => m.UserId == userId && m.Deleted == false).ToList();
        }

        // Get All By User Id and Not Deleted. Async.
        public Task<List<Memo>> GetAllByUserIdAsync(string userId)
        {
            return Context.Memos.Where(m => m.UserId == userId && m.Deleted == false).ToListAsync();
        }

        public List<Memo> ExecuteQuery(string sql)
            => Context.Memos.SqlQuery(sql).ToList();

        public Task<List<Memo>> ExecuteQueryAsync(string sql)
            => Context.Memos.SqlQuery(sql).ToListAsync();
        public List<Memo> ExecuteQuery(
            string sql, object[] sqlParametersObjects)
            => Context.Memos.SqlQuery(sql, sqlParametersObjects).ToList();
        public Task<List<Memo>> ExecuteQueryAsync(
            string sql, object[] sqlParametersObjects)
            => Context.Memos.SqlQuery(sql).ToListAsync();
    }
}
