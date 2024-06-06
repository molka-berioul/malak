using malak.Entities;
using malak.Helpers;
using malak.Models;
using malak.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace malak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfController : ControllerBase
    {
        private readonly Repositories.IProfRepository profRepository;
        public ProfController(Repositories.IProfRepository profRepository)
        {
            this.profRepository = profRepository;
        }
        [HttpPost("add")]
        public IActionResult AddProf([FromBody] ProfRequest models)
        {
            var Prof = new Prof()
            {
                idProf = Guid.NewGuid(),
                NomProf = models.nomProf,
                prenom = models.prenom,
                adresse = models.adresse,
                email = models.email,
                tel = models.tel,
            };
            var idProf = profRepository.AddProf(Prof);
            return CreatedAtAction("AddProf", idProf);
        }
        [HttpGet("all")]
        public IActionResult GetProf()
        {
            var Prof = profRepository.GetProf();
            return Ok(Prof);
        }
        [HttpGet("{idProf}")]
        public IActionResult GetProf(Guid idProf)
        {
            var Prof = profRepository.GetProf(idProf);
            return Ok(Prof);

        }
        [HttpGet("search/{NomProf}")]
        public IActionResult SearchProf(string NomProf)
        {
            var Prof = profRepository.SearchProf(NomProf);
            return Ok(Prof);

        }
        [HttpGet("delete/{idProf}")]
        public IActionResult DeleteProf(string idProf)
        {
            Guid ProfidProf = new Guid();
            var Prof = profRepository.GetProf(ProfidProf);
              if (Prof == null)
              {
                  var error = new APIError()
                  {
                      ErrorDescription = "Prof does not exist",
                      Code = 1300
                  };
                  return BadRequest(error);
              }
            profRepository.DeleteProf(Prof);
            return Ok();
        }

    }
}
