namespace NurserySchoolWebPortal.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Models;

    public class PostsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Posts.Any())
            {
                return;
            }

            await dbContext.Posts.AddAsync(new Post
            {
                Title = "Knclsje LJdjcm",
                Content = "Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv.",
                NurserySchoolId = 1,
            });

            await dbContext.Posts.AddAsync(new Post
            {
                Title = "Knclsje LJdjcm",
                Content = "Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv.",
                NurserySchoolId = 1,
            });

            await dbContext.Posts.AddAsync(new Post
            {
                Title = "Knclsje LJdjcm",
                Content = "Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv.",
                NurserySchoolId = 1,
            });

            await dbContext.Posts.AddAsync(new Post
            {
                Title = "Knclsje LJdjcm",
                Content = "Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv.",
                NurserySchoolId = 1,
            });

            await dbContext.Posts.AddAsync(new Post
            {
                Title = "Knclsje LJdjcm",
                Content = "Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv.",
                NurserySchoolId = 1,
            });

            await dbContext.Posts.AddAsync(new Post
            {
                Title = "Knclsje LJdjcm",
                Content = "Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv.",
                NurserySchoolId = 2,
            });

            await dbContext.Posts.AddAsync(new Post
            {
                Title = "Knclsje LJdjcm",
                Content = "Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv.",
                NurserySchoolId = 2,
            });

            await dbContext.Posts.AddAsync(new Post
            {
                Title = "Knclsje LJdjcm",
                Content = "Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv.",
                NurserySchoolId = 2,
            });

            await dbContext.Posts.AddAsync(new Post
            {
                Title = "Knclsje LJdjcm",
                Content = "Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv. Llkdn ks lskfnv k lskdnvlsk lksdnv l lsmdnv lksdnvl k pskdmv.",
                NurserySchoolId = 3,
            });
        }
    }
}
