using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5.Repositories;

namespace Lab5.Pages.BookBorrow;

public class CreateModel : PageModel
{
    private readonly IRepository<Models.Book> _bookRepository;
    private readonly IRepository<Models.Reader> _readerRepository;
    private readonly IRepository<Models.BookBorrow> _repository;

    public CreateModel(IRepository<Models.Book> bookRepository,
        IRepository<Models.Reader> readerRepository,
        IRepository<Models.BookBorrow> repository)
    {
        _repository = repository;
        _bookRepository = bookRepository;
        _readerRepository = readerRepository;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        ViewData["BookId"] = new SelectList(await _bookRepository.GetAllAsync(), "Id", "Description");
        ViewData["ReaderId"] = new SelectList(await _readerRepository.GetAllAsync(), "Id", "Description");
        return Page();
    }

    [BindProperty]
    public Models.BookBorrow BookBorrow { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        await _repository.CreateAsync(BookBorrow);

        return RedirectToPage("./Index");
    }
}
