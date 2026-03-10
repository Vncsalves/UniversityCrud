using UniversityCrud.Business.DTOs;
using UniversityCrud.Business.Entities;
using UniversityCrud.Business.Interfaces.IRepositories;
using UniversityCrud.University.Bussiness.Interfaces.IServices;

namespace UniversityCrud.Business.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _repo;
        private readonly ICourseRepository _courseRepo;

        public ClassService(IClassRepository repo, ICourseRepository courseRepo)
        {
            _repo = repo;
            _courseRepo = courseRepo;
        }

        public int Create(ClassDTO dto)
        {
            if (dto == null)
            {
                throw new Exception("The class data cannot be empty or null");
            }
            if (dto.ClassName == null || dto.ClassName == "")
            {
                throw new Exception("Presence: Class name cannot be empty");
            }

            var courseExists = _courseRepo.FindById(dto.CourseId);
            if (courseExists != null)
            {
                var classEntity = new Class
                {
                    Name = dto.ClassName,
                    CourseId = dto.CourseId
                };

                _repo.Create(classEntity);
                return classEntity.Id;
            }
            else
            {
                throw new Exception("Integrity: The specified Course does not exist");
            }
        }

        public List<ClassDTO> FindAll()
        {
            return _repo.FindAll().Select(c => new ClassDTO
            {
                Id = c.Id,
                ClassName = c.Name,
                CourseId = c.CourseId
            }).ToList();
        }

        public int Update(int id, ClassDTO dto)
        {
            var entity = _repo.FindById(id);
            if (entity == null)
            {
                throw new Exception("Class not found");
            }

            if (dto.ClassName == null || dto.ClassName == "")
            {
                throw new Exception("Presence: Class name cannot be empty");
            }

            entity.Name = dto.ClassName;
            entity.CourseId = dto.CourseId;

            _repo.Update(entity);
            return entity.Id;
        }

        public int Delete(int id)
        {
            var entity = _repo.FindById(id);
            if (entity == null)
            {
                throw new Exception("Class not found");
            }
            _repo.Delete(id);
            return id;
        }

        public ClassDTO FindById(int id)
        {
            var c = _repo.FindById(id);
            if (c == null)
            {
                return null;
            }
            else
            {
                return new ClassDTO { Id = c.Id, ClassName = c.Name, CourseId = c.CourseId };
            }
        }
    }
}