using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoWebAppDAL.Repos
{
    interface IRepoIntIndex<T>
    {
        T GetOne(int? id);
        Task<T> GetOneAsync(int? id);
        int Delete(int id);
        Task<int> DeleteAsync(int id);
    }
}
