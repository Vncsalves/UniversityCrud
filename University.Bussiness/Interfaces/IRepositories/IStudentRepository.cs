using UniversityCrud.Business.Entities;

namespace UniversityCrud.Business.Interfaces.IRepositories
{
    public interface IStudentRepository
    {
        public Student FindById(int id);
        public Student FindByEmail(string email);
        public List<Student> FindAll();
        public void Create(Student student);
        public void Update(Student student);
        public void Delete(int id);
    }
}