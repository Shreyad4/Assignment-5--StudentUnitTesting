using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Repository;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
            private readonly ISubjectRepository _repositoty;

            public SubjectController(ISubjectRepository repository)
            {
                _repositoty = repository;
            }

            public SubjectController()
            {
            }

            [HttpGet]
            public IEnumerable<Subject> GetSubjects()
            {
                return _repositoty.GetSubjects();

            }
            [HttpGet("{id}")]
            public Subject GetSubjectById(int id)
            {
                return _repositoty.GetSubjectById(id);

            }

            [HttpPost]
            public Subject AddSubject(Subject subject)
            {
                return _repositoty.AddSubject(subject);
            }

            [HttpPut("{id}")]
            public Subject UpdateById(Subject subject)
            {
                return _repositoty.UpdateSubject(subject);
            }

            [HttpDelete("{id}")]
            public bool DeleteById(int id)
            {

                return _repositoty.DeleteSubject(id);

            }


        }
}

