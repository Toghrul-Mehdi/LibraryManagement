using LibraryManagement.Application.Abstractions.Repositories;
using LibraryManagement.Application.Abstractions.Services;
using LibraryManagement.Application.Common;
using LibraryManagement.Application.DTOs.Book;
using LibraryManagement.Application.ResponseModel;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Persistence.Implementations.Repositories;

namespace LibraryManagement.Persistence.Implementations.Services;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public async Task<ResponseModel<GetBookDto>> CreateAsync(CreateBookDto dto)
    {
        try
        {
            var exists = await bookRepository.AnyAsync(b => b.Title == dto.Title);
            if (exists)
                return ResponseModel.Failure<GetBookDto>("Bu Title-lə kitab artıq mövcuddur", 409);

            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Year = dto.Year,
                Price = dto.Price
            };

            await bookRepository.AddAsync(book);
            await bookRepository.SaveChangesAsync();

            return ResponseModel.Success(
                new GetBookDto(book.Id, book.Title, book.Author,book.Genre, book.Year, book.Price),
                "Kitab uğurla yaradıldı");
        }
        catch (Exception ex)
        {
            return ResponseModel.ServerError<GetBookDto>($"Daxili server xətası: {ex.Message}");
        }
    }

    public async Task<ResponseModel<bool>> DeleteAsync(int id)
    {
        try
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book is null)
                return ResponseModel.Failure<bool>("Kitab tapılmadı", 404);

            await bookRepository.DeleteAsync(book);
            await bookRepository.SaveChangesAsync();

            return ResponseModel.Success(true, "Kitab uğurla silindi");
        }
        catch (Exception ex)
        {
            return ResponseModel.ServerError<bool>($"Daxili server xətası: {ex.Message}");
        }
    }

    public async Task<ResponseModel<PaginatedResult<GetBookDto>>> GetAllAsync(int page, int pageSize)
    {
        try
        {
            var query = bookRepository
                .GetAll(orderExpression: b => b.Title);

            var totalCount = query.Count();

            var books = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new GetBookDto(b.Id, b.Title, b.Author,b.Genre, b.Year, b.Price))
                .ToList();

            var result = new PaginatedResult<GetBookDto>(books, totalCount, page, pageSize);

            return ResponseModel.Success(result, "Kitablar uğurla gətirildi");
        }
        catch (Exception)
        {
            return ResponseModel.ServerError<PaginatedResult<GetBookDto>>("Daxili server xətası.");
        }
    }

    public async Task<ResponseModel<GetBookDto>> GetByIdAsync(int id)
    {
        try
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book is null)
                return ResponseModel.Failure<GetBookDto>("Kitab tapılmadı", 404);

            return ResponseModel.Success(new GetBookDto(book.Id, book.Title, book.Author,book.Genre, book.Year, book.Price));
        }
        catch (Exception)
        {
            return ResponseModel.ServerError<GetBookDto>("Daxili server xətası.");
        }
    }

    public async Task<ResponseModel<GetBookDto>> UpdateAsync(int id,UpdateBookDto dto)
    {
        try
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book is null)
                return ResponseModel.Failure<GetBookDto>("Kitab tapılmadı", 404);

            var isbnConflict = await bookRepository
                .AnyAsync(b => b.Title == dto.Title);

            if (isbnConflict)
                return ResponseModel.Failure<GetBookDto>("Bu Title-lə kitab artıq mövcuddur", 409);

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Year = dto.Year;
            book.Price = dto.Price;

            await bookRepository.UpdateAsync(book);
            await bookRepository.SaveChangesAsync();

            return ResponseModel.Success(
                new GetBookDto(book.Id, book.Title, book.Author,book.Genre, book.Year, book.Price),
                "Kitab uğurla yeniləndi");
        }
        catch (Exception ex)
        {
            return ResponseModel.ServerError<GetBookDto>($"Daxili server xətası: {ex.Message}");
        }
    }

    public async Task<ResponseModel<IEnumerable<GetBookDto>>> GetByAuthorAsync(string author)
    {
        try
        {
            var books = bookRepository
                .GetAll()
                .Where(b => b.Author.ToLower().Contains(author.ToLower()))
                .Select(b => new GetBookDto(b.Id, b.Title, b.Author,b.Genre, b.Year, b.Price))
                .ToList();

            if (!books.Any())
                return ResponseModel.Failure<IEnumerable<GetBookDto>>("Bu müəllifə aid kitab tapılmadı", 404);

            return ResponseModel.Success<IEnumerable<GetBookDto>>(books, "Kitablar uğurla gətirildi");
        }
        catch (Exception)
        {
            return ResponseModel.ServerError<IEnumerable<GetBookDto>>("Daxili server xətası.");
        }
    }
    public async Task<ResponseModel<IEnumerable<GetBookDto>>> GetByGenreAsync(string genre)
    {
        try
        {
            var books = bookRepository
                .GetAll()
                .Where(b => b.Genre.ToLower().Contains(genre.ToLower()))
                .Select(b => new GetBookDto(b.Id, b.Title, b.Author, b.Genre, b.Year, b.Price))
                .ToList();

            if (!books.Any())
                return ResponseModel.Failure<IEnumerable<GetBookDto>>("Bu janra aid kitab tapılmadı", 404);

            return ResponseModel.Success<IEnumerable<GetBookDto>>(books, "Kitablar uğurla gətirildi");
        }
        catch (Exception)
        {
            return ResponseModel.ServerError<IEnumerable<GetBookDto>>("Daxili server xətası.");
        }
    }
}
