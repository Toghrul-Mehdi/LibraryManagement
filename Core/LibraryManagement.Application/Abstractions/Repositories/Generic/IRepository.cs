using LibraryManagement.Domain.Entities.Common;
using System.Linq.Expressions;

namespace LibraryManagement.Application.Abstractions.Repositories.Generic;

public interface IRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> GetAll(
        Expression<Func<T, bool>>? expression = null,
        Expression<Func<T, object>>? orderExpression = null,
        int skip = 0,
        int take = 0,
        bool isDescending = false,
        bool isTracking = false,
        bool ignoreQuery = false,
        params string[]? includes);

    Task<T> GetByIdAsync(int id, params string[] includes);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
    Task<int> SaveChangesAsync();
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression, params string[]? includes);
}
