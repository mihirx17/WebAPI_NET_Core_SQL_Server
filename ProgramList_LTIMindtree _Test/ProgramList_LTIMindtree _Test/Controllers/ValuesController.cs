using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramList_LTIMindtree__Test.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgramList_LTIMindtree__Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly pgm_Program_DetailContext _pgmProgramDetailContext;

        public ValuesController(pgm_Program_DetailContext pgmProgramDetailContext)
        {
            _pgmProgramDetailContext = pgmProgramDetailContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<pgm_Program_Detail>>> GetValues()
        {
            var pgm_program_details = await _pgmProgramDetailContext.pgm_Program_Detail.ToListAsync();
            return Ok(pgm_program_details);
        }
    }
}
