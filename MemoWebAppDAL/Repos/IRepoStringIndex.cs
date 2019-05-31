using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoWebAppDAL.Repos
{
    interface IRepoStringIndex<T>
    {
        T GetOne(string id);
        Task<T> GetOneAsync(string id);
        int Delete(string id);
        Task<int> DeleteAsync(string id);
    }
}
