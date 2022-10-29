using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;
using Lab5.Repositories;

namespace Lab5.Pages.Address
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Models.Address> _repository;

        public Models.Address Address { get; set; } = default!;

        public DetailsModel(IRepository<Models.Address> repository) => _repository = repository;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || !await _repository.ExistsAsync(id.Value))
            {
                return NotFound();
            }

            Address = await _repository.GetAsync(id.Value);

            return Page();
        }
    }
}
