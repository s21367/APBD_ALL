using efDataBase.Models.DTO;
using efDataBase.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace efDataBase.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorsController : Controller
    {

        private readonly IDbService _dbService;

        public DoctorsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            IEnumerable<SomeSortOfDoctor> doctors = await _dbService.GetDoctors();
            return Ok(doctors);
        }

        [HttpDelete]
        [Route("{idDoctor}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int idDoctor)
        {
            try
            {
                string result = await _dbService.DeleteDoctor(idDoctor);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        [Route("{idDoctor}")]
        public async Task<IActionResult> EditDoctor([FromBody] SomeSortOfDoctor doctor, [FromRoute] int idDoctor)
        {
            try
            {
                string result = await _dbService.EditDoctor(doctor, idDoctor);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] SomeSortOfDoctor doctor)
        {
            try
            {
                string result = await _dbService.AddDoctor(doctor);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
