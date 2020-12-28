namespace NurserySchoolWebPortal.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Menu;

    public class MenuService : IMenuService
    {
        private readonly IDeletableEntityRepository<Menu> menuRepository;

        public MenuService(
            IDeletableEntityRepository<Menu> menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public async Task AddAsync(MenuInputModel input, int schoolId)
        {
            var menu = new Menu
            {
                DateFrom = input.DateFrom,
                DateTo = input.DateTo,
                Monday = input.Monday,
                Tuesday = input.Tuesday,
                Wednesday = input.Wednesday,
                Thursday = input.Thursday,
                Friday = input.Friday,
                NurserySchoolId = schoolId,
            };

            await this.menuRepository.AddAsync(menu);
            await this.menuRepository.SaveChangesAsync();
        }

        public MenuViewModel GetById(int id)
        {
            var menu = this.menuRepository.AllAsNoTracking()
                 .Where(x => x.Id == id)
                 .Select(x => new MenuViewModel
                 {
                     Id = x.Id,
                     DateFrom = x.DateFrom.ToShortDateString(),
                     DateTo = x.DateTo.ToShortDateString(),
                     Monday = x.Monday,
                     Tuesday = x.Tuesday,
                     Wednesday = x.Wednesday,
                     Thursday = x.Thursday,
                     Friday = x.Friday,
                     CreatedOn = x.CreatedOn,
                     ModifiedOn = (DateTime)x.ModifiedOn,
                 })
                 .FirstOrDefault();

            return menu;
        }

        public MenuViewModel GetCurrent()
        {
            var menu = this.menuRepository.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new MenuViewModel
                {
                    Id = x.Id,
                    DateFrom = x.DateFrom.ToShortDateString(),
                    DateTo = x.DateTo.ToShortDateString(),
                    Monday = x.Monday,
                    Tuesday = x.Tuesday,
                    Wednesday = x.Wednesday,
                    Thursday = x.Thursday,
                    Friday = x.Friday,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = (DateTime)x.ModifiedOn,
                    DeletedOn = (DateTime)x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                })
                .FirstOrDefault();

            return menu;
        }
    }
}
