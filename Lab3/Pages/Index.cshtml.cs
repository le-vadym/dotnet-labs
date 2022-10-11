using Lab3.Models;
using Lab3.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<BookBorrow> _repository;
        public IEnumerable<BookBorrow> BookBorrows => _repository.GetAllAsync().Result;

        public IndexModel(IRepository<BookBorrow> repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
        }
    }
}
