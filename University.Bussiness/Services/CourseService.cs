using System;
using System.Collections.Generic;
using System.Linq;
using UniversityCrud.Business.DTOs;
using UniversityCrud.Business.Entities;
using UniversityCrud.Business.Interfaces.IRepositories;
using UniversityCrud.Business.Interfaces.IServices;

namespace UniversityCrud.Business.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;

        public CourseService(ICourseRepository repo)
        {
            _repo = repo;
        }

        public int Create(CourseDTO dto)
        {
            if (dto == null)
            {
                throw new Exception("The course data cannot be empty or null");
            }
            if (dto.CourseName == null || dto.CourseName == "")
            {
                throw new Exception("Presence: Course name cannot be empty");
            }

            var course = new Course
            {
                Name = dto.CourseName,
                Description = dto.CourseDescription
            };

            _repo.Create(course);
            return course.Id;
        }

        public List<CourseDTO> FindAll()
        {
            var courses = _repo.FindAll();
            return courses.Select(c => new CourseDTO
            {
                CourseId = c.Id,
                CourseName = c.Name,
                CourseDescription = c.Description
            }).ToList();
        }

        public CourseDTO FindById(int id)
        {
            var course = _repo.FindById(id);
            if (course == null)
            {
                return null;
            }
            else
            {
                return new CourseDTO
                {
                    CourseId = course.Id,
                    CourseName = course.Name,
                    CourseDescription = course.Description
                };
            }
        }

        public int Update(int id, CourseDTO dto)
        {
            var course = _repo.FindById(id);
            if (course == null)
            {
                throw new Exception("Course not found");
            }

            if (dto.CourseName == null || dto.CourseName == "")
            {
                throw new Exception("Presence: Course name cannot be empty");
            }

            course.Name = dto.CourseName;
            course.Description = dto.CourseDescription;

            _repo.Update(course);
            return course.Id;
        }

        public int Delete(int id)
        {
            var course = _repo.FindById(id);
            if (course == null)
            {
                throw new Exception("Course not found");
            }

            _repo.Delete(id);
            return id;
        }
    }
}