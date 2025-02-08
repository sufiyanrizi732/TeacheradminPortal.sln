using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeacheradminPortal.Data;
using TeacheradminPortal.Models;
using TeacheradminPortal.Models.Entities;

namespace TeacheradminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TeachersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
         
        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            var allTeachers = dbContext.Teachers.ToList();

            return Ok(allTeachers);
        }


        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetTeacherById(Guid id)
        {
            var teacher = dbContext.Teachers.Find(id);

            if (teacher is null)
            {
                return NotFound();
            }

            return Ok(teacher);
                
        }

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpdateTeacher(Guid id, UpdateTeacherDto updateTeacherDto )
        {
            var teacher = dbContext.Teachers.Find(id);

            if (teacher is null)
            {
                return NotFound();
            }

            teacher.Name = updateTeacherDto.Name;
            teacher.Email = updateTeacherDto.Email;
            teacher.Department = updateTeacherDto.Department;
            teacher.Phone = updateTeacherDto.Phone;
            teacher.Salary = updateTeacherDto.Salary;

            dbContext.SaveChanges();

            return Ok(teacher);
        }

        [HttpPost]

        public IActionResult AddTeacher(AddTeacherDto addTeacherDto) {

            var teacherEntity = new Teacher()
            {
                Name = addTeacherDto.Name,
                Email = addTeacherDto.Email,
                Department = addTeacherDto.Department,
                Phone = addTeacherDto.Phone,
                Salary = addTeacherDto.Salary,
            };

            dbContext.Teachers.Add(teacherEntity);
            dbContext.SaveChanges();

            return Ok(teacherEntity);
        
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeletTeacher(Guid id)
        {
            var teacher = dbContext.Teachers.Find(id);

            if (teacher is null)
            {
                return NotFound();
            }

            dbContext.Teachers.Remove(teacher);
            dbContext.SaveChanges();

            return Ok();

        }

    }
}
