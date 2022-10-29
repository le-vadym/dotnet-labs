using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab5.Repositories;

namespace Lab5.Pages.BookBorrow;

public class DetailsModel : PageModel
{
    private readonly IRepository<Models.BookBorrow> _repository;

    public DetailsModel(IRepository<Models.BookBorrow> repository) => _repository = repository;

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
}
