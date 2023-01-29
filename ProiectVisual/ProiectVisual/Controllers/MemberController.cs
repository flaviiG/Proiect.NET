using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectVisual.Data;
using ProiectVisual.Models;
using ProiectVisual.Models.DTOs;
using System.Diagnostics.Metrics;

namespace ProiectVisual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private Context _context;

        public MemberController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            return Ok(await _context.Members.ToListAsync());
        }

        [HttpPost("CreateMember")]
        public async Task<IActionResult> Create(MemberDTO memberDTO)
        {
            var newMember = new Member();
            newMember.First_Name = memberDTO.First_Name;
            newMember.Last_Name = memberDTO.Last_Name;

            await _context.Members.AddAsync(newMember);
            await _context.SaveChangesAsync();
            return Ok(newMember);
        }
    }
}
