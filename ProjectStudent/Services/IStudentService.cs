using ProjectStudent.Models;

namespace ProjectStudent.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> CreateStudentAsync(Student student);
    }
}
