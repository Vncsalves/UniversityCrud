
using global::UniversityCrud.Business.Entities;
using global::UniversityCrud.Business.Interfaces.IRepositories;
using global::UniversityCrud.Data.Contexts;


namespace UniversityCrud.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public List<Course> FindAll() => _context.Courses.ToList();

        public Course FindById(int id) => _context.Courses.FirstOrDefault(c => c.Id == id);

        public void Update(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = FindById(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}