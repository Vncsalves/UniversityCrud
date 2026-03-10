using UniversityCrud.Business.Entities;
using UniversityCrud.Business.Interfaces.IRepositories;
using UniversityCrud.Data.Contexts;
using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic;
using System.Linq;

namespace UniversityCrud.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = FindById(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public Student FindById(int id)
        {
            return _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Class)
                .ThenInclude(c => c.Course)
                .FirstOrDefault(s => s.Id == id);
        }

        public Student FindByEmail(string email)
        {
            return _context.Students.FirstOrDefault(s => s.Email == email);
        }

        public List<Student> FindAll()
        {
            return _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Class)
                .ThenInclude(c => c.Course)
                .ToList();
        }
    }
}