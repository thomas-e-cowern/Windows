using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        [BindProperty]
        public Book Book { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync(int Id)
        {
            Book = await _db.Book.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            var BookFromDb = await _db.Book.FindAsync(Book.Id);
            BookFromDb.Name = Book.Name;
            BookFromDb.Author = Book.Author;
            BookFromDb.ISBN = Book.ISBN;

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
