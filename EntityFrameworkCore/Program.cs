using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //https://docs.microsoft.com/en-us/ef/core/saving/transactions

            var connectionString = new ConnectionString("Server=.\\;Database=EFCoreDB;Trusted_Connection=true;");

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddTransient<EfCoreSqlServerContext>()
                .AddSingleton(connectionString)
                .BuildServiceProvider();

            //do the actual work here
            var ctx = serviceProvider.GetService<EfCoreSqlServerContext>();

            Console.WriteLine("EF Core 5 Demo");

            using (ctx)
            {
                // Insert
                await ctx.AddAsync(new CategoryEntity { Name = "Apple" });

                await ctx.SaveChangesAsync();

                // Read
                var categories = await ctx.Categories.TagWith("Category Name Starting With A").Where(x => x.Name.StartsWith("A")).ToListAsync();

                var category = await ctx.Categories.FindAsync(categories.First().Id);

                category.Desc = "Apple Products";

                // Update
                ctx.Categories.Update(category);

                await ctx.SaveChangesAsync();

                // Delete
                ctx.Categories.Remove(category);

                await ctx.SaveChangesAsync();

                var categoryName = "Apple";
                var spCategories = await ctx.AnotherCategories.FromSqlInterpolated($"EXEC [dbo].[GetCategories] @Name={categoryName}").ToListAsync();

                // EF Functions
                // https://docs.microsoft.com/en-us/ef/core/providers/sql-server/functions

                //var functionCategories = await ctx.Categories.Where(p => EF.Functions.Like(p.Name, "A%")).ToListAsync();
                var functionCategories = await ctx.Categories.Where(p => p.Name.FirstOrDefault() == 'A').ToListAsync();
            }

            Console.ReadKey();
        }
    }
}
