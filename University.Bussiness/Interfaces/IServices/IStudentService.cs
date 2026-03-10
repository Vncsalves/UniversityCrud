using UniversityCrud.Business.DTOs;
using UniversityCrud.Business.Entities;

namespace UniversityCrud.Business.Interfaces.IServices
{
    public interface IStudentService
    {
        public int Create(StudentDTO dto);
        public Student FindById(int id);
        public List<Student> FindAll();
        public int Update(int Id, StudentDTO dto);
        public int Delete(int id);
    }
}