using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HON.Models
{
    public interface IStudentRepository
    {
        Student GetStudent(int Id);
        IEnumerable<Student> GetAllStudent();

        Student Add(Student student);
        Student Update(Student studentchange);
        Student Delete(int id);
    }
}
