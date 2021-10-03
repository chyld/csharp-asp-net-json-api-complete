using System;
using System.Collections.Generic;

namespace web
{
  public class Todo
  {
    public Guid Id { get; set; }
    public StatusEnum Status { get; set; }
    public PriorityEnum Priority { get; set; }
    public string Title { get; set; }
    public DateTime Due { get; set; }
    public List<Tag> Tags { get; set; }
    public List<Comment> Comments { get; set; }

    public Todo() { }
    public Todo(TodoDto todoDto)
    {
      Id = Guid.NewGuid();
      Status = StatusEnum.Open;
      Priority = todoDto.Priority;
      Title = todoDto.Title;
      Due = todoDto.Due;
      Tags = new();
      Comments = new();
    }
  }
}
