using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    [Route("/api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var BookFromDb = _db.Book.FirstOrDefault(b => b.Id == Id);
            if (BookFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            } else
            {
                _db.Book.Remove(BookFromDb);
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Book deleted successfully" });
            }
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
