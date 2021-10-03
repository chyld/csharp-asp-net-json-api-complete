using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace web
{
  public class TodoRepository : ITodoRepository
  {
    private Database _db;

    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
      return await _db.Todos.ToListAsync();
    }

    public async Task<Todo> GetByIdAsync(Guid id)
    {
      return await _db.Todos
      .Where(t => t.Id == id)
      .Include(t => t.Comments)
      .Include(t => t.Tags)
      .SingleOrDefaultAsync();
    }

    public Todo AddComment(Todo todo, Comment comment)
    {
      todo.Comments.Add(comment);
      return todo;
    }

    public async Task<Todo> AddTagAsync(Todo todo, Tag tag)
    {
      var oldTag = await _db.Tags.Where(t => t.Name == tag.Name).SingleOrDefaultAsync();
      todo.Tags.Add(oldTag ?? tag);
      return todo;
    }

    public async Task AddAsync(Todo todo)
    {
      await _db.AddAsync(todo);
    }

    public async Task SaveAsync()
    {
      await _db.SaveChangesAsync();
    }

    public TodoRepository(Database db)
    {
      _db = db;
    }
  }
}
