using Lab4.Models;
using Lab4.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab4.Controllers;

public class BookBorrowsController : GenericController<BookBorrow>
{
    private readonly IRepository<Reader> _readersRepository;
    private readonly IRepository<Book> _booksRepository;

    public BookBorrowsController(IRepository<BookBorrow> repository, 
        IRepository<Reader> readersRepository, 
        IRepository<Book> booksRepository) : base(repository)
    {
        _readersRepository = readersRepository;
        _booksRepository = booksRepository;
    }

    public override async Task<IActionResult> Create()
    {
        var readers = await _readersRepository.GetAllAsync();
        var books = await _booksRepository.GetAllAsync();

        ViewBag.Readers = new SelectList(readers, "Id", "Description");
        ViewBag.Books = new SelectList(books, "Id", "Description");

        return await base.Create();
    }

    public override async Task<IActionResult> Edit(Guid? id)
    {
        var readers = await _readersRepository.GetAllAsync();
        var books = await _booksRepository.GetAllAsync();

        ViewBag.Readers = new SelectList(readers, "Id", "Description");
        ViewBag.Books = new SelectList(books, "Id", "Description");

        return await base.Edit(id);
    }
}
