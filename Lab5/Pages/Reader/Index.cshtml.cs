using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab5.Repositories;

namespace Lab5.Pages.Reader;

public class IndexModel : PageModel
{
    private readonly IRepository<Models.Reader> _repository;

    public IndexModel(IRepository<Models.Reader> repository) => _repository = repository;

    public IEnumerable<Models.Reader> Readers { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Readers = await _repository.GetAllAsync();
    }
}
