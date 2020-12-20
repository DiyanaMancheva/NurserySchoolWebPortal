namespace NurserySchoolWebPortal.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Administration.Principals;

    public class PrincipalsService : IPrincipalsService
    {
        private readonly IDeletableEntityRepository<NurserySchool> schoolsRepository;
        private readonly IDeletableEntityRepository<Principal> principalsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public PrincipalsService(
            IDeletableEntityRepository<NurserySchool> schoolsRepository,
            IDeletableEntityRepository<Principal> principalsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.schoolsRepository = schoolsRepository;
            this.principalsRepository = principalsRepository;
            this.usersRepository = usersRepository;
            this.userManager = userManager;
        }

        public async Task<int> AddAsync(PrincipalInputModel input)
        {
            var user = new ApplicationUser
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserType = input.UserType,
                UserName = input.UserName,
                Email = input.Email,
                Address = input.Address,
                DateOfBirth = input.DateOfBirth,
            };

            var result = await this.userManager.CreateAsync(user, input.Password);
            if (result.Succeeded)
            {
                await this.userManager.AddToRoleAsync(user, "Principal");
            }

            await this.userManager.AddToRoleAsync(user, "Principal");

            var userId = this.usersRepository.AllAsNoTracking()
                .Where(x => x.UserName == input.UserName)
                .Select(x => x.Id)
                .FirstOrDefault();

            var schoolId = this.schoolsRepository.AllAsNoTracking()
                .Where(x => x.Id == Int32.Parse(input.NurserySchool))
                .Select(x => x.Id)
                .FirstOrDefault();

            var principal = new Principal
            {
                UserId = userId,
                NurserySchoolId = schoolId,
            };

            await this.principalsRepository.AddAsync(principal);
            await this.principalsRepository.SaveChangesAsync();
            return principal.Id;
        }
    }
}
