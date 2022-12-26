using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;
using StudentAPI.Repositery;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : Controller
    {
        private readonly Models.AppDbContext _Db;
        

        public StudentController(AppDbContext Db)
        {
            _Db = Db;
        }

        public StudentController(IStudentRepository @object)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            var StudentList = await _Db.Students.Include(sub => sub.Subject).ToListAsync();
            return (StudentList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var stud = await _Db.Students.Where(u => u.StudentId == id).Include(sub => sub.Subject).FirstOrDefaultAsync();
            if (stud == null)
            {
                return NotFound();
            }
            return Ok(stud);

        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            _Db.Students.Add(student);
            await _Db.SaveChangesAsync();
            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateStudentById(int id, Student student)
        {
            if (student == null || id != student.StudentId)
            {
                return BadRequest();
            }

            var stud = _Db.Students.AsNoTracking().FirstOrDefault(u => u.StudentId == id);
            stud.Name = student.Name;
            stud.Address = student.Address;
            stud.Class = student.Class;

            _Db.Students.Update(student);
            try
            {
                await _Db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (IsProductExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(stud);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletStudentById(int id)
        {
            var dstud = await _Db.Students.FirstOrDefaultAsync(u => u.StudentId == id);
            if (dstud == null)
            {
                return NotFound();
            }
            _Db.Students.Remove(dstud);
            await _Db.SaveChangesAsync();
            return NoContent();
        }
        private bool IsProductExist(int id)
        {
            return _Db.Students.Any(e => e.StudentId == id);
        }
    }
}
