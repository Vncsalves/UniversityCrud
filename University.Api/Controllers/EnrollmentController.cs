using System;
using Microsoft.AspNetCore.Mvc;
using UniversityCrud.Business.DTOs;
using UniversityCrud.Business.Interfaces.IServices;

namespace University.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _service;

        public EnrollmentController(IEnrollmentService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_service.FindAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] EnrollmentCreateDTO dto)
        {
            try
            {
                int id = _service.Create(dto);
                return StatusCode(201, new { Message = "Enrollment completed successfully", Id = id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Enrollment canceled successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}