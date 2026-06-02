using LibraryManagement.Application.Common;
using LibraryManagement.Application.DTOs.Book;
using LibraryManagement.Application.ResponseModel;

namespace LibraryManagement.Application.Abstractions.Services;
public interface IBookService
{
    Task<ResponseModel<PaginatedResult<GetBookDto>>> GetAllAsync(int page, int pageSize);
    Task<ResponseModel<GetBookDto>> GetByIdAsync(int id);
    Task<ResponseModel<GetBookDto>> CreateAsync(CreateBookDto dto);
    Task<ResponseModel<GetBookDto>> UpdateAsync(int id,UpdateBookDto dto);
    Task<ResponseModel<bool>> DeleteAsync(int id);
    Task<ResponseModel<IEnumerable<GetBookDto>>> GetByAuthorAsync(string author);
    Task<ResponseModel<IEnumerable<GetBookDto>>> GetByGenreAsync(string genre);
}
