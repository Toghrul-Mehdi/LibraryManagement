using LibraryManagement.Application.Abstractions.Repositories;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Persistence.Context;
using LibraryManagement.Persistence.Implementations.Repositories.Generic;

namespace LibraryManagement.Persistence.Implementations.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }
}
