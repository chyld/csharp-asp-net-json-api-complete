using System;
using Xunit;
using FluentAssertions;
using lib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using web;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace test.Controllers
{
  public class TodoControllerTest
  {
    private TodoController _controller;
    private Mock<ITodoRepository> _mockRepository;
    private DefaultHttpContext _httpContext;

    public TodoControllerTest()
    {
      _mockRepository = new Mock<ITodoRepository>();
      _httpContext = new DefaultHttpContext();
      _controller = new TodoController(_mockRepository.Object)
      { ControllerContext = new ControllerContext() { HttpContext = _httpContext } };
    }

    [Fact]
    public async Task ShouldCreateTodo()
    {
      var dto = new TodoDto() { Priority = PriorityEnum.Medium, Title = "Clean House", Due = DateTime.Parse("01/01/2000") };
      var result = await _controller.Create(dto);
      var createdActionResult = result as CreatedAtActionResult;
      createdActionResult.StatusCode.Should().Be(201);
      createdActionResult.ActionName.Should().Be("GetOne");
      createdActionResult.RouteValues["Id"].Should().NotBeNull();
    }

    [Fact]
    public async Task ShouldGetOneTodo()
    {
      Guid guid = Guid.NewGuid();
      _mockRepository.Setup(obj => obj.GetByIdAsync(guid)).Returns(Task.FromResult(new Todo() { Id = guid, Title = "Write Code" }));
      var result = await _controller.GetOne(guid);
      var okResult = result as OkObjectResult;
      okResult.StatusCode.Should().Be(200);
      (okResult.Value as Todo).Title.Should().Be("Write Code");
      _mockRepository.Verify(obj => obj.GetByIdAsync(guid));
    }

    [Fact]
    public async Task ShouldGetAllTodos()
    {
      var result = await _controller.GetAll();
      var okResult = result as OkObjectResult;
      okResult.StatusCode.Should().Be(200);
      _mockRepository.Verify(obj => obj.GetAllAsync());
    }
  }
}
