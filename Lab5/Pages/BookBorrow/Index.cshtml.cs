using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab5.Repositories;

namespace Lab5.Pages.BookBorrow;

public class IndexModel : PageModel
{
    private readonly IRepository<Models.BookBorrow> _repository;

    public IndexModel(IRepository<Models.BookBorrow> repository) => _repository = repository;

    public IEnumerable<Models.BookBorrow> BookBorrows { get;set; } = default!;

    public async Task OnGetAsync()
    {
        BookBorrows = await _repository.GetAllAsync();
    }
}
