using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectVisual.Data;
using ProiectVisual.Models;
using ProiectVisual.Models.DTOs;
using ProiectVisual.Repositories.MemberRepository;
using ProiectVisual.Services.MemberServices;
using System.Diagnostics.Metrics;

namespace ProiectVisual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private Context _context;

        private readonly IMemberService _memberService;
/*     
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public MemberController(Context context)
        {
            _context = context;
        }
*/
        public MemberController(IMemberService memberService = null, Context context = null)
        {
            _memberService = memberService;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            return Ok(await _context.Members.ToListAsync());
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var member = _context.Members.FirstOrDefault(x => x.Id == id);
            return Ok(member);
        }
      [HttpGet("byStatus/{status}")]
        public List<Member> GetByStatus(string status)
        {
            return _memberService.GetDataMappedByStatus(status);
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
        //Update
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchMember([FromRoute] int id, [FromBody] JsonPatchDocument memberDocument)
        {
            var updatedMember = await _memberService.UpdateMember(id, memberDocument);
            if(updatedMember == null)
            {
                return NotFound();
            }
            return Ok(updatedMember);
        }


        //Delete


    }
}
