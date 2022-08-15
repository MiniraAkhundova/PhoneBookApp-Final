using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneBookApp.Data;
using PhoneBookApp.Models;

namespace PhoneBookApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly PhoneBookApp.Data.PhoneBookContext _context;

        public CreateModel(PhoneBookApp.Data.PhoneBookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PhoneBookItem PhoneBookItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PhoneBookItems == null || PhoneBookItem == null)
            {
                return Page();
            }

            _context.PhoneBookItems.Add(PhoneBookItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
