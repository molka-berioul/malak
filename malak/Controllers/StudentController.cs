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
    public class StudentController : ControllerBase
    {
        private readonly Repositories.IStudentRepository studentRepository;
        public StudentController(Repositories.IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        [HttpPost("add")]
        public IActionResult AddStudent([FromBody] StudentRequest models)
        {
            var Student = new Student()
            {
                idStudent = Guid.NewGuid(),
                NomStudent = models.nomStudent,
                prenom = models.prenom,
                adresse = models.adresse,
                email = models.email,
                tel = models.tel,
            };
            var idStudent = studentRepository.AddStudent(Student);
            return CreatedAtAction("AddStudent", idStudent);
        }
        [HttpGet("all")]
        public IActionResult GetProf()
        {
            var Student = studentRepository.GetStudent();
            return Ok(Student);
        }
        [HttpGet("{idStudent}")]
        public IActionResult GetStudent(Guid idStudent)
        {
            var Student = studentRepository.GetStudent(idStudent);
            return Ok(Student);

        }
        [HttpGet("search/{NomStudent}")]
        public IActionResult SearchStudent(string NomStudent)
        {
            var Student = studentRepository.SearchStudent(NomStudent);
            return Ok(Student);

        }
        [HttpGet("delete/{StudentidStudent}")]
        public IActionResult DeleteStudent(string idStudent)
        {
            Guid StudentidStudent = new Guid();
            var Student = studentRepository.GetStudent(StudentidStudent);
             if (Student == null)
             {
                 var error = new APIError()
                 {
                     ErrorDescription = "Student does not exist",
                     Code = 1300
                 };
                 return BadRequest(error);
             }
            studentRepository.DeleteStudent(Student);
            return Ok();
        }



    }
}
