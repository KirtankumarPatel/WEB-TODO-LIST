using AspCore_MVC_Todo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AspCore_MVC_Todo.Models
{

    // Enitiy framework context class
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
           : base(options)
        {
        }

        // Table dataset config.
        public DbSet<Todo> Todo { get; set; }
    }
}
