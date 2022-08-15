using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Data;
using PhoneBookApp.Models;

namespace PhoneBookApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly PhoneBookApp.Data.PhoneBookContext _context;

        public DeleteModel(PhoneBookApp.Data.PhoneBookContext context)
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

            var phonebookitem = await _context.PhoneBookItems.FirstOrDefaultAsync(m => m.Id == id);

            if (phonebookitem == null)
            {
                return NotFound();
            }
            else 
            {
                PhoneBookItem = phonebookitem;
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.PhoneBookItems == null)
            {
                return NotFound();
            }
            var phonebookitem = await _context.PhoneBookItems.FindAsync(id);

            if (phonebookitem != null)
            {
                PhoneBookItem = phonebookitem;
                _context.PhoneBookItems.Remove(PhoneBookItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
