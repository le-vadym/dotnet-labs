using Lab5.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab5.Pages.Reader;

public class EditModel : PageModel
{
    private readonly IRepository<Models.Reader> _repository;
    private readonly IRepository<Models.Address> _addressRepository;

    public EditModel(IRepository<Models.Reader> repository, IRepository<Models.Address> addressRepository)
    {
        _repository = repository;
        _addressRepository = addressRepository;
    }

    [BindProperty]
    public Models.Reader Reader { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || !await _repository.ExistsAsync(id.Value))
        {
            return NotFound();
        }

        ViewData["AddressId"] = new SelectList(await _addressRepository.GetAllAsync(), "Id", "Description");
        Reader = await _repository.GetAsync(id.Value);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            await _repository.UpdateAsync(Reader.Id, Reader);
        }
        catch
        {
            if (!await _repository.ExistsAsync(Reader.Id))
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
