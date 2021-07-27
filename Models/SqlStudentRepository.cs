using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HON.Models
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly AppDbContext db;
        public SqlStudentRepository(AppDbContext db)
        {
            this.db = db;
        }
        public Student Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return student;

        }

        public Student Delete(int id)
        {
            Student student = db.Students.Find(id);
            if(student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();

            }
            return student;
                
                
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return db.Students;
        }

        public Student GetStudent(int Id)
        {
            return db.Students.Find(Id);
        }

        public Student Update(Student studentchange)
        {
            var s = db.Students.Attach(studentchange);
            s.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return studentchange;

        }
    }
}
