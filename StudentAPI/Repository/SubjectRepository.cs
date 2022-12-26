using StudentAPI.Models;

namespace StudentAPI.Repository
{
    public class SubjectRepository
    {
         private readonly AppDbContext _dbContext;
            public SubjectRepository(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            AppDbContext DbContext { get; }

            public Subject AddSubject(Subject subject)
            {
                var result = _dbContext.Subjects.Add(subject);
                _dbContext.SaveChanges();
                return result.Entity;


            }

            public bool DeleteSubject(int id)
            {
                var filtredData = _dbContext.Subjects.FirstOrDefault(s => s.SubId == id);
                if (filtredData != null)
                {
                    var result = _dbContext.Remove(filtredData);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }

            public Subject GetSubjectById(int id)
            {
                return _dbContext.Subjects.Where(s => s.SubId == id).FirstOrDefault();
            }

            public IEnumerable<Subject> GetSubjects()
            {
                return _dbContext.Subjects.ToList();
            }

            public Subject UpdateSubject(Subject subject)
            {
                var result = _dbContext.Subjects.Update(subject);
                _dbContext.SaveChanges();
                return result.Entity;
            }
    }
}

