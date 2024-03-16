using ASP.NET_Web_API_CRUD_Operation_Using_SQL_Server_Stored_Procedures.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ASP.NET_Web_API_CRUD_Operation_Using_SQL_Server_Stored_Procedures.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        [HttpGet]
        public List<EmpList> GetEmpLists()
        {

            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("SqlServer").ToString());
            SqlCommand cmd1 = new SqlCommand("YourStoredProcedureName", conn);
            cmd1.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            adapter.Fill(dt);
            List <EmpList> list = new List<EmpList>();
            if(dt.Rows.Count > 0)
            {
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EmpList empList = new EmpList();
                    empList.Name = dt.Rows[i]["Name"].ToString();
                    list.Add(empList);
                }

            }
            if(dt.Rows.Count > 0)
            {
                return list;
            }
            return null;



        }
        [HttpGet("{id}")]
        public EmpList GetbyID(int id)
        {
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("SqlServer").ToString());
            SqlCommand cmd1 = new SqlCommand("uspEmpBYid", conn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@id", id);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            adapter.Fill(dt);
            EmpList empList = new EmpList();
            
            if (dt.Rows.Count > 0)
            {

               
                   
                    empList.Name = dt.Rows[0]["Name"].ToString();
                

            }
           if(empList!=null)
            {
                return empList;
            }
            return null;
        }
        

        [HttpPost]
        public void postvalues(EmpList empList)
        {
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("SqlServer").ToString());
            SqlCommand cmd = new SqlCommand("usp_AddEmployee", conn);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name",empList.Name);
            conn.Open();
            
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        
    }
    
}
