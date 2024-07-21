using DesafioUbc.Application.Helper;
using DesafioUbc.Application.Mappers;
using DesafioUbc.Application.Requests.Student;
using DesafioUbc.Application.Responses;
using DesafioUbc.Application.Services;
using DesafioUbc.Business.Entitys;
using DesafioUbc.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioUbc.Api.Controllers;

[Route("api/students")]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;


    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public IActionResult Create([FromBody]EditorStudentRequest request)
    {
        var response = _studentService.Create(request);

        return Created($"/api/students/{response?.Data?.Id}",response);
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery]int pageNumber = Configuration.DefaultPageNumber,
                                [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        return Ok(_studentService.GetAll(new GetAllStudentsRequest() { PageNumber = pageNumber, PageSize = pageSize}));
    }

    [HttpGet("{id:long}")]
    public IActionResult GetById(long id)
    {
        var response = _studentService.GetById(id);

        if (response.Data is null) return NotFound(response);

        return Ok(response);
    }

    [HttpPut("{id:long}")]
    public IActionResult Update(long id, [FromBody]EditorStudentRequest request)
    {
        var response = _studentService.Update(id, request);

        if (response.Data is null) return NotFound(response);

        return Ok(response);
    }

    [HttpDelete("{id:long}")]
    public IActionResult Delete(long id)
    {
        var response = _studentService.Delete(id);

        if (response.Data is null) return NotFound(response);

        return Ok(response);
    }
}