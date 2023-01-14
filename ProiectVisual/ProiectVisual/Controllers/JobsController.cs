using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectVisual.Models;

namespace ProiectVisual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        public static List<Job> jobs = new List<Job>
        {
            new Job{Id=1, Name="Video Editing"},
            new Job{Id=2, Name="Streaming"},
            new Job{Id=3, Name="Player"},
            new Job{Id=4, Name="Graphic Designer"},
            new Job{Id=5, Name="Content Creating"}
        };

        public static List<Member> members = new List<Member>
        {
            new Member{Id=1, Jobs=new List<Job> {jobs[0]}},
            new Member{Id=2, Jobs=new List<Job> {jobs[1]}}
        };

        [HttpGet]
        public List<Job> Get()
        {
            return jobs;
        }

        [HttpGet("jobs/{member_id}")]
        public IActionResult GetJobsByMember(int member_id)
        {
            return Ok(members.FirstOrDefault(x => x.Id.Equals(member_id))?.Jobs);
        }
    }
}
