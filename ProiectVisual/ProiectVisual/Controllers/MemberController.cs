using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectVisual.Models;

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
        



    }
}
