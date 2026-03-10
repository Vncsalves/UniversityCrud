using UniversityCrud.Business.Entities;

namespace UniversityCrud.Business.Interfaces.IRepositories
{
    public interface ICourseRepository
    {
        public Course FindById(int id);
        public List<Course> FindAll();
        public void Create(Course course);
        public void Update(Course course);
        public void Delete(int id);
    }
}