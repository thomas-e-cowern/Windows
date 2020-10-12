using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set;}

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        public async Task<ActionResult> OnPostDelete(int Id)
        {
            var Book = await _db.Book.FindAsync(Id);

            if (Book == null)
            {
                return NotFound();
            } else
            {
                _db.Book.Remove(Book);
                await _db.SaveChangesAsync();
                return Redirect("BookList");
            }
        }
    }
}
