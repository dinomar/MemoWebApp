using System;
using System.Data.Entity;
using System.Linq;
using MemoWebAppDAL.Models;

namespace MemoWebAppDAL.EF
{
    public class MemoEntities : DbContext
    {
        // Your context has been configured to use a 'MemoEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MemoWebAppDAL.EF.MemoEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MemoEntities' 
        // connection string in the application configuration file.
        public MemoEntities()
            : base("name=DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Memo> Memos { get; set; }
        public virtual DbSet<AspNetUsers> Users { get; set; }
    }
}