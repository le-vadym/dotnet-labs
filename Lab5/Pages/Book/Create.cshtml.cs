using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab5.Repositories;

namespace Lab5.Pages.Book;

public class CreateModel : PageModel
{
    private IRepository<Models.Book> _repository;

    [BindProperty]
    public Models.Book Book { get; set; } = default!;

    public CreateModel(IRepository<Models.Book> repository) => _repository = repository;

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _repository.CreateAsync(Book);

        return RedirectToPage("./Index");
    }
}
