using efDataBase.Models.DTO;
using efDataBase.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace efDataBase.Controllers
{
    [Route("api/prescription")]
    [ApiController]
    public class PrescriptionController : Controller
    {

        private readonly IDbPrescriptionService _dbService;


        public PrescriptionController(IDbPrescriptionService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("{idPrescription}")]
        public async Task<IActionResult> GetPrescription([FromRoute] int idPrescription)
        {
            SomeSortOfPrescription doctors = await _dbService.GetPrescription(idPrescription);
            return Ok(doctors);
        }



    }
}
