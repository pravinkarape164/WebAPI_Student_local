using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebAPI_Student.Models;
using Serilog;

namespace WebAPI_Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentsApiContext _db;
        public StudentAPIController(StudentsApiContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            var data = await _db.Students.ToListAsync();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var data = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }
        [HttpPost,ActionName("Create")]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest("Student data is null.");
            }

            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _db.Entry(student).State = EntityState.Modified;
            //try
            //{
            await _db.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!St(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
