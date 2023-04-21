using Student_Portal_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal_API.service
{
  public interface ICountryStateCityRepository
    {
        Task<List<Country>> GetAllCountryAsync();
        Task<List<State>> GetAllStatesAsync();
        Task<List<City>> GetAllCitiesAsync();
        Task<List<State>> GetStateByCountryIdAsync(int countryId);
        Task<List<City>> GetCityByStateIdAsync(int stateId);
    }
}
