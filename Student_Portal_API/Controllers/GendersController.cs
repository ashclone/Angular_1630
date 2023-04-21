using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Portal_API.service;
using Student_Portal_API.service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal_API.Controllers
{
    [Route("api/Genders")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderRepository _genderRepository;

        public GendersController(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        //[Route("[action]")]
    [HttpGet("GetAllGender")]
    public async Task<IActionResult> GetAllGender()
        {
            
            return Ok(await _genderRepository.GetGenderAsync());

        }
    }
}
