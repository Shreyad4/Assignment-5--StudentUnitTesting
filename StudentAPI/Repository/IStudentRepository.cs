using StudentAPI.Models;

namespace StudentAPI.Repositery
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudentById(int id);
        public Student AddStudent(Student student);
        public Student UpdateStudent(Student student);
        public bool DeleteStudent(int id);
    }
}
