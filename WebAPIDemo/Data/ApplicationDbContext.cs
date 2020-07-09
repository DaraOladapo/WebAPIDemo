using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Models;

namespace WebAPIDemo.Data
{
    public class ApplicationDbContext:DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
    
        public DbSet<Person> Persons{get;set;}
        public DbSet<AnotherPerson> OtherPeople{get;set;}
    }
}