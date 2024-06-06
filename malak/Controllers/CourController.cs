using malak.Models;
using malak.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using malak.Entities;
using NuGet.Protocol.Core.Types;
using malak.Helpers;
using System.Net.Http.Headers;
namespace malak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourController : ControllerBase
    {
        private readonly Repositories.ICourRepository courRepository;
        public CourController(Repositories.ICourRepository courRepository)
        {
            this.courRepository = courRepository;
        }
        [HttpPost("add")]
        public IActionResult AddCour([FromBody] CourRequest models)
        {
            var Cour = new Cour()
            {
                idCour = Guid.NewGuid(),
                NomCour = models.nomCour,
                Description = models.Description,
                StarTime = models.startime,
                EndTime = models.endtime,
                Price = models.Price,
                IsOffred = models.IsOffred,
            };
            var idCour = courRepository.AddCour(Cour);
            return CreatedAtAction("AddCour", idCour);
        }
        [HttpGet("all")]
        public IActionResult GetCour()
        {
            var Cour = courRepository.GetCour();
            return Ok(Cour);
        }
        [HttpGet("{idCourses}")]
        public IActionResult GetCour(Guid idCour)
        {
            var Cour = courRepository.GetCour(idCour);
            return Ok(Cour);

        }
        [HttpGet("search/{NomCour}")]
        public IActionResult SearchCour(string NomCour)
        {
            var Cour = courRepository.SearchCour(NomCour);
            return Ok(Cour);

        }
        [HttpGet("update/{idCour}")]
        public IActionResult UpdateCour([FromBody] CourOfferRequest models, string id)
        {

            Guid idCour;


            var Cour = courRepository.GetCour(models.idCour);
            {

                Cour.StarTime = models.startime;
                Cour.EndTime = models.endtime;
                Cour.Price = models.Price;
                Cour.IsOffred = models.IsOffred;
                var updateidCour = courRepository.UpdateCour(Cour);
                return Ok(updateidCour);
            }
        }
        [HttpGet("delete/{idCour}")]
        public IActionResult DeleteCour(String idCour)
        {
            Guid id = new Guid(idCour);
            var Cour = courRepository.GetCour(id);
             if (Cour == null)
             {
                 var error = new APIError()
                 {
                     ErrorDescription = "Cour does not exist",
                     Code = 1300
                 };
                 return BadRequest(error);
             }
            
            courRepository.DeleteCour(Cour);
            return Ok();
        }
        [HttpGet("current-offred-Cour/{page}/{pageSize}")]
        public IActionResult GetCurrentOffredCour(int page, int pageSize)
        {
            var Cour = courRepository.GetCurrentOffredCour(page, pageSize);
            if (Cour.Results.Count == 0)
            {
                return NoContent();
            }
            return Ok(Cour);
        }
        [HttpPut("add-offre-to-cour")]
        public IActionResult AddOfferrequest([FromBody] CourOfferRequest model)
        {
            var cour = courRepository.GetCour(model.idCour);
            
            cour.StarTime = model.startime;
            cour.EndTime = model.endtime;
            cour.IsOffred = model.IsOffred;
            var CouridCour = courRepository.UpdateCour(cour);
            return Ok(CouridCour);

        }
        [HttpPost("upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName , fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error : {ex}");
            }
        }
    }
}
