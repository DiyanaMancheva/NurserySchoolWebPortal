namespace NurserySchoolWebPortal.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(
            IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task AddAsync(PostInputModel input, int schoolId)
        {
            var post = new Post
            {
                Title = input.Title,
                Content = input.Content,
                ImageUrl = input.ImageUrl,
                NurserySchoolId = schoolId,
            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
        }

        public AllPerSchool AllPerSchool(int schoolId, int postsPerPage)
        {
            var postsSlide1 = this.postsRepository.AllAsNoTracking()
                .Where(x => x.NurserySchoolId == schoolId)
                .Select(x => new SinglePostViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn,
                })
                .OrderByDescending(x => x.CreatedOn)
                .Take(postsPerPage)
                .ToList();

            var postsSlide2 = this.postsRepository.AllAsNoTracking()
                .Where(x => x.NurserySchoolId == schoolId)
                .Select(x => new SinglePostViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn,
                })
                .OrderByDescending(x => x.CreatedOn)
                .Skip(postsPerPage).Take(postsPerPage)
                .ToList();

            var postsSlide3 = this.postsRepository.AllAsNoTracking()
                .Where(x => x.NurserySchoolId == schoolId)
                .Select(x => new SinglePostViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn,
                })
                .OrderByDescending(x => x.CreatedOn)
                .Skip(2 * postsPerPage).Take(postsPerPage)
                .ToList();

            var posts = new AllPerSchool
            {
                PostsSlide1 = postsSlide1,
                PostsSlide2 = postsSlide2,
                PostsSlide3 = postsSlide3,
            };

            return posts;
        }

        public SinglePostViewModel GetById(int id)
        {
            var post = this.postsRepository.AllAsNoTracking()
                 .Where(x => x.Id == id)
                 .Select(x => new SinglePostViewModel
                 {
                     Id = x.Id,
                     Title = x.Title,
                     Content = x.Content,
                     ImageUrl = x.ImageUrl,
                     CreatedOn = x.CreatedOn,
                     ModifiedOn = (DateTime)x.ModifiedOn,
                 })
                 .FirstOrDefault();

            return post;
        }
    }
}
