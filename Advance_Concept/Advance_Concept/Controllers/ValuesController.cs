using Advance_Concept.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Stored_Procedures_.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly IConfiguration _Configuration;
        public ValuesController(IConfiguration configuration)
        {

            _Configuration = configuration;

        }
       
        [HttpGet("{id}")]
        public ProgramList Get(int id)
        {
            SqlConnection conn = new SqlConnection(_Configuration.GetConnectionString("SqlServer").ToString());
            SqlDataAdapter adapter = new SqlDataAdapter("usp_AllProgramById", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("ProgID", id);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            ProgramList list1 = new ProgramList();
            if (dt.Rows.Count > 0)
            {
               
                    
                    list1.ProgID = Convert.ToInt32(dt.Rows[0]["ProgID"]);
                    list1.ProgID = Convert.ToInt32(dt.Rows[0]["ProgDetailName"].ToString());
                  
                
            }
            if (list1!=null)
            {
                return list1 ;
            }
            return null;

        }

    }
}
