
using StudentAPI.Models;

namespace StudentAPI.Repository
{
    public interface ISubjectRepository
    {
        public IEnumerable<Subject> GetSubjects();
        public Subject GetSubjectById(int id);
        public Subject AddSubject(Subject subject);
        public Subject UpdateSubject(Subject subject);
        public bool DeleteSubject(int id);
    }
}
