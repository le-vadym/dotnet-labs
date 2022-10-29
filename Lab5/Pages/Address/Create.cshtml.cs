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

namespace Lab5.Pages.Address
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Models.Address> _repository;

        public CreateModel(IRepository<Models.Address> repository) => _repository = repository;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Address Address { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repository.CreateAsync(Address);

            return RedirectToPage("./Index");
        }
    }
}
