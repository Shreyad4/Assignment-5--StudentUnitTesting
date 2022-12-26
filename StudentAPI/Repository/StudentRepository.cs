using StudentAPI.Models;
using StudentAPI.Repositery;
using System.Runtime.InteropServices;

namespace StudentAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;
        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student AddStudent(Student student)
        {
            var result = _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return result.Entity;


        }

        public bool DeleteStudent(int id)
        {
            var filtredData = _dbContext.Students.FirstOrDefault(s => s.StudentId == id);
            if (filtredData != null)
            {
                var result = _dbContext.Remove(filtredData);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Student GetStudentById(int id)
        {
            return _dbContext.Students.Where(s => s.StudentId == id).FirstOrDefault();
        }

        public IEnumerable<Student> GetStudents()
        {
            return _dbContext.Students.ToList();
        }

        public Student UpdateStudent(Student student)
        {
            var result = _dbContext.Students.Update(student);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}

