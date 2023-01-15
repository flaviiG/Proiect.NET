using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProiectVisual.Data;
using ProiectVisual.Models;
using System.Diagnostics.Metrics;

namespace ProiectVisual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        public static List<Member> members = new List<Member>
        {
             new Member{Id = 1, First_Name = "Flavian", Last_Name = "Dumitrache", Status = "CEO"},
             new Member{Id = 2, First_Name = "David", Last_Name = "Pham", Status = "Manager"},
             new Member{Id = 3, First_Name = "Valentin", Last_Name = "Lescai", Status = "OG" },
             new Member{Id = 4, First_Name = "Stefan", Last_Name = "Panait", Status = "OG"}
        };

        //Endpoint

        //Get
        [HttpGet]
        public List<Member> Get()
        { return members; }

        [HttpGet("byId")]
        public Member GetById(int Id)
        {
            return members.FirstOrDefault(x => x.Id.Equals(Id));
        }

        [HttpGet("byId/{id}")]
        public Member GetByIdEndpoint(int id)
        {
            return members.FirstOrDefault(x => x.Id.Equals(id));
        }

        [HttpGet("filter /{first_name}/{last_name}")]
        public List<Member> GetWithFilters(string first_name, string last_name)
        {
            return members.Where(x => x.First_Name.ToLower().Equals(first_name) && x.Last_Name.ToLower().Equals(last_name)).ToList();
        }

        [HttpGet("filter /{status}")]
        public List<Member> GetWithFilters(string status)
        {
            return members.Where(x => x.Status.ToLower().Equals(status.ToLower())).ToList();
        }

        [HttpGet("fromRouteWithId/{id}")]
        public Member GetByIdWithFromRoute([FromRoute] int id)
        {
            Member membru = members.FirstOrDefault(x => x.Id.Equals(id));
            return membru;
        }

        [HttpGet("fromHeader")]
        public Member GetByIdWithFromHeader([FromHeader] int id)
        {
            return members.FirstOrDefault(x => x.Id.Equals(id));
        }

        [HttpGet("fromQuery")]
        public Member GetByIdWithFromQuery([FromQuery] int id)
        {
            return members.FirstOrDefault(x => x.Id.Equals(id));
        }

        //Status codes

        //200
        [HttpGet("StatusCodeOK")]
        public IActionResult StatusCodeOK()
        {
            return Ok("All good");
        }

        //204
        [HttpGet("NoContent")]
        public new IActionResult NoContent()
        {
            return NoContent();
        }

        //404
        [HttpGet("NotFound")]
        public IActionResult StatusCodeNotFound()
        {
            return NotFound();
        }

        //403
        [HttpGet("Forbid")]
        public IActionResult StatusCodeForbid()
        {
            return Forbid();
        }

        //400
        [HttpGet("BadRequest")]
        public IActionResult StatusCodeBadRequest()
        {
            return BadRequest();
        }

        //Create
        [HttpPost]
        public IActionResult Add(Member member)
        {
            members.Add(member);
            return Ok(members);
        }

        [HttpPost("fromBody")]
        public IActionResult AddWithFromBody([FromBody] Member member)
        {
            members.Add(member);
            return Ok(members);
        }

        [HttpPost("fromForm")]
        public IActionResult AddWithFromForm([FromForm] Member member)
        {
            members.Add(member);
            return Ok(members);
        }

        //Update Full
        [HttpPost("update")]
        public IActionResult Update([FromBody] Member member)
        {
            var memberIndex = members.FindIndex(x => x.Id == member.Id);
            members[memberIndex] = member;

            return Ok(members);
        }

        //Update async
        [HttpPost("updateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] Member member)
        {
            var memberIndex = members.FindIndex(x => x.Id == member.Id);
            members[memberIndex] = member;

            return Ok(members);
        }

        //Update Partial
        [HttpPatch("{id:int}")]
        public IActionResult Patch([FromRoute] int id, [FromBody] JsonPatchDocument<Member> member)
        {
            if(member != null) 
            {
                var memberToUpdate = members.FirstOrDefault(x => x.Id == id);
                member.ApplyTo(memberToUpdate);
                

                return Ok(members);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id_member)
        {
            var memberToDelete = members.FirstOrDefault(x => x.Id.Equals(id_member));
            members.Remove(memberToDelete); 
            return Ok(members);
        }

        private Context _context;

        public MemberController(Context context)
        {
            _context = context;
        }


    }
}
