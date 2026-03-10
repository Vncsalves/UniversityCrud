using UniversityCrud.Business.DTOs;

namespace UniversityCrud.Business.Interfaces.IServices
{
    public interface ICourseService
    {
        public int Create(CourseDTO dto);
        public int Update(int id, CourseDTO dto);
        public int Delete(int id);
        public CourseDTO FindById(int id);
        public List<CourseDTO> FindAll();
    }
}