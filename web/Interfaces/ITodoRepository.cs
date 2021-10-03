using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web
{
  public interface ITodoRepository
  {
    Task<IEnumerable<Todo>> GetAllAsync();
    Task<Todo> GetByIdAsync(Guid id);
    Todo AddComment(Todo todo, Comment comment);
    Task<Todo> AddTagAsync(Todo todo, Tag tag);
    Task AddAsync(Todo todo);
    Task SaveAsync();
  }
}
