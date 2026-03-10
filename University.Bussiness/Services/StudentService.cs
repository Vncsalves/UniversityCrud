using System;
using System.Collections.Generic;
using UniversityCrud.Business.DTOs;
using UniversityCrud.Business.Entities;
using UniversityCrud.Business.Interfaces.IRepositories;
using UniversityCrud.Business.Interfaces.IServices;

namespace University.Bussiness.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public int Create(StudentDTO dto)
        {
            if (dto == null)
            {
                throw new Exception("The students data cannot be empty or null");
            }
            if (dto.FirstName == null || dto.FirstName == "")
            {
                throw new Exception("First name cannot be empty or null");
            }
            if (dto.FirstName.Length > 50)
            {
                throw new Exception("The first name is too long; it should contain fewer than 50 characters");
            }

            if (dto.Email.Contains("@faculdade.edu"))
            {
                var emailExists = _repo.FindByEmail(dto.Email);
                if (emailExists == null)
                {
                    var student = new Student
                    {
                        FirstName = dto.FirstName,
                        Email = dto.Email,
                        Number = dto.Number
                    };

                    _repo.Create(student);
                    return student.Id;
                }
                else
                {
                    throw new Exception("The email provided is already in use");
                }
            }
            else
            {
                throw new Exception("The email is invalid, is necessary @faculdade.edu");
            }
        }

        public List<Student> FindAll()
        {
            return _repo.FindAll();
        }

        public Student FindById(int id)
        {
            return _repo.FindById(id);
        }

        public int Update(int id, StudentDTO dto)
        {
            var student = _repo.FindById(id);
            if (student == null)
            {
                throw new Exception("Student not found.");
            }

            if (dto.FirstName == null || dto.FirstName == "")
            {
                throw new Exception("First name cannot be empty or null");
            }
            if (dto.FirstName.Length > 50)
            {
                throw new Exception("The first name is too long; it should contain fewer than 50 characters");
            }

            if (dto.Email.Contains("@faculdade.edu"))
            {
                student.FirstName = dto.FirstName;
                student.Email = dto.Email;
                student.Number = dto.Number;

                _repo.Update(student);
                return student.Id;
            }
            else
            {
                throw new Exception("The email is invalid, is necessary @faculdade.edu");
            }
        }

        public int Delete(int id)
        {
            var student = _repo.FindById(id);
            if (student == null)
            {
                throw new Exception("Student not found.");
            }
            _repo.Delete(id);
            return id;
        }
    }
}