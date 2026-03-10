using UniversityCrud.Business.Entities;

namespace UniversityCrud.Business.Interfaces.IRepositories
{
    public interface IClassRepository
    {
        public Class FindById(int id);
        public List<Class> FindAll();
        public void Create(Class entity);
        public void Update(Class entity);
        public void Delete(int id);
    }
}