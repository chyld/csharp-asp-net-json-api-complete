using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web
{
  public class Tag
  {
    [Key]
    public string Name { get; set; }
    public ColorEnum Color { get; set; }
    public List<Todo> Todos { get; set; }
  }
}