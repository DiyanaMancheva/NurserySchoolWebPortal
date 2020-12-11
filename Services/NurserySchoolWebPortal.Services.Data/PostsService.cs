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
    }
}
