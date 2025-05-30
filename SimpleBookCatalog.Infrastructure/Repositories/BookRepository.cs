namespace SimpleBookCatalog.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Application.Interfaces;
using SimpleBookCatalog.Domain.DTO;
using SimpleBookCatalog.Domain.Entities;
using SimpleBookCatalog.Domain.Enums;
using SimpleBookCatalog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;
    public BookRepository(IDbContextFactory<AppDbContext> factory)
    {
        _context = factory.CreateDbContext();        
    }
    public async Task<List<BookDTO>> GetAllAsync()
    {
        var Book = await _context.Books.OrderByDescending(x => x.CreatedAtDate).Where(x => x.RemovedAt == null).ToListAsync();
        var model = new List<BookDTO>();
        foreach (var book in Book) 
        {
            model.Add(new BookDTO()
            {
                BookId = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublicationDate = book.PublicationDate,
                Category = (Category)book.Category,
            });
        }
        return model;
    }

    public async Task AddAsync(BookDTO book)
    {
        var model = new Book()
        {
            Title = book.Title,
            Author = book.Author,
            PublicationDate = book.PublicationDate,
            Category = (int?)book.Category,
        };
        await _context.Books.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task<BookDTO> GetByIdAsync(Guid id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        var model = new BookDTO()
        {
            BookId = book.Id,
            Title = book.Title,
            Author = book.Author,
            PublicationDate = book.PublicationDate,
            Category = (Category)book.Category,   
        };
        return model;
    }

    public async Task UpdateBookAsync(BookDTO book)
    {
        var data = await _context.Books.FirstOrDefaultAsync(x => x.Id == book.BookId);
        
        data.Title = book.Title;
        data.Author = book.Author;
        data.PublicationDate = book.PublicationDate;
        data.Category = (int?)book.Category;
        data.UpdatedAtDate = DateTime.UtcNow;

        //_context.Entry(model).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Guid id)
    {
        var data = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

        if(data is not null)
        {
             data.RemovedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();  
        }
    }
}
