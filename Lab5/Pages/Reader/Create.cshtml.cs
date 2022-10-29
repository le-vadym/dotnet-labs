using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5.Data;
using Lab5.Models;
using Lab5.Repositories;

namespace Lab5.Pages.Reader
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Models.Reader> _repository;
        private readonly IRepository<Models.Address> _addressRepository;

        public CreateModel(IRepository<Models.Reader> repository, IRepository<Models.Address> addressRepository)
        {
            _repository = repository;
            _addressRepository = addressRepository;
        }

        [BindProperty]
        public Models.Reader Reader { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["AddressId"] = new SelectList(await _addressRepository.GetAllAsync(), "Id", "Description");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _repository.CreateAsync(Reader);

            return RedirectToPage("./Index");
        }
    }
}
