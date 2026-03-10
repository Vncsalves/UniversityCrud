using UniversityCrud.Business.Entities;
using UniversityCrud.Business.Interfaces.IRepositories;
using UniversityCrud.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace UniversityCrud.Data.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly DataContext _context;
        public EnrollmentRepository(DataContext context) => _context = context;

        public void Create(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        public List<Enrollment> FindAll()
        {
            return _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Class)
                .ThenInclude(c => c.Course)
                .ToList();
        }

        public Enrollment FindById(int id) => _context.Enrollments.FirstOrDefault(e => e.Id == id);

        public void Delete(int id)
        {
            var entity = FindById(id);
            if (entity != null)
            {
                _context.Enrollments.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}