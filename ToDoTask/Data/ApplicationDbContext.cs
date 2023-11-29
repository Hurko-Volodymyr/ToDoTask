using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;

namespace ToDoTask.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
