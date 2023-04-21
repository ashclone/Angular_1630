using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Portal_API.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal_API.Controllers
{
  [Route("api/CountryStateCity")]
  [ApiController]
  public class CountryStateCityController : Controller
  {
    private readonly ICountryStateCityRepository _countryStateCityRepository;

    public CountryStateCityController(ICountryStateCityRepository countryStateCityRepository)
    {
      _countryStateCityRepository = countryStateCityRepository;
    }
    [HttpGet("Country")]
    //[Route("[action]")]
    public async Task<IActionResult> Country()
    {
      return Ok(await _countryStateCityRepository.GetAllCountryAsync());
    }
    //[Route("[action]")]
    [HttpGet("State")]

    public async Task<IActionResult> State()
    {
      return Ok(await _countryStateCityRepository.GetAllStatesAsync());
    }
    //[Route("[action]")]
    [HttpGet("City")]

    public async Task<IActionResult> City()
    {
      return Ok(await _countryStateCityRepository.GetAllCitiesAsync());
    }

    //[Route("[action]/{id:int}")]
    [HttpGet("StateByCountryId/{id:int}")]

    public async Task<IActionResult> StateByCountryId(int id)
    {
      return Ok(await _countryStateCityRepository.GetStateByCountryIdAsync(id));
    }

    //[Route("[action]/{id:int}")]
    [HttpGet("CityByStateId/{id:int}")]

    public async Task<IActionResult> CityByStateId(int id)
    {
      return Ok(await _countryStateCityRepository.GetCityByStateIdAsync(id));
    }


  }
}
