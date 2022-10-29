using Lab5.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab5.Pages.Address;

public sealed class IndexModel : PageModel
{
    private readonly IRepository<Models.Address> _repository;

    public IEnumerable<Models.Address> Addresses { get;set; } = default!;

    public IndexModel(IRepository<Models.Address> repository)
    {
        _repository = repository;
    }

    public async Task OnGetAsync()
    {
        Addresses = await _repository.GetAllAsync();
    }
}
