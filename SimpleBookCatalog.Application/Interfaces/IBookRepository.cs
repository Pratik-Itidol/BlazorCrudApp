
using SimpleBookCatalog.Domain.DTO;

namespace SimpleBookCatalog.Application.Interfaces;

public interface IBookRepository
{
    public Task AddAsync(BookDTO book);
    public Task<List<BookDTO>> GetAllAsync();   
    public Task<BookDTO> GetByIdAsync(Guid id);
    public Task UpdateBookAsync(BookDTO book);
    public Task DeleteBookAsync(Guid id);
}
