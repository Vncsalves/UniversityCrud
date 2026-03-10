using System;
using System.Collections.Generic;
using System.Linq;
using UniversityCrud.Business.DTOs;
using UniversityCrud.Business.Entities;
using UniversityCrud.Business.Interfaces.IRepositories;
using UniversityCrud.Business.Interfaces.IServices;

namespace University.Bussiness.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repo;
        private readonly IStudentRepository _studentRepo;
        private readonly IClassRepository _classRepo;

        public EnrollmentService(IEnrollmentRepository repo, IStudentRepository studentRepo, IClassRepository classRepo)
        {
            _repo = repo;
            _studentRepo = studentRepo;
            _classRepo = classRepo;
        }

        public int Create(EnrollmentCreateDTO dto)
        {
            if (dto == null)
            {
                throw new Exception("The enrollment data cannot be empty or null");
            }

            var studentExists = _studentRepo.FindById(dto.StudentId);
            if (studentExists != null)
            {
                var classExists = _classRepo.FindById(dto.ClassId);
                if (classExists != null)
                {
                    var enrollment = new Enrollment
                    {
                        StudentId = dto.StudentId,
                        ClassId = dto.ClassId
                    };

                    _repo.Create(enrollment);
                    return enrollment.Id;
                }
                else
                {
                    throw new Exception("Integrity: Class not found");
                }
            }
            else
            {
                throw new Exception("Integrity: Student not found");
            }
        }

        public List<EnrollmentDTO> FindAll()
        {
            var enrollments = _repo.FindAll();

            return enrollments.Select(e => new EnrollmentDTO
            {
                EnrollmentId = e.Id,
                StudentId = e.StudentId,
                StudentName = e.Student?.FirstName,
                ClassId = e.ClassId,
                ClassName = e.Class?.Name,
                CourseName = e.Class?.Course?.Name
            }).ToList();
        }

        public int Delete(int id)
        {
            var enrollment = _repo.FindById(id);
            if (enrollment == null)
            {
                throw new Exception("Enrollment not found");
            }

            _repo.Delete(id);
            return id;
        }
    }
}