using AspCore_MVC_Todo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AspCore_MVC_Todo.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
           : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; }
    }
}
