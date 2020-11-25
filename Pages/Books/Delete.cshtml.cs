using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pop_Simona_Lab8.Data;
using Pop_Simona_Lab8.Models;

namespace Pop_Simona_Lab8.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly Pop_Simona_Lab8.Data.Pop_Simona_Lab8Context _context;

        public DeleteModel(Pop_Simona_Lab8.Data.Pop_Simona_Lab8Context context)
        {
            _context = context;
        }

        [BindProperty]
        public book book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            book = await _context.book.FirstOrDefaultAsync(m => m.ID == id);

            if (book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            book = await _context.book.FindAsync(id);

            if (book != null)
            {
                _context.book.Remove(book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
