using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab5.Repositories;

namespace Lab5.Pages.Address;

public class EditModel : PageModel
{
    private readonly IRepository<Models.Address> _repository;

    public EditModel(IRepository<Models.Address> repository) => _repository = repository;

    [BindProperty]
    public Models.Address Address { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || !await _repository.ExistsAsync(id.Value))
        {
            return NotFound();
        }

        Address = await _repository.GetAsync(id.Value);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            await _repository.UpdateAsync(Address.Id, Address);
        }
        catch
        {
            if (!await _repository.ExistsAsync(Address.Id))
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
