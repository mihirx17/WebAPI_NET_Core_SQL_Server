using Microsoft.EntityFrameworkCore;

namespace Advance_SQL_SERVER_with_API.Data
{
    public class StudentDBcontext:DbContext
    {
     

        public StudentDBcontext(DbContextOptions<StudentDBcontext> options) : base(options)
        {
        }
         public DbSet<Student> students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Student>().HasData(new List<Student>()
            {
                new Student
                {
                    id = Guid.NewGuid(),
                    name="Test",
                    age=21
                },
                new Student
                {
                    id = Guid.NewGuid() ,
                    name="Test2",
                    age=22
                }
            }   
                );

            
        }

    }
}
