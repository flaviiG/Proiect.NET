using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectVisual.Data;
using ProiectVisual.Models;
using ProiectVisual.Models.DTOs;

namespace ProiectVisual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public DepartmentController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            return Ok(await _context.Departments.ToListAsync());
        }

        [HttpPost("createDepartment")]
        public async Task<IActionResult> CreateDep(DepartmentDTO dep)
        {
            var newDep = new Department();

            newDep = _mapper.Map<Department>(dep);

            await _context.Departments.AddAsync(newDep);
            await _context.SaveChangesAsync();
            return Ok(newDep);
        }
    }
}
