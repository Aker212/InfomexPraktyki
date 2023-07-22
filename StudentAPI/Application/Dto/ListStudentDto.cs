namespace Application.Dto
{
    public class ListStudentDto
    {
        public int Count { get; set; }
        public IEnumerable<StudentDto> Students { get; set; }
    }
}
