using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Data;
using PhoneBookApp.Models;

namespace PhoneBookApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly PhoneBookApp.Data.PhoneBookContext _context;

        public EditModel(PhoneBookApp.Data.PhoneBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PhoneBookItem PhoneBookItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.PhoneBookItems == null)
            {
                return NotFound();
            }

            var phonebookitem =  await _context.PhoneBookItems.FirstOrDefaultAsync(m => m.Id == id);
            if (phonebookitem == null)
            {
                return NotFound();
            }
            PhoneBookItem = phonebookitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PhoneBookItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneBookItemExists(PhoneBookItem.Id))
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

        private bool PhoneBookItemExists(Guid id)
        {
          return (_context.PhoneBookItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
