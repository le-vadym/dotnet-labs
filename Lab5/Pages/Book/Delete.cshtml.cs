using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab5.Repositories;

namespace Lab5.Pages.Book;

public class DeleteModel : PageModel
{
    private IRepository<Models.Book> _repository;

    [BindProperty]
    public Models.Book Book { get; set; } = default!;

    public DeleteModel(IRepository<Models.Book> repository) => _repository = repository;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || !await _repository.ExistsAsync(id.Value))
        {
            return NotFound();
        }

        Book = await _repository.GetAsync(id.Value);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        if (id == null || !await _repository.ExistsAsync(id.Value))
        {
            return NotFound();
        }

        await _repository.DeleteAsync(id.Value);

        return RedirectToPage("./Index");
    }
}
