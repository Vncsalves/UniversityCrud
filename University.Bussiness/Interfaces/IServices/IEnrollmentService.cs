using UniversityCrud.Business.DTOs;

namespace UniversityCrud.Business.Interfaces.IServices
{
    public interface IEnrollmentService
    {
        int Create(EnrollmentCreateDTO dto);
        List<EnrollmentDTO> FindAll();
        int Delete(int id);
    }
}