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
    public class IndexModel : PageModel
    {
        private readonly Pop_Simona_Lab8.Data.Pop_Simona_Lab8Context _context;

        public IndexModel(Pop_Simona_Lab8.Data.Pop_Simona_Lab8Context context)
        {
            _context = context;
        }

        public IList<book> book { get;set; }

        public async Task OnGetAsync()
        {
            book = await _context.book
                .Include(b => b.Publisher)
                .ToListAsync();
        }
    }
}
