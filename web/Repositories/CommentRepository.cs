using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web
{
  public class CommentRepository : ICommentRepository
  {
    private Database _db;
    public Task<Comment> Add(Comment comment)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Comment>> All()
    {
      throw new NotImplementedException();
    }

    public Task<Comment> GetById(Guid Id)
    {
      throw new NotImplementedException();
    }

    public CommentRepository(Database db)
    {
      Console.WriteLine($"repository : {db}");
      _db = db;
    }
  }
}
