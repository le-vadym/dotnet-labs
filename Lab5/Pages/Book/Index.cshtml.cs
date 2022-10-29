using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab5.Repositories;

namespace Lab5.Pages.Book;

public class IndexModel : PageModel
{
    private IRepository<Models.Book> _repository;

    public IEnumerable<Models.Book> Books { get; set; } = default!;

    public IndexModel(IRepository<Models.Book> repository) => _repository = repository;

    public async Task OnGetAsync()
    {
        Books = await _repository.GetAllAsync();
    }
}
