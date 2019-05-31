using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoWebAppDAL.EF;

namespace MemoWebAppDALTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new MemoWebAppDAL.EF.DataInitializer());
            Console.WriteLine("***** Memo Web App DAL Test *****\n");

            using (MemoEntities context = new MemoEntities())
            {
                foreach (var item in context.Memos)
                {
                    Console.WriteLine(item.Title);
                    Console.WriteLine(item.User.UserName);
                }
            }

            Console.ReadLine();
        }
    }
}
