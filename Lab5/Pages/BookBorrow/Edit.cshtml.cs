using Lab5.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Pages.BookBorrow;

public class EditModel : PageModel
{
    private readonly IRepository<Models.Book> _bookRepository;
    private readonly IRepository<Models.Reader> _readerRepository;
    private readonly IRepository<Models.BookBorrow> _repository;

    public EditModel(IRepository<Models.Book> bookRepository, IRepository<Models.Reader> readerRepository, IRepository<Models.BookBorrow> repository)
    {
        _repository = repository;
        _bookRepository = bookRepository;
        _readerRepository = readerRepository;
    }

    [BindProperty]
    public Models.BookBorrow BookBorrow { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || !await _repository.ExistsAsync(id.Value))
        {
            return NotFound();
        }

        BookBorrow = await _repository.GetAsync(id.Value);

        ViewData["BookId"] = new SelectList(await _bookRepository.GetAllAsync(), "Id", "Author");
        ViewData["ReaderId"] = new SelectList(await _readerRepository.GetAllAsync(), "Id", "FirstName");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            await _repository.UpdateAsync(BookBorrow.Id, BookBorrow);
        }
        catch
        {
            if (!await _repository.ExistsAsync(BookBorrow.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }
}
