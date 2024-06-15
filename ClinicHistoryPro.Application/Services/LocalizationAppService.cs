using ClinicHistoryPro.Application.Services.Interfaces;
using ClinicHistoryPro.Domain.Models;
using ClinicHistoryPro.Infraestructure.Ports;

namespace ClinicHistoryPro.Application.Services
{
    public class LocalizationAppService: ILocalizationAppService
    {
        private readonly IUnitOfWork unitOfWork;
        public LocalizationAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Country>> GetManyCountry()
        {
            try
            {
                return await unitOfWork.Repository<Country>().GetManyAsync(
                        selector: country => new Country
                        {
                            Id = country.Id,
                            Name = country.Name
                        },
                        orderBy: country => country.OrderBy(o => o.Name)
                    );
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<State>> GetManyState(int country)
        {
            try
            {
                return await unitOfWork.Repository<State>().GetManyAsync(
                        selector: country => new State
                        {
                            Id = country.Id,
                            Name = country.Name
                        },
                        predicate: state => state.CountryId.Equals(country),
                        orderBy: country => country.OrderBy(o => o.Name)
                    );
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<City>> GetManyCity(int state)
        {
            try
            {
                return await unitOfWork.Repository<City>().GetManyAsync(
                        selector: country => new City
                        {
                            Id = country.Id,
                            Name = country.Name
                        },
                        predicate: city => city.StateId.Equals(state),
                        orderBy: country => country.OrderBy(o => o.Name)
                    );
            }
            catch
            {
                throw;
            }
        }
    }
}
