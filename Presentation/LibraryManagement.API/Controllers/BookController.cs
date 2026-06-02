using LibraryManagement.API.Extensions;
using LibraryManagement.Application.Abstractions.Services;
using LibraryManagement.Application.DTOs.Book;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        => (await bookService.GetAllAsync(page, pageSize)).ToActionResult(this);

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => (await bookService.GetByIdAsync(id)).ToActionResult(this);

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateBookDto dto)
        => (await bookService.CreateAsync(dto)).ToActionResult(this);

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromForm] UpdateBookDto dto)
        => (await bookService.UpdateAsync(id, dto)).ToActionResult(this);

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => (await bookService.DeleteAsync(id)).ToActionResult(this);

    [HttpGet("author/{author}")]
    public async Task<IActionResult> GetByAuthor(string author)
        => (await bookService.GetByAuthorAsync(author)).ToActionResult(this);

    [HttpGet("genre/{genre}")]
    public async Task<IActionResult> GetByGenre(string genre)
        => (await bookService.GetByGenreAsync(genre)).ToActionResult(this);
}