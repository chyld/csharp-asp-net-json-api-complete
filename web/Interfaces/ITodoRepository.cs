using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web
{
  public interface ITodoRepository
  {
    Task<IEnumerable<Todo>> GetAllAsync();
    Task<Todo> GetByIdAsync(Guid id);
    Task AddAsync(Todo todo);
    Task SaveAsync();
  }
}
