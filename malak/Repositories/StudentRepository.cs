using malak.DbContexts;
using malak.Entities;
using Microsoft.EntityFrameworkCore;
namespace malak.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly icfContext icfContext;

        public StudentRepository(icfContext icfContext)
        {
            this.icfContext = icfContext;
        }
        public void DeleteStudent(Student student)
        {
            icfContext.students.Remove(student);
            icfContext.SaveChanges();
        }
        public Guid AddStudent(Student student)
        {
            icfContext.students.Add(student);
            icfContext.SaveChanges();
            return student.idStudent;
        }
        public Student GetStudent(Guid idStudent)
        {
            return icfContext.students.FirstOrDefault(p => p.idStudent == idStudent);

            throw new NotImplementedException();

        }
        public IList<Student> GetStudent()
        {
            return icfContext.students.Include(p => p.idStudent).ToList();
        }
        public IList<Student> SearchStudent(string NomStudent)
        {
            return icfContext.students.Where(p => p.NomStudent.Contains(NomStudent)).ToList();
        }

    }
}
