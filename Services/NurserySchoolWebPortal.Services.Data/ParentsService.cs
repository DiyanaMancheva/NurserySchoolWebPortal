namespace NurserySchoolWebPortal.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Parents;

    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    public class ParentsService : IParentsService
    {
        private readonly IDeletableEntityRepository<Parent> parentsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Post> postRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;

        public ParentsService(
            IDeletableEntityRepository<Parent> parentsRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Post> postRepository,
            IDeletableEntityRepository<Image> imageRepository
            )
        {
            this.parentsRepository = parentsRepository;
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.imageRepository = imageRepository;
        }

        public ParentPageViewModel GetAll()
        {
            var currentUser = this.userRepository.AllAsNoTracking().Include(x => x.Parent.Children).FirstOrDefault(x => x.UserName == "Diyana");

            var postsSlide1 = this.postRepository.AllAsNoTracking()
                .Where(x => x.NurserySchoolId == currentUser.Parent.Children.FirstOrDefault().NurseryGroup.NurserySchoolId)
                .Select(x => new PostViewModel
                {
                    Title = x.Title,
                    Content = x.Content,
                    Created = x.CreatedOn,
                })
                .OrderByDescending(x => x.Created)
                .Take(4)
                .ToList();

                var postsSlide2 = this.postRepository.AllAsNoTracking()
                .Where(x => x.NurserySchoolId == currentUser.Parent.Children.FirstOrDefault().NurseryGroup.NurserySchoolId)
                .Select(x => new PostViewModel
                {
                    Title = x.Title,
                    Content = x.Content,
                    Created = x.CreatedOn,
                })
                .OrderByDescending(x => x.Created)
                .Skip(4).Take(4)
                .ToList();

                var postsSlide3 = this.postRepository.AllAsNoTracking()
                .Where(x => x.NurserySchoolId == currentUser.Parent.Children.FirstOrDefault().NurseryGroup.NurserySchoolId)
                .Select(x => new PostViewModel
                {
                    Title = x.Title,
                    Content = x.Content,
                    Created = x.CreatedOn,
                })
                .OrderByDescending(x => x.Created)
                .Skip(8).Take(4)
                .ToList();

            var images = this.imageRepository.AllAsNoTracking()
                .Where(x => x.NurseryGroupId == currentUser.Parent.Children.FirstOrDefault().NurseryGroupId)
                .Select(x => new ImageViewModel
                {
                    Url = x.Url,
                    Extension = x.Extension,
                }).ToList();

            var viewModel = new ParentPageViewModel
            {
                PostsSlide1 = postsSlide1,
                PostsSlide2 = postsSlide2,
                PostsSlide3 = postsSlide3,
                Images = images,
            };

            return viewModel;
        }
    }
}
