using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoWebAppDAL.Models;

namespace MemoWebAppDAL.EF
{
    public class DataInitializer : DropCreateDatabaseAlways<MemoEntities>
    {
        protected override void Seed(MemoEntities context)
        {
            List<Memo> memos = new List<Memo>
            {
                new Memo { UserId = "5ecfd543-1952-48a7-9f48-4871379bd2f0", Title = "Title 1", Text = "Text 1", Deleted = false},
                new Memo { UserId = "5ecfd543-1952-48a7-9f48-4871379bd2f0", Title = "Title 2", Text = "Text 2", Deleted = false},
                new Memo { UserId = "5ecfd543-1952-48a7-9f48-4871379bd2f0", Title = "Title 3", Text = "Text 3", Deleted = false},
                new Memo { UserId = "5ecfd543-1952-48a7-9f48-4871379bd2f0", Title = "Title 4", Text = "Text 4", Deleted = false},
                new Memo { UserId = "5ecfd543-1952-48a7-9f48-4871379bd2f0", Title = "Title 5", Text = "Text 5", Deleted = false}
            };
            memos.ForEach(x => context.Memos.Add(x));

            context.SaveChanges();
            // Database.SetInitializer(new DataInitializer());
        }
    }
}
