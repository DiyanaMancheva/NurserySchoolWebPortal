namespace NurserySchoolWebPortal.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using NurserySchoolWebPortal.Data.Common.Repositories;
    using NurserySchoolWebPortal.Data.Models;
    using NurserySchoolWebPortal.Web.ViewModels.Fees;

    public class FeesService : IFeesService
    {
        private readonly IDeletableEntityRepository<Fee> feesRepository;

        public FeesService(IDeletableEntityRepository<Fee> feesRepository)
        {
            this.feesRepository = feesRepository;
        }

        public async Task AddAsync(FeeInputModel input)
        {
            var fee = new Fee
            {
                Title = input.Title,
                DateFrom = input.DateFrom,
                DateTo = input.DateTo,
                MoneyAmount = input.MoneyAmount,
                ChildId = int.Parse(input.Child),
            };

            await this.feesRepository.AddAsync(fee);
            await this.feesRepository.SaveChangesAsync();
        }

        public FeeInputModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
