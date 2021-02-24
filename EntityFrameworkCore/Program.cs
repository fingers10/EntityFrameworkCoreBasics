using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("EF Core 5 Demo");

            using var ctx = new EfCoreSqlServerContext();

            // Insert
            await ctx.AddAsync(new CategoryEntity { Name = "Apple" });

            await ctx.SaveChangesAsync();

            // Read
            var categories = await ctx.Categories.TagWith("Category Name Starting With A").Where(x => x.Name.StartsWith("A")).ToListAsync();

            var category = await ctx.Categories.FindAsync(1);

            category.Desc = "Apple Products";

            // Update
            ctx.Categories.Update(category);

            await ctx.SaveChangesAsync();

            // Delete
            ctx.Categories.Remove(category);

            await ctx.SaveChangesAsync();

            Console.ReadKey();
        }
    }
}
