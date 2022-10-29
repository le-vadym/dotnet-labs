using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab5.Repositories;

namespace Lab5.Pages.Reader;

public class DetailsModel : PageModel
{
    private readonly IRepository<Models.Reader> _repository;

    public DetailsModel(IRepository<Models.Reader> repository) => _repository = repository;

    public Models.Reader Reader { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || !await _repository.ExistsAsync(id.Value))
        {
            return NotFound();
        }

        Reader = await _repository.GetAsync(id.Value);

        return Page();
    }
}
