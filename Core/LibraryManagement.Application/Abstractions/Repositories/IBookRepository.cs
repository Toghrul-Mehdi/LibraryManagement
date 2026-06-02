using LibraryManagement.Application.Abstractions.Repositories.Generic;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Abstractions.Repositories;
public interface IBookRepository : IRepository<Book>
{
}
