namespace MemoWebAppDAL.Migrations
{
    using MemoWebAppDAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MemoWebAppDAL.EF.MemoEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MemoWebAppDAL.EF.MemoEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            List<Memo> memos = new List<Memo>
            {
                new Memo { UserId = "5ecfd543-1952-48a7-9f48-4871379bd2f0", Title = "Title 1", Text = "Text 1", Deleted = false},
                new Memo { UserId = "5ecfd543-1952-48a7-9f48-4871379bd2f0", Title = "Title 2", Text = "Text 2", Deleted = false},
                new Memo { UserId = "5ecfd543-1952-48a7-9f48-4871379bd2f0", Title = "Title 3", Text = "Text 3", Deleted = false},
                new Memo { UserId = "5ecfd543-1952-48a7-9f48-4871379bd2f0", Title = "Title 4", Text = "Text 4", Deleted = false},
                new Memo { UserId = "5ecfd543-1952-48a7-9f48-4871379bd2f0", Title = "Title 5", Text = "Text 5", Deleted = false}
            };
            memos.ForEach(x => context.Memos.AddOrUpdate(m => new { m.Title, m.Text }, x));
        }
    }
}
