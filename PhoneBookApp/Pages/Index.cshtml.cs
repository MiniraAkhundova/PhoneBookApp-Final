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
    public class IndexModel : PageModel
    {
        private readonly PhoneBookApp.Data.PhoneBookContext _context;

        public IndexModel(PhoneBookApp.Data.PhoneBookContext context)
        {
            _context = context;
        }

        public IList<PhoneBookItem> PhoneBookItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PhoneBookItems != null)
            {
                PhoneBookItem = await _context.PhoneBookItems.ToListAsync();
            }
        }
    }
}
