using malak.Entities;
using malak.Models;
using malak.Models.Offers;
using malak.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace malak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly ICourRepository CourRepository;
        public OffersController(ICourRepository CourRepository)
        {
            this.CourRepository = CourRepository;
        }
        [HttpPatch("activate-offer")]
        public IActionResult ActivateOffer([FromBody] ActivateOfferRequest activateOfferRequest)
        {
            var Cour = CourRepository.GetCour(activateOfferRequest.idCour);
            Cour.IsOffred = true;
            var CourUpdateidCour = CourRepository.UpdateCour(Cour);
            return Ok(CourUpdateidCour);
        }
        [HttpPatch("disactivate-offer")]
        public IActionResult DisactivateOffer([FromBody] ActivateOfferRequest activateOfferRequest)
        {
            var Cour = CourRepository.GetCour(activateOfferRequest.idCour);
            var CourUpdateidCour = CourRepository.UpdateCour(Cour);
            return Ok(CourUpdateidCour);
        }

        [HttpPut("update-offred")]
        public IActionResult UpdateProduct([FromBody] CourOfferRequest models)
        {
            var Cour = CourRepository.GetCour(models.idCour);

            Cour.StarTime = models.startime;
            Cour.EndTime = models.endtime;
            Cour.Price = models.Price;
            Cour.IsOffred = models.IsOffred;
            var updateidCour = CourRepository.UpdateCour(Cour);
            return Ok(updateidCour);
        }

    }
}