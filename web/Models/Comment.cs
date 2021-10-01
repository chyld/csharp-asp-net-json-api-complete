using System;

namespace web
{
  public record Comment
  {
    public Guid Id { get; init; }
    public string Text { get; init; }
  }
}
