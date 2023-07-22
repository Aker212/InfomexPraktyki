using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [SwaggerOperation(Summary = "Zobacz wszystkich studentów")]
        [HttpGet]
        public IActionResult Get()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [SwaggerOperation(Summary = "Wyszukaj studenta po id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentService.GetStudentById(id);

            if (student is null)
                return NotFound();

            return Ok(student);
        }

        [SwaggerOperation(Summary = "Dodaj nowego studenta")]
        [HttpPost]
        public IActionResult Add(AddStudentDto newStudent)
        {
            var student = _studentService.AddStudent(newStudent);
            return Created($"api/student/{student.Id}", student);
        }

        [SwaggerOperation(Summary = "Zaktualizuj informacje o studencie")]
        [HttpPut]
        public IActionResult Update(UpdateStudentDto updateStudent)
        {
            _studentService.UpdateStudent(updateStudent);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Usuń studenta")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
