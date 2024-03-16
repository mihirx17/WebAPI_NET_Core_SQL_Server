using System.ComponentModel.DataAnnotations;

namespace ProgramList_LTIMindtree__Test.Models
{
    public class pgm_Program_Detail
    {
        [Key] // This attribute specifies that ProgID is the primary key
        public int ProgID { get; set; }

        public string ProgDetailName { get; set; }
    }
}
