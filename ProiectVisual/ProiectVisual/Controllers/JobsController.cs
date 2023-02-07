using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectVisual.Data;
using ProiectVisual.Models;
using System.Diagnostics.Metrics;

namespace ProiectVisual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private Context _context;

        public JobsController(Context context)
        {
            _context = context;
        }

        [HttpGet("jobs")]
        public async Task<IActionResult> GetJobs()
        {
            return Ok(await _context.Jobs.ToListAsync());
        }
        //Create

        //Update

        //Delete

    }
}
