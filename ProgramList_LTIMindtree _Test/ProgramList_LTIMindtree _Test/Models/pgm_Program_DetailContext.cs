using Microsoft.EntityFrameworkCore;

namespace ProgramList_LTIMindtree__Test.Models
{
    public class pgm_Program_DetailContext : DbContext
    {
        public pgm_Program_DetailContext(DbContextOptions<pgm_Program_DetailContext> options) : base(options) { }
        public DbSet<pgm_Program_Detail> pgm_Program_Detail { get; set; } // Specify the correct table name here
    }
}
