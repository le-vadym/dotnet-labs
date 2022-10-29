using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab5.Repositories;

namespace Lab5.Pages.Address;

public class DeleteModel : PageModel
{
    private readonly IRepository<Models.Address> _repository;

    [BindProperty]
    public Models.Address Address { get; set; } = default!;

    public DeleteModel(IRepository<Models.Address> repository) => _repository = repository;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || !await _repository.ExistsAsync(id.Value))
        {
            return NotFound();
        }

        Address = await _repository.GetAsync(id.Value);

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
