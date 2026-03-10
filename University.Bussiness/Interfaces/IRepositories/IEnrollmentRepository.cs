using UniversityCrud.Business.Entities;

namespace UniversityCrud.Business.Interfaces.IRepositories
{
    public interface IEnrollmentRepository
    {
        public void Create(Enrollment enrollment);
        public List<Enrollment> FindAll();
        public Enrollment FindById(int id);
        public void Delete(int id);
    }
}