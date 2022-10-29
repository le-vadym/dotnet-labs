using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab5.Repositories;

namespace Lab5.Pages.BookBorrow;

public class DeleteModel : PageModel
{
    private readonly IRepository<Models.BookBorrow> _repository;

    public DeleteModel(IRepository<Models.BookBorrow> repository) => _repository = repository;

    [BindProperty]
    public Models.BookBorrow BookBorrow { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || !await _repository.ExistsAsync(id.Value))
        {
            return NotFound();
        }

        BookBorrow = await _repository.GetAsync(id.Value);

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
