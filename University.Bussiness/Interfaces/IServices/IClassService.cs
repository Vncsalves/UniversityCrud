using UniversityCrud.Business.DTOs;
namespace UniversityCrud.University.Bussiness.Interfaces.IServices
{
    public interface IClassService
    {
        public int Create(ClassDTO dto);
        public int Update(int id, ClassDTO dto);
        public int Delete(int id);
        public ClassDTO FindById(int id);
        public List<ClassDTO> FindAll();
    }
}
