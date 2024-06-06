using malak.Entities;

namespace malak.Repositories
{
    public interface IStudentRepository
    {
        void DeleteStudent(Student Student);
        Guid AddStudent(Student Student);
        Student GetStudent(Guid idStudent);
        IList<Student> GetStudent();
        IList<Student> SearchStudent(string NomStudent);
    }
}
