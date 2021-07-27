using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HON.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentList;
        public MockStudentRepository()
        {
            _studentList = new List<Student>()
            {
                new Student(){Id=1,Name="Ram",Email="Ram@gmail.com"},
                new Student(){Id=2,Name="Ravi",Email="Ravi@gmail.com"}
            };

        }

        public Student Add(Student student)
        {
            student.Id = _studentList.Max(s => s.Id) + 1;
            _studentList.Add(student);
            return student;
        }

        public Student Delete(int id)
        {
            Student student = _studentList.FirstOrDefault(s => s.Id == id);
            if (student !=null)
            {
                _studentList.Remove(student);
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _studentList;
        }

        public Student GetStudent(int Id)
        {
            return _studentList.FirstOrDefault(s => s.Id == Id);
        }

        public Student Update(Student studentchange)
        {
            Student student = _studentList.FirstOrDefault(s => s.Id == studentchange.Id);
            if (student != null)
            {
                student.Name = studentchange.Name;
                student.Email = studentchange.Email;

            }
            return student;
        }
    }
}
