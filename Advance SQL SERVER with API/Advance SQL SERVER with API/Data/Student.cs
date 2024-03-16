using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advance_SQL_SERVER_with_API.Data
{
    public class Student
    {
        
       public Guid id { get; set; }
        [Required (ErrorMessage ="Name Must be Required")]
       public string name { get; set; }
        [Required(ErrorMessage ="Age Should be in between 21 to 65")]
        [Range(21,65)]
        
        public int age { get; set; }    
    }
}
