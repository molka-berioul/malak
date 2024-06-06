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
    public class AdminController : ControllerBase
    {
        private readonly Repositories.IAdminRepository adminRepository;
        public AdminController(Repositories.IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }
        [HttpPost("add")]
        public IActionResult AddAdmin([FromBody] AdminRequest models)
        {
            var admin = new Admin()
            {
                idAdmin = Guid.NewGuid(),
                nomAdmin = models.nomAdmin,
                prenom = models.prenom,
                adresse = models.adresse,
                email = models.email,
                tel = models.tel,
            };
            Guid idAdmin = adminRepository.AddAdmin(admin);
            return CreatedAtAction("AddAdmin", idAdmin);
        }
        [HttpGet("all")]
        public IActionResult GetAdmin()
        {
            var Admin = adminRepository.GetAdmin();
            return Ok(Admin);
        }
        [HttpGet("{idAdmin}")]
        public IActionResult GetAdmin(Guid idAdmin)
        {
            var Admin = adminRepository.GetAdmin(idAdmin);
            return Ok(Admin);

        }
        [HttpDelete("delete/{idAdmin}")]
        public IActionResult DeleteAdmin(string idAdmin)
        {
            Guid AdminidAdmin = new Guid(idAdmin);
            var Admin = adminRepository.GetAdmin(AdminidAdmin);
              if (Admin == null)
              {
                  var error = new APIError()
                  {
                      ErrorDescription = "Administrateur does not exist",
                      Code = 1300
                  };
                  return BadRequest(error);
              }
            adminRepository.DeleteAdmin(Admin);
            return Ok();
        }


    }
}
