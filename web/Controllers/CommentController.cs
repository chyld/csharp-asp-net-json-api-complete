using System;
using Microsoft.AspNetCore.Mvc;

namespace web
{
  [ApiController]
  [Route("comments")]
  public class CommentController : ControllerBase
  {
    private ICommentRepository _repository;

    public CommentController(ICommentRepository repository)
    {
      Console.WriteLine($"controller : {repository}");
      _repository = repository;
    }

    [HttpGet]
    public int Get()
    {
      return 3;
    }
  }
}
