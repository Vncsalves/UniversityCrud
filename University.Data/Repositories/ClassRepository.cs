using UniversityCrud.Business.Entities;
using UniversityCrud.Business.Interfaces.IRepositories;
using UniversityCrud.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace UniversityCrud.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly DataContext _context;

        public ClassRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Class entity)
        {
            _context.Classes.Add(entity);
            _context.SaveChanges(); 
        }

        public List<Class> FindAll()
        {
            return _context.Classes
                .Include(c => c.Course)
                .ToList();
        }

        public Class FindById(int id)
        {
            return _context.Classes
                .Include(c => c.Course)
                .FirstOrDefault(c => c.Id == id);
        }

        public void Update(Class entity)
        {
            _context.Classes.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = FindById(id);
            if (entity != null)
            {
                _context.Classes.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}