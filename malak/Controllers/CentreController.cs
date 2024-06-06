using malak.Entities;
using malak.Models;
using malak.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace malak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentreController : ControllerBase
    {
        private readonly Repositories.ICentreRepository centreRepository;
        public CentreController(Repositories.ICentreRepository centreRepository)
        {
            this.centreRepository = centreRepository;
        }
        [HttpPost("add")]
        public IActionResult AddCentre([FromBody] CentreRequest models)
        {
            var centre = new Centre()
            {
                idCentre = Guid.NewGuid(),
                NomCentre = models.nomCentre,
                adresse = models.adresse,
                email = models.email,
                tel = models.tel,
               
                
            };
            var idCentre = centreRepository.AddCentre(centre);
            return CreatedAtAction("AddCentre", idCentre);
        }
    }
}
