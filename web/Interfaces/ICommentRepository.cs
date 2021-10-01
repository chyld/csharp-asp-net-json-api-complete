using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web
{
  public interface ICommentRepository
  {
    Task<IEnumerable<Comment>> All();
    Task<Comment> GetById(Guid Id);
    Task<Comment> Add(Comment comment);
  }
}
