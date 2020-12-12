namespace NurserySchoolWebPortal.Services.Data
{
    using System.Linq;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
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
                 })
                 .FirstOrDefault();

            return post;
        }

        public PostsPerSchool AllPerSchool(int schoolId)
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
                .Take(4)
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
                .Skip(4).Take(4)
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
                .Skip(8).Take(4)
                .ToList();

            var posts = new PostsPerSchool
            {
                PostsSlide1 = postsSlide1,
                PostsSlide2 = postsSlide2,
                PostsSlide3 = postsSlide3,
            };

            return posts;
        }
    }
}
